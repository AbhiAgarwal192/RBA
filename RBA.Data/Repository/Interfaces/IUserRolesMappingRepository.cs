using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RBA.Data.Repository.Interfaces
{
    public interface IUserRolesMappingRepository
    {
        Task<string> GetUserRoles(int userId);
    }
}
