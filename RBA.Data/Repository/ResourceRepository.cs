using RBA.Data.Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace RBA.Data.Repository
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly RolesDbContext _rolesDbContext;
        public ResourceRepository(RolesDbContext rolesDbContext)
        {
            _rolesDbContext = rolesDbContext;
        }

        public async Task<int> GetResourceId(string resourceName)
        {
           var resourceId =  _rolesDbContext.Resource.FirstOrDefault(_resource => string.Equals(_resource.Name, resourceName)).Id;

           return resourceId;
        }
    }
}
