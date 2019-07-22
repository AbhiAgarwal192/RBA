using RBA.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBA.Data.Repository
{
    public class ResourceRoleMappingRepository : IResourceRoleMappingRepository
    {
        private readonly RolesDbContext _rolesDbContext;

        public ResourceRoleMappingRepository(RolesDbContext rolesDbContext)
        {
            _rolesDbContext = rolesDbContext;   
        }

        public async Task<List<int>> GetRoles(string resourceName)
        {
            return _rolesDbContext.ResourceRoleMapping.Where(_mapping => string.Equals(_mapping.Resource.Name, resourceName)).Select(_res => _res.RoleId).ToList();
        }
    }
}
