using Microsoft.EntityFrameworkCore;
using StudentHive.Domain.Entities;

namespace StudentHive.Infrastructure.Repositories;

public class AdministradorRepository
{
    private readonly StudentHiveDbContext _context;
    public AdministradorRepository(StudentHiveDbContext context)
    {
        this._context = context;
    }

    public async Task<IEnumerable<Administrador>> GetAll()
    {
        var Administradores = await _context.Administrador
        .Include(nombreRol => nombreRol.IdRolNavigation)
        .ToListAsync();
        return Administradores;
    }

    public async Task<Administrador> GetById(int id)
    {
        var Administrador = await _context.Administrador.FirstOrDefaultAsync(Administrador => Administrador.IdAdmin == id);
        return Administrador ?? new Administrador();
    }

    public async Task<Administrador> GetByEmail(string email)
    {
        var Administrador = await _context.Administrador
        .Include(u => u.IdRolNavigation)
        .FirstOrDefaultAsync(Administrador => Administrador.Email == email);
        return Administrador ?? new Administrador();
    }

    public async Task Add(Administrador administrador)
    {
        await _context.AddAsync(administrador);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Administrador updatedAdministrador)
    {
        _context.Administrador.Update(updatedAdministrador);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var administrador = await _context.Administrador.FirstOrDefaultAsync(administrador => administrador.IdAdmin == id);
        if (administrador != null)
        {
            _context.Administrador.Remove(administrador);
            await _context.SaveChangesAsync();
        }
    }

}