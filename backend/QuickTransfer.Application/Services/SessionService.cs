using Application.DTO;
using Application.DTO.Results;
using Application.Interfaces;
using Application.Services.Token;
using Microsoft.EntityFrameworkCore;
using QuickTransfer.Entities.Domain;
using QuickTransfer.Infrastructure.Data;

namespace Application.Services;

public class SessionService : ISessionService
{
    private AppDbContext _context;

    public SessionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ResultT<SessionResponse>> CreateSessionAsync()
    {
        string token = TokenMaker.CreateToken();
        DateTime expiresTime = DateTime.UtcNow.AddMinutes(15);
        
        Session session = new Session(token, expiresTime);
        _context.Sessions.Add(session);
        await _context.SaveChangesAsync(); 
        
        var newSessionResponse = new SessionResponse()
        {
            ExpiresAt = expiresTime,
            Id = session.PublicId
        };
        
        return ResultT<SessionResponse>.Success(newSessionResponse);
    }
    public async Task<ResultT<SessionResponse>> GetSessionAsync(Guid id)
    {
        var session = await _context.Sessions.FirstOrDefaultAsync(s => s.PublicId == id);

        if (session is null)
        {
            return ResultT<SessionResponse>.Failure("Session not found");
        }

        if (session.ExpiresAt < DateTime.UtcNow)
        {
            return ResultT<SessionResponse>.Failure("Expired Session!");
        }
        
        var newSessionResponse = new SessionResponse()
        {
            ExpiresAt = session.ExpiresAt,
            Id = session.PublicId
        };
        
        return ResultT<SessionResponse>.Success(newSessionResponse);
        
    }
    public Task<Result> DeleteSessionAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}