using Microsoft.EntityFrameworkCore;
using UsersToTagsApp.Core.Context;
using UsersToTagsApp.Core.DataGateways.Extentions;
using UsersToTagsApp.Domain.Users;

namespace UsersToTagsApp.Core.DataGateways
{
    public interface IUserGateway
    {
        Task<User> GetById(Guid guid);
        Task<User> GetByIdAndDomain(Guid guid, string domain);
        Task<PagedList<User>?> GetByDomain(string domain, int page, int size);
        Task<List<User>?> GetForTag(string domain, string tag);
    }

    public class UserGateway : IUserGateway
    {
        private readonly UsersToTagsContext _usersToTagsContext;

        public UserGateway(UsersToTagsContext usersToTagsContext)
        {
            _usersToTagsContext = usersToTagsContext;
        }

        public async Task<User?> GetById(Guid guid)
        {
            return await _usersToTagsContext.Users
                .Where(x => x.UserId == guid)
                .Include(x => x.TagToUsers)
                .Include(x => x.Tags)
                .FirstOrDefaultAsync();
        }

        public async Task<User?> GetByIdAndDomain(Guid guid, string domain)
        {
            return await _usersToTagsContext.Users
                .Where(x => x.UserId == guid)
                .Where(x => x.Domain == domain)
                .Include(x => x.TagToUsers)
                .Include(x => x.Tags)
                .FirstOrDefaultAsync();
        }

        public async Task<PagedList<User>?> GetByDomain(string domain, int page, int size)
        {
            return await _usersToTagsContext.Users
                .Where(x => x.Domain == domain)
                .Include(x => x.Tags)
                .ToPagedListAsync(page, size);
        }

        public async Task<List<User>?> GetForTag(string domain, string tag)
        {
            return await _usersToTagsContext.Users
                .Where(x => x.Domain == domain)
                .Where(x => x.Tags.Any(t => t.Value == tag))
                .Include(x => x.Tags)
                .ToListAsync();
        }
    }
}
