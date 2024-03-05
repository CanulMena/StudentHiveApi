using StudentHive.Domain.Entities;
// using StudentHive.Services.Features.RentalHouses;
using StudentHive.Services.Features.Users;
using StudentHive.Services.Mappings;
using Microsoft.EntityFrameworkCore;
using StudentHive.Infrastructure.Repositories;
using StudentHive.Controllers.V1;
using StudentHive.Services.Features.Administradors;
using StudentHive.Services.Features.RentalHouses;
using CloudinaryDotNet;
using StudentHive.Services.Features.CoudinaryRentalHouses;


var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;

//*Add services container services
//TODO: Agregar mis repositorios

//rental House
builder.Services.AddScoped<RentalHouseService>(); //
builder.Services.AddTransient<RentalHouseRepository>();

builder.Services.AddScoped<UsersService>(); // 
builder.Services.AddTransient<UserRepository>(); 

// Administrador 
builder.Services.AddScoped<AdministradorService>();
builder.Services.AddTransient<AdministradorRepository>();

// builder.Services.AddSingleton<RentalHouseService>(); //*<--- Singleton services added 
// builder.Services.AddSingleton<UsersService>(); //*<--- Singleton services added 

builder.Services.AddControllers(); //*<--- Controller services added 
builder.Services.AddDbContext<StudentHiveDbContext>(
    options => {
        options.UseSqlServer(Configuration.GetConnectionString("gemDevelopment"));
    }
);
//*Add services to the container.   
var cloudinarySettings = builder.Configuration.GetSection("Cloudinary");
    Account account = new Account(
        cloudinarySettings["CloudName"],
        cloudinarySettings["ApiKey"],
        cloudinarySettings["ApiSecret"]
    );
    Cloudinary cloudinary = new Cloudinary(account);
    builder.Services.AddScoped<CloudinaryRentalHouse>();

    builder.Services.AddSingleton(cloudinary);
    
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//*Using mappings services
builder.Services.AddAutoMapper(typeof(ResponseMappingProfile).Assembly);
builder.Services.AddAutoMapper(typeof(RequestCreateMappingProfile).Assembly);
builder.Services.AddAutoMapper(typeof(UpdateMappingProfile).Assembly);

var app = builder.Build();

// Configure Swagger for all environments
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
