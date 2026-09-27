using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using QuickTransfer.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Services;

public class SessionCleanupService : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    
    public SessionCleanupService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider
                .GetRequiredService<AppDbContext>();

            var expiredSessions = await context.Sessions
                .Where(s => s.ExpiresAt <= DateTime.UtcNow)
                .ToListAsync(stoppingToken);

            if (expiredSessions.Count > 0)
            {
                context.Sessions.RemoveRange(expiredSessions);
                await context.SaveChangesAsync(stoppingToken);
            }

            await Task.Delay(
                TimeSpan.FromMinutes(1),
                stoppingToken);
        }
    }
}