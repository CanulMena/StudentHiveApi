using StudentHive.Domain.Entities;
using StudentHive.Infrastructure.Repositories;

namespace StudentHive.Services.Features.Requests;

public class RequestService
{
    private readonly RequestRepository _requestRepository;

    public RequestService(RequestRepository requestRepository)
    {
        _requestRepository = requestRepository;
    }

    public async Task<IEnumerable<Request>> GetAll()
    {
        return await _requestRepository.GetAllRequests();
    }

    public async Task<Request> GetById(int id)
    {
        return await _requestRepository.GetRequestById(id);
    }

    public async Task Add(Request request)
    {
        await _requestRepository.CreateRequest(request);
    }

    public async Task Update(Request request)
    {
        await _requestRepository.UpdateRequest(request);
    }

    public async Task Delete(int id)
    {
        await _requestRepository.DeleteRequest(id);
    }

    public async Task<IEnumerable<Request>> GetByUserId(int id)
    {
        return await _requestRepository.GetRequestsByUserId(id);
    }

    public async Task<IEnumerable<Request>> GetByPublicationId(int id)
    {
        return await _requestRepository.GetRequestsByPublicationId(id);
    }

}