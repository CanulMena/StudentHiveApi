using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using StudentHive.Domain.Dtos;
using StudentHive.Domain.Entities;
using StudentHive.Infrastructure.Repositories;
using StudentHiveApi.Services.Features.PswdHasher;

namespace StudentHive.Services.Features.Administradors;

public class AdministradorService
{
    private readonly AdministradorRepository _AdministradorRepository;
    private readonly PasswordHasher _passwordHasher;

    private readonly IConfiguration _configuration;

    public AdministradorService(AdministradorRepository administradorRepository, PasswordHasher passwordHasher, IConfiguration configuration)
    {
        _AdministradorRepository = administradorRepository;
        _passwordHasher = passwordHasher;
        _configuration = configuration;

    }

    public async Task<IEnumerable<Administrador>> GetAll()
    {
        return await _AdministradorRepository.GetAll();
    }

    public async Task<Administrador> GetById(int id)
    {
        var administrador = await _AdministradorRepository.GetById(id);

        if (administrador == null)
        {
            throw new InvalidOperationException($"Administrador with ID {id} not found.");
        }
        return administrador;
    }
    
    public async Task<string> AuthLogin(AuthLoginDTO authLoginDTO)
    {
        if (authLoginDTO.Email == null || authLoginDTO.Password == null)
            return "";

            var administrador = await _AdministradorRepository.GetByEmail(authLoginDTO.Email);
            if(administrador.IdAdmin <= 0 || administrador.Password == null)
                return "";

            var result = _passwordHasher.Verify(administrador.Password, authLoginDTO.Password);

            if (!result)
            {
                return "";
            }

            string token = GenerateToken(administrador);

            return token;
    }

    public string GenerateToken(Administrador administrador)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Email, administrador.Email ?? ""),
            new Claim(ClaimTypes.Role, administrador.IdRolNavigation?.NombreRol ?? "")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var securityToken = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(365),
            signingCredentials: creds
        );
        var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
        return token;
    }

    public async Task Add(Administrador administrador)
    {
        await _AdministradorRepository.Add(administrador);
    }

    public string HashPassword(string password)
    {
        return _passwordHasher.Hash(password);
    }
    public async Task Update(Administrador administrador)
    {
        await _AdministradorRepository.Update(administrador);
    }

    public async Task Delete(int id)
    {
        await _AdministradorRepository.Delete(id);
    }
}