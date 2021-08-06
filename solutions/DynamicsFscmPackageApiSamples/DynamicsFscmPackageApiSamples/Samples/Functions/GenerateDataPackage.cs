using DynamicsFscmPackageApiSamples.Samples.DemoData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DynamicsFscmPackageApiSamples.Samples.Functions
{
    public static class GenerateDataPackage
    {
        [FunctionName(nameof(GenerateDataPackage))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req)
        {
            List<dynamic> entities = DataHelper.Entities();
            var packageStream = new MemoryStream();

            using (var packageTemplateStream = new MemoryStream(Resource.PackageTemplate))
            {
                await packageTemplateStream.CopyToAsync(packageStream);
            }

            using (var packageZip = new ZipArchive(packageStream, ZipArchiveMode.Update, true))
            {
                foreach (var entity in entities)
                {
                    packageZip.GetEntry($"{entity.Label}.xml").Delete();
                    ZipArchiveEntry fileEntry = packageZip.CreateEntry($"{entity.Label}.xml");

                    using var memoryStream = new MemoryStream();
                    using var sw = new StringWriter();
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add(String.Empty, String.Empty);

                    using XmlWriter xmlWriter = XmlWriter.Create(sw, new XmlWriterSettings { OmitXmlDeclaration = true });
                    new XmlSerializer(entity.Document.GetType()).Serialize(xmlWriter, entity.Document, ns);
                    memoryStream.Write(Encoding.UTF8.GetBytes(sw.ToString()));
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    await memoryStream.CopyToAsync(fileEntry.Open());
                }
            }

            packageStream.Seek(0, SeekOrigin.Begin);

            return new FileStreamResult(packageStream, "application/zip")
            {
                FileDownloadName = $"{Guid.NewGuid()}.zip",
            };
        }
    }
}
