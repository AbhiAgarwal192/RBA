using RBA.Data.Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace RBA.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly RolesDbContext _rolesDbContext;
        public UserRepository(RolesDbContext rolesDbContext)
        {
            _rolesDbContext = rolesDbContext;
        }

        public async Task<int> GetUserId(string userName)
        {
            var userId = _rolesDbContext.User.FirstOrDefault(_user => string.Equals(userName, _user.Name)).Id;

            return userId;
        }
    }
}
