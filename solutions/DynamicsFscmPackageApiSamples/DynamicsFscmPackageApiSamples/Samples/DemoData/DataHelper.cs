using DynamicsFscmPackageApiSamples.Common.Models;
using DynamicsFscmPackageApiSamples.Samples.Models;
using System.Collections.Generic;

namespace DynamicsFscmPackageApiSamples.Samples.DemoData
{
    public static class DataHelper
    {
        public static List<dynamic> Entities()
        {
            return new List<dynamic>
            {
                new Entity<CustCustomerGroupEntity>(
                    new List<CustCustomerGroupEntity>
                    {
                        new CustCustomerGroupEntity
                        {
                            CustomerGroupId = "US-001"
                        },
                        new CustCustomerGroupEntity
                        {
                            CustomerGroupId = "US-002"
                        }
                    },
                    "Customer groups")
            };
        }
    }
}
