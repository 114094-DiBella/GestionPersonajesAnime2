using Microsoft.EntityFrameworkCore;
using WebApplication1.Repositories;
using WebApplication1.Services.Impl;
using WebApplication1.Services;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IPersonajeService, PersonajeService>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<PersonajeRepository>();
builder.Services.AddAutoMapper(config =>
{
    config.AddMaps(typeof(Program).Assembly);

});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod();
    });
});

/* 
 * builder.Services.AddDbContext<GestionAnimeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("connectionString")));
*/
builder.Services.AddDbContext<GestionAnimeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("connectionString")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// Comandos: 
// add-migration initialCreate
// database-update

// Scaffold-DbContext "TuCadenaDeConexion" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force
// Scaffold - DbContext "TuCadenaDeConexion" Microsoft.EntityFrameworkCore.SqlServer - OutputDir Models - Force