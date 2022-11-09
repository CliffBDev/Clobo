

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Add migration and initializer in infrastructure initializer and do it here



app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();