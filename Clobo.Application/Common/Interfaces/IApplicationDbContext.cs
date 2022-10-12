using Clobo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clobo.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<Agent> Agents { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerUser> CustomerUsers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductLine> ProductLines { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<TeamAgent> TeamAgents { get; set; }
    public DbSet<TeamProductLines> TeamProductLines { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}