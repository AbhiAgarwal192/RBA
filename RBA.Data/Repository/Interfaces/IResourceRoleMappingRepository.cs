using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RBA.Data.Repository.Interfaces
{
    public interface IResourceRoleMappingRepository
    {
        Task<List<int>> GetRoles(string resourceName);
    }
}
