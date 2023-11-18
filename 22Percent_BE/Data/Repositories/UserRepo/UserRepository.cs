using _22Percent_BE.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace _22Percent_BE.Data.Repositories.UserRepo
{
    public class UserRepository : IUserRepository
    {
        private _22Context _context;

        public UserRepository(_22Context context) 
        {
            _context = context; 
        }

        public async Task<string?> CreateUser(User user)
        {
            var result = await _context.Users.SingleOrDefaultAsync(e => e.Id == user.Id); 
            if (result == null) 
            {
                _context.Users.Add(user); 
                await _context.SaveChangesAsync();
                return null;
            }
            return Message.UserExisted;
        }

        public async Task<User?> GetUserById(string id)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Id == id);  
        }

        public Task<User?> GetUserByUserNameAndPassword(string userName, string password)
        {
            return _context.Users.SingleOrDefaultAsync(e=> (e.Id==userName) && (e.Password==password));
        }
    }
}
