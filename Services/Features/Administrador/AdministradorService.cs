using StudentHive.Domain.Entities;
using StudentHive.Infrastructure.Repositories;

namespace StudentHive.Services.Features.Administradors;

public class AdministradorService
{
    private readonly AdministradorRepository _AdministradorRepository;

    public AdministradorService(AdministradorRepository administradorRepository)
    {
        _AdministradorRepository = administradorRepository;


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

    public async Task Add(Administrador administrador)
    {
        await _AdministradorRepository.Add(administrador);
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