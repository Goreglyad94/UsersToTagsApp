using System.ComponentModel.DataAnnotations;
using UsersToTagsApp.Domain.Tags;
using UsersToTagsApp.Domain.TagsToUsers;

namespace UsersToTagsApp.Domain.Users
{
    public class User
    {
        public User() { }

        public User(Guid userId, string name, string domain)
        {
            UserId = userId;
            Name = name;
            Domain = domain;
        }

        public Guid UserId { get; set; }
        [Required]
        public string Name { get; set; } = default!;
        [Required]
        public string Domain { get; set; } = default!;
        public List<TagToUser>? TagToUsers { get; set; }
        public List<Tag>? Tags { get; set; }

        public void AddTag(Tag tag)
        {
            if (Tags == null)
                Tags = new List<Tag>();

            Tags.Add(tag);
        }
    }
}
