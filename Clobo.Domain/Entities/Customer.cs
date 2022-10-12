using System;
using Clobo.Domain.Base;

namespace Clobo.Domain.Entities
{
    public class Customer : TrackableEntity
    {
        public Customer()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public IList<CustomerUser> CustomerUsers { get; set; }
    }
}

