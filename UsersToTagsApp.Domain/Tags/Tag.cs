using System.ComponentModel.DataAnnotations;
using UsersToTagsApp.Domain.TagsToUsers;
using UsersToTagsApp.Domain.Users;

namespace UsersToTagsApp.Domain.Tags
{
    public class Tag
    {
        public Tag() { }

        public Tag(Guid tagId, string value, string domain)
        {
            TagId = tagId;
            Value = value;
            Domain = domain;
        }

        public Guid TagId { get; set; }
        [Required]
        public string Value { get; set; } = default!;
        [Required]
        public string Domain { get; set; } = default!;
        public List<TagToUser>? TagToUsers { get; set; }
        public List<User>? Users { get; set; }
    }
}
