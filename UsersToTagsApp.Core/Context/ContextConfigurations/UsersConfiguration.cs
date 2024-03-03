using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsersToTagsApp.Domain.TagsToUsers;
using UsersToTagsApp.Domain.Users;

namespace UsersToTagsApp.Core.Context.ContextConfigurations
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users")
                .HasMany(x => x.Tags)
                .WithMany(x => x.Users)
                .UsingEntity<TagToUser>();
        }
    }
}
