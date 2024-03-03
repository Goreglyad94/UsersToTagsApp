using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsersToTagsApp.Domain.TagsToUsers;

namespace UsersToTagsApp.Core.Context.ContextConfigurations
{
    public class TagsToUsersConfiguration : IEntityTypeConfiguration<TagToUser>
    {
        public void Configure(EntityTypeBuilder<TagToUser> builder)
        {
            builder.ToTable("tags_to_users");
        }
    }
}
