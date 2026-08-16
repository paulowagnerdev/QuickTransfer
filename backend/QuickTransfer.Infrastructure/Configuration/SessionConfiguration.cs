using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickTransfer.Entities.Domain;

namespace QuickTransfer.Infrastructure.Configuration;

public class SessionConfiguration : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        builder.HasKey(m => m.Id);
        
        builder.Property(m => m.Id).ValueGeneratedOnAdd();
        
        builder.HasMany(x => x.Messages)
            .WithOne(x => x.Session)
            .HasForeignKey(x => x.SessionId);
    }
}