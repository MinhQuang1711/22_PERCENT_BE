using _22Percent_BE.Data.Entities;

namespace _22Percent_BE.Data.Repositories.UserRepo
{
    public interface IUserRepository
    {
     
        public Task<User?> GetUserById(string id);

        public Task<string?> CreateUser(User user);

        public Task<User?> GetUserByUserNameAndPassword(string userName, string password);
    }
}
