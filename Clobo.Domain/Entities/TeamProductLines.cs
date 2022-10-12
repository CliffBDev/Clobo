using System;
namespace Clobo.Domain.Entities
{
    public class TeamProductLines
    {
        public TeamProductLines()
        {
        }

        public int Id { get; set; }
        public IList<Team> Teams { get; set; }
        public IList<Product> Products { get; set; }
    }
}

