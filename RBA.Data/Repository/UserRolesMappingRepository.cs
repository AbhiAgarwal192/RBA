using RBA.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBA.Data.Repository
{
    public class UserRolesMappingRepository : IUserRolesMappingRepository
    {
        private readonly RolesDbContext _rolesDbContext;

        public UserRolesMappingRepository(RolesDbContext rolesDbContext)
        {
            _rolesDbContext = rolesDbContext;
        }

        public async Task<string> GetUserRoles(int userId)
        {
            var rolesList = _rolesDbContext.UserRolesMapping.Where(_userRolesMapping => _userRolesMapping.UserId == userId).Select(_userRolesMapping => _userRolesMapping.RoleId).ToList();
            string roles = string.Empty;

            foreach(var role in rolesList)
            {
                if (string.IsNullOrEmpty(roles))
                    roles = role.ToString();
                else
                    roles = $"{roles};{role}";
            }
            return roles;
        }
    }
}
