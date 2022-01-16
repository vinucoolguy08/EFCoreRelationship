using EFCoreRelationship.Models;
using System.Threading.Tasks;

namespace EFCoreRelationship.Data
{
    public interface IAuthRepository
    {
        public Task<ServiceResponse<int>> Register(User user, string password);

        public Task<ServiceResponse<string>> Login(string userName, string password);

        public Task<bool> UserExists(string userName);
    }
}
