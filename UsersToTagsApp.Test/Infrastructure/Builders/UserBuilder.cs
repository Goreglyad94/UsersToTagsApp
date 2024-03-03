using System.Security.AccessControl;
using UsersToTagsApp.Domain.Users;

namespace UsersToTagsApp.Test.Infrastructure.Builders
{
    public interface IUserBuilder
    {
        User CreateUser(Guid giudId,string name, string domain);
    }

    public class UserBuilder : IUserBuilder
    {
        public User CreateUser(Guid giudId, string name, string domain)
        {
            return new User(giudId, name, domain);
        }
    }
}
