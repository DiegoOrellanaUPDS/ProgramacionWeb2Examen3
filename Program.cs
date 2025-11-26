using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ExamenFinalProgramacionWeb2.Data;
var builder = WebApplication.CreateBuilder(args);

var url = Environment.GetEnvironmentVariable("DATABASE");

builder.Services.AddDbContext<ExamenFinalProgramacionWeb2Context>(options =>
    options.UseNpgsql(url));
Console.WriteLine($"la cadena es : {url}");

// Add services to the container.
builder.WebHost.UseUrls("http://0.0.0.0:8080");
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ExamenFinalProgramacionWeb2Context>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
