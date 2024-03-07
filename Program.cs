using StudentHive.Domain.Entities;
using StudentHive.Services.Features.Users;
using StudentHiveApi.Services.Features.PswdHasher;
using StudentHive.Services.Mappings;
using StudentHive.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using CloudinaryDotNet;
using System.Security.Claims;
using System.Text;
using StudentHive.Services.Features.RentalHouses;
using StudentHive.Services.Features.Administradors;
using StudentHive.Services.Features.CoudinaryRentalHouses;
using StudentHive.Services.Features.Reports;


var builder = WebApplication.CreateBuilder(args);

var Configuration = builder.Configuration;

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetSection("Jwt:Key").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

// user services
builder.Services.AddScoped<UsersService>();  
builder.Services.AddTransient<UserRepository>(); 

// rental house services
builder.Services.AddScoped<RentalHouseService>();
builder.Services.AddTransient<RentalHouseRepository>();

// report services
builder.Services.AddScoped<ReportService>();
builder.Services.AddTransient<ReportRepository>();

// admin services
builder.Services.AddScoped<AdministradorService>();
builder.Services.AddTransient<AdministradorRepository>();

builder.Services.AddScoped<PasswordHasher>(); 


builder.Services.AddControllers(); //*<--- Controller services added 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new() { Title = "StudentHive", Version = "v1" });

    s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
    });

    s.AddSecurityRequirement(new OpenApiSecurityRequirement{
        {
            new OpenApiSecurityScheme{
                Reference = new OpenApiReference{
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Usuario", policy => policy.RequireClaim(ClaimTypes.Role, "Usuario"));
    options.AddPolicy("Administrador", policy => policy.RequireClaim(ClaimTypes.Role, "Administrador"));
});

builder.Services.AddDbContext<StudentHiveDbContext>(
    options => {
        options.UseSqlServer(Configuration.GetConnectionString("gemDevelopment"));
    }
);

var cloudinarySettings = builder.Configuration.GetSection("Cloudinary");
Account account = new Account(
    cloudinarySettings["CloudName"],
    cloudinarySettings["ApiKey"],
    cloudinarySettings["ApiSecret"]
);
Cloudinary cloudinary = new Cloudinary(account);

builder.Services.AddSingleton(cloudinary);
builder.Services.AddScoped<ImageUploadService>();
builder.Services.AddScoped<CloudinaryRentalHouse>();




builder.Services.AddAutoMapper(typeof(ResponseMappingProfile).Assembly);
builder.Services.AddAutoMapper(typeof(RequestCreateMappingProfile).Assembly);
builder.Services.AddAutoMapper(typeof(UpdateMappingProfile).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure Swagger for all environments
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
