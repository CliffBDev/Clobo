using System;
using Clobo.Domain.Base;

namespace Clobo.Domain.Entities
{
    public class CustomerUser : TrackableEntity
    {
        public CustomerUser()
        {
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public bool IsPrimary { get; set; }
    }
}

