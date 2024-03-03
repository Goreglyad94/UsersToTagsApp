using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsersToTagsApp.Domain.Tags;
using UsersToTagsApp.Domain.TagsToUsers;

namespace UsersToTagsApp.Core.Context.ContextConfigurations
{
    public class TagsConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("tags")
                .HasMany(x => x.Users)
                .WithMany(x => x.Tags)
                .UsingEntity<TagToUser>();
        }
    }
}
