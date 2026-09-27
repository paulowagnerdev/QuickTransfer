using Application.DTO;
using Application.DTO.Results;

namespace Application.Interfaces;

public interface ISessionService
{
    public Task<ResultT<SessionResponse>> CreateSessionAsync();
    public Task<ResultT<SessionResponse>> GetSessionAsync(Guid id);
    public Task<Result> DeleteSessionAsync(Guid id);
}