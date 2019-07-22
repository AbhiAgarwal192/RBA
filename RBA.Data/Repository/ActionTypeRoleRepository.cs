using RBA.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBA.Data.Repository
{
    public class ActionTypeRoleRepository : IActionTypeRoleRepository
    {
        private readonly RolesDbContext _rolesDbContext;
        public ActionTypeRoleRepository(RolesDbContext rolesDbContext)
        {
            _rolesDbContext = rolesDbContext;
        }

        public async Task<List<string>> GetActionTypes(int roleId)
        {
           return _rolesDbContext.ActionTypeRoleMapping.Where(_mapping => _mapping.RoleId == roleId).Select(_mapping => _mapping.ActionType.Name).ToList();
        }
    }
}
