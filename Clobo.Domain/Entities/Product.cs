using System;
using Clobo.Domain.Base;

namespace Clobo.Domain.Entities
{
    public class Product : TrackableEntity
    {
        public Product()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string? SerialNumber { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}

