using System.ComponentModel;
using Core.Entities;
using Infrastructure.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

/// <summary>
/// Конфигурация для <see cref="Call"/>
/// </summary>
public class CallConfiguration : IEntityTypeConfiguration<Call>
{
    public void Configure(EntityTypeBuilder<Call> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(c => c.Title)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.ScheduledAt)
            .IsRequired();
        
        builder.Property(c => c.HangfireJobId);

        builder.Property(c => c.NotifyBefore)
            .HasConversion<TimeSpanToSecondsConverter>();
        
        builder.Property(c => c.CreatedByUserId)
            .IsRequired();

        builder.HasMany(c => c.Participants)
            .WithOne(cp => cp.Call)
            .HasForeignKey(cp => cp.CallId)
            .HasPrincipalKey(c => c.Id)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(c => c.CreatedByUser)
            .WithMany()
            .HasForeignKey(c => c.CreatedByUserId)
            .HasPrincipalKey(u => u.Id)
            .OnDelete(DeleteBehavior.Cascade); 
    }
}