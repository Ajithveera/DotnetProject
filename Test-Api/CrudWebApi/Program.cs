using CrudWebApi.Database;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<EmployeeDBContext>(Options => Options.UseSqlServer
(builder.Configuration.GetConnectionString("sqlConnectionstring")));

builder .Services.AddCors((CorsOptions)=>
{
CorsOptions.AddPolicy("MyPolicy", (policyoptions) =>
{
    policyoptions.AllowAnyHeader().AllowAnyOrigin().AllowAnyHeader();
});
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
