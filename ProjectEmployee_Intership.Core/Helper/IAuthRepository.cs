

using ProjectEmployee_Intership.Entities;
using ProjectEmployee_Intership.Models;

namespace ProjectEmployee_Intership.Core.Helper
{
 

        public interface IAuthRepository
        {
            Task<ServiceResponse<int>> Register(User user, string password);
            Task<ServiceResponse<string>> Login(string username, string password);
            Task<bool> UserExists(string username);
        }
    }

