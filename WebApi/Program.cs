using Core.AutoMapper;
using Core.Validation;
using FluentValidation;
using InfraEstrutura;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces.InterfacesServices;
using Services.Interfaces.Service;
using Services.Repositorios.InterfacesRepositorios;
using Services.Repositorios.RepositoriosServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<GestaoDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<GestaoDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
//);


builder.Services.AddDbContext<GestaoDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Usual db context registration
builder.Services.AddScoped<DbContext, GestaoDbContext>(); // This is what I added

//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); // My custom service




builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<IEscolaRepository, EscolaRepository>();
builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();
builder.Services.AddScoped<ICursoRepository, CursoRepository>();

builder.Services.AddScoped<IAlunoService, AlunoService>();
builder.Services.AddScoped<IEscolaService, EscolaService>();
builder.Services.AddScoped<IProfessorService, ProfessorService>();
builder.Services.AddScoped<ICursoService, CursoService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddValidatorsFromAssemblyContaining<AlunoDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CursoDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<EscolaDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<ProfessorDtoValidator>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
