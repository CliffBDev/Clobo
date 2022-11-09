using System;
namespace Clobo.Domain.Base
{
    public class TrackableEntity
    {
        public TrackableEntity()
        {
        }
        public string? CreatedBy { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime LastModified { get; set; } = DateTime.UtcNow;
    }
}

