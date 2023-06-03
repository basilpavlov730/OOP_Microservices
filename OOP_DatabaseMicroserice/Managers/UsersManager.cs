using Microsoft.EntityFrameworkCore;
using OOP_DatabaseMicroserice.DataBase;
using OOP_Microservices.Data;

namespace OOP_Microservices.Managers
{
    public class UsersManager : IUsersManger
    {
        private readonly UsersContext _dbContext;
        public UsersManager(UsersContext dbContext)
        {
            _dbContext = dbContext; 
        }
        public async Task<List<UserDto>> Get()
        {
            var users = await _dbContext.Users.ToListAsync();
            return users.Select(x => new UserDto { Id = x.Id, Name = x.UserName, Email = x.Email }).ToList();          
        }

        public async Task<UserDto> GetById(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                return new UserDto { Id = user.Id, Name = user.UserName, Email = user.Email };
            }
            else
                return null;
            
         }

        public async Task<UserDto> CreateUser(CreateUserRequest createUserRequest)
        {
            User newUser = new User { UserName = createUserRequest.UserName, Email = createUserRequest.Email, RegistrationDate = DateTime.Now };

            _dbContext.Users.Add(newUser);
            await _dbContext.SaveChangesAsync();

            return new UserDto { Name = newUser.UserName, Email = newUser.Email };
        }

        public async Task<UserDto> UpdateUser(int id, UpdateUserRequest updateUserRequest)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user != null)
            {
                user.UserName = updateUserRequest.UserName;
                user.Email = updateUserRequest.Email;

                await _dbContext.SaveChangesAsync();

                return new UserDto { Id = user.Id, Email = user.Email, Name = user.UserName };
            }
            else
            {
                return null;
            }
        }

        public async Task DeleteUser(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.Users.Remove(user);

            await _dbContext.SaveChangesAsync();
        }
    }
}
