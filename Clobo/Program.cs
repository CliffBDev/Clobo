using Clobo.Infrastructure.Persistance;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Configure services from Application
builder.Services.AddApplicationServices();
//Configure services from Infrastructure
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((hostContext, services, configuration) =>
{
    configuration.WriteTo.Console();
    configuration.WriteTo.File($"{AppDomain.CurrentDomain.BaseDirectory}logs/log-.txt", rollingInterval: RollingInterval.Hour);
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var initialiser = scope.ServiceProvider.GetRequiredService<DatabaseContextInitializer>();
    await initialiser.MigrateAsync();
}

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


//Add migration and initializer in infrastructure initializer and do it here



app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();