using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RBA.Data.Repository.Interfaces
{
    public interface IResourceRepository
    {
        Task<int> GetResourceId(string resourceName);
    }
}
