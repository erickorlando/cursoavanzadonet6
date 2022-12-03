using GalaxyApp.AccesoDatos;
using GalaxyApp.Entidades;
using GalaxyApp.Repositorios;
using GalaxyApp.Servicios;
using GalaxyApp.Servicios.Profiles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<AppSettings>(builder.Configuration);

builder.Services.AddDbContext<InstitutoDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("InstitutoDb"));
});

builder.Services.AddIdentity<GalaxyUser, IdentityRole>(setup =>
{

    setup.Password.RequireNonAlphanumeric = true;
    setup.Password.RequireUppercase = false;
    setup.Password.RequireLowercase = false;
    setup.Password.RequireDigit = false;
    setup.Password.RequiredLength = 8;

    setup.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<InstitutoDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<TallerProfile>();
    config.AddProfile<InstructorProfile>();
});

builder.Services.AddTransient<ITallerRepository, TallerRepository>();
builder.Services.AddTransient<IInstructorRepository, InstructorRepository>();
builder.Services.AddTransient<ITallerService, TallerService>();
builder.Services.AddTransient<IFileUploader, FileUploader>();
builder.Services.AddTransient<IUsuarioService, UsuarioService>();

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
