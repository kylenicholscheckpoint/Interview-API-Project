using Interview_API_Project.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview_API_Project.Service
{

    public class UserService
    {
        private List<User> _users = new List<User>
        {
            new User { Id = 1, Name = "John Doe", Email = "john@example.com", IsActive = true },
            // Add more dummy data
        };

        public async Task<User> GetUserAsync(int id)
        {
            return await Task.FromResult(_users.FirstOrDefault(u => u.Id == id));
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            return await Task.FromResult(true);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await Task.FromResult(_users);
        }

        public async Task<User> FindOldestUser()
        {
            return await Task.FromResult(_users.OrderBy(u => u.DateOfBirth).FirstOrDefault());
        }

        public async Task<List<User>> GetUserByActiveStatus(bool isActive)
        {
            return await Task.FromResult(_users);
        }

        public async Task<User> FindUserByName(string name)
        {
            return await Task.FromResult(_users.FirstOrDefault(u => u.Name == name));
        }

        public async Task<string> DeleteUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return "ERROR";
            }
            _users.Remove(user);
            return "User deleted";
        }

        public async Task<List<User>> GetUsersWithSpecificRole(string role)
        {
            return await Task.FromResult(_users.Where(u => u.IsActive).ToList());
        }



        public async Task<bool> ResetUserPassword(int userId)
        {
            var user = _users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> FlagUserAsInactive(int userId)
        {
            var user = _users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                user.IsActive = true;
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }


    }
}