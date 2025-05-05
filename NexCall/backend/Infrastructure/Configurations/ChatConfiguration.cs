using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

/// <summary>
/// Конфигурация для <see cref="Chat"/>
/// </summary>
[Obsolete("Chat не используется в данный момент, но может быть использован в будущем")]
public class ChatConfiguration /*:  IEntityTypeConfiguration<Chat>*/
{
    /*public void Configure(EntityTypeBuilder<Chat> builder)
    {
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.HasOne(c => c.User1)
            .WithMany()
            .HasForeignKey(c => c.User1Id)
            .HasPrincipalKey(x => x.Id);

        builder.HasOne(c => c.User2)
            .WithMany()
            .HasForeignKey(c => c.User2Id)
            .HasPrincipalKey(x => x.Id);

        builder.HasMany(c => c.Messages)
            .WithOne(m => m.Chat)
            .HasForeignKey(m => m.ChatId)
            .OnDelete(DeleteBehavior.Cascade);

        // Уникальность пары участников (в обеих комбинациях)
        builder.HasIndex(c => new { c.User1Id, c.User2Id })
            .IsUnique();
    }*/
}