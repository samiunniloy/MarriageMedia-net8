using API.Models;

namespace API.DataAccessLayer
{
    public interface IUserRepository
    {
        public Task<AddUserResponse> AddUser(AppUser request);
    }
}
