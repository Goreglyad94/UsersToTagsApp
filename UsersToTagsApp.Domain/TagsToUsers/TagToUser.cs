using System.ComponentModel.DataAnnotations;
using UsersToTagsApp.Domain.Tags;
using UsersToTagsApp.Domain.Users;

namespace UsersToTagsApp.Domain.TagsToUsers
{
    public class TagToUser
    {
        [Key]
        public Guid EntityId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public User? User { get; set; }
        [Required]
        public Guid TagId { get; set; }
        public Tag? Tag { get; set; }
    }
}
