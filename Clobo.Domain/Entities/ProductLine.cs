using System;
using Clobo.Domain.Base;

namespace Clobo.Domain.Entities
{
    public class ProductLine : TrackableEntity
    {
        public ProductLine()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Product> Products { get; set; }
    }
}

