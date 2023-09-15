using Microsoft.EntityFrameworkCore;
using MultiplaDatabaseConnection.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SqlContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"));
});

builder.Services.AddDbContext<PostgresContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("postgresConnection"));
});

var app = builder.Build();

app.MapGet("/Products", async (PostgresContext context) => Results.Ok(await context.Products.ToListAsync()));
app.MapGet("/Clients", async (SqlContext context) => Results.Ok(await context.Clients.ToListAsync()));

app.Run();