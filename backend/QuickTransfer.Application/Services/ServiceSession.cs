using Application.DTO;
using Application.Interfaces;
using QuickTransfer.Entities.Domain;
using QuickTransfer.Infrastructure.Data;

namespace Application.Services;

public class ServiceSession : ISessionService
{
    private AppDbContext _context;

    public ServiceSession(AppDbContext context)
    {
        _context = context;
    }
    public SessionDTO CreateSession()
    {
        string token = CreateToken();
        DateTime expirationDate = DateTime.Now.AddMinutes(30);
        
        var session = new Session(token,expirationDate);
        return new SessionDTO();
    }

    private string CreateToken()
    {
        throw new NotImplementedException();
    }
}