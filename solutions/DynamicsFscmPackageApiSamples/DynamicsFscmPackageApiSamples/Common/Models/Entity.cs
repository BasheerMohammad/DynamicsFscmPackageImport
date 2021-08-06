using System.Collections.Generic;

namespace DynamicsFscmPackageApiSamples.Common.Models
{
    public class Entity<T>
    {
        public Entity(List<T> document, string label)
        {
            Label = label;
            Document = new EntityDocument<T>
            {
                Entity = document
            };
        }
        public string Label { get; }
        public EntityDocument<T> Document { get; }
    }
}
