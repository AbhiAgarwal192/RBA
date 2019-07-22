using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RBA.Data.Repository.Interfaces
{
    public interface IActionTypeRoleRepository
    {
        Task<List<string>> GetActionTypes(int roleId);
    }
}
