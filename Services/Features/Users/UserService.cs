using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using StudentHive.Domain.Entities;
using StudentHive.Infrastructure.Repositories;
using StudentHiveApi.Services.Features.PswdHasher;
using StudentHive.Domain.Dtos;


namespace StudentHive.Services.Features.Users;
//* This is the layer that uses my database service
//* here i create all the logic that i will use to add the data in the database
public class UsersService
{
    private readonly UserRepository _UserRepository;  
    private readonly IConfiguration _configuration;
    private readonly PasswordHasher _passwordHasher;

    public UsersService( UserRepository userRepository, PasswordHasher passwordHasher, IConfiguration configuration)
    {
        _UserRepository = userRepository;
        _passwordHasher = passwordHasher;
        _configuration = configuration;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _UserRepository.GetAll();
    }

    public async Task<User> GetById( int Userid )//* The user will add the id to find a user from the list _User.id
    {
        return await _UserRepository.GetById( Userid );

    }

    public async Task<string> AuthLogin(AuthLoginDTO authLogin)
    {
        if (authLogin.Email == null || authLogin.Password == null)
            return "";
        //Me regresa la instancia de usuario con el campo de rol
        var user = await _UserRepository.GetUserByEmail(authLogin.Email);
        if (user.IdUser <= 0 || user.Password == null)
            return "";

        var result = _passwordHasher.Verify(user.Password, authLogin.Password);

        if (!result)
        {
            return "";
        }

        string token = GenerateToken(user);


        return token;
    }


    public string GenerateToken(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Name ?? ""),
            new Claim(ClaimTypes.Email, user.Email ?? ""),
            new Claim(ClaimTypes.Role, user.IdRolNavigation?.NombreRol ?? "") 
        };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var securityToken = new JwtSecurityToken(
                                claims: claims,
                                expires: DateTime.Now.AddDays(256),
                                signingCredentials: creds
                            );

        var token = new JwtSecurityTokenHandler().WriteToken(securityToken);    
        return token;
    }

    public async Task Add( User user )
    {
        await _UserRepository.Add( user );
    }

    public string HashPassword(string password)
    {
        return _passwordHasher.Hash(password);
    }

    public async Task<User> GetUserByEmail(string email)
{
    // Realiza una consulta a la base de datos para encontrar al usuario por su correo electrónico
    var user = await _UserRepository.GetUserByEmail(email);
    return user;
}

    public async Task Update(User user)
{
    await _UserRepository.Update(user);
}

    public async Task Delete(int id)
{
    await _UserRepository.Delete(id);
}

public async Task<IEnumerable<User>> GetUsersInWaitList(int requestId)
{
    // Suponiendo que _UserRepository tiene un método GetUsersInWaitList que es asincrónico
    var users = await _UserRepository.GetUsersInWaitList(requestId);
    return users;
}

}