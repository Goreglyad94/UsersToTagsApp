using UsersToTagsApp.Domain.Tags;

namespace UsersToTagsApp.Test.Infrastructure.Builders
{
    public interface ITagBuilder
    {
        public Tag CreateTag(string value, string domain);
    }


    public class TagBuilder : ITagBuilder
    {
        public Tag CreateTag(string value, string domain)
        {
            return new Tag(Guid.NewGuid(), value, domain);
        }
    }
}
