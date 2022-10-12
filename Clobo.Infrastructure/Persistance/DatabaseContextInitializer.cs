using Microsoft.EntityFrameworkCore;

namespace Clobo.Infrastructure.Persistance;

public class DatabaseContextInitializer
{
    private readonly CloboContext _context;

    public DatabaseContextInitializer(CloboContext context)
    {
        _context = context;
    }

    public async Task Migrate()
    {
        await _context.Database.MigrateAsync();
    }
}