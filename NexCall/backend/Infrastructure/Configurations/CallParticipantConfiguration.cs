using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

/// <summary>
/// Конфигурация для <see cref="CallParticipant"/>
/// </summary>
public class CallParticipantConfiguration : IEntityTypeConfiguration<CallParticipant>
{
    public void Configure(EntityTypeBuilder<CallParticipant> builder)
    {
        builder.HasKey(cp => cp.Id);

        builder.Property(cp => cp.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(cp => cp.UserId)
            .IsRequired();

        builder.Property(cp => cp.IsHost)
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(cp => cp.JoinedAt);
        builder.Property(cp => cp.LeftAt);

        builder.HasIndex(cp => new { cp.CallId, cp.UserId })
            .IsUnique();

        builder.HasOne(x => x.User)
            .WithMany(cp => cp.CallParticipants)
            .HasForeignKey(cp => cp.UserId)
            .HasPrincipalKey(u => u.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}