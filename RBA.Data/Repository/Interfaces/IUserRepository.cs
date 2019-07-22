using System.Threading.Tasks;

namespace RBA.Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<int> GetUserId(string userName);
    }
}
