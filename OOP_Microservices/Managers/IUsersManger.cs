using OOP_Microservices.Data;

namespace OOP_Microservices.Managers
{
    public interface IUsersManger
    {
        Task<List<UserDto>> Get();
        Task<UserDto> GetById(int id);
        Task<UserDto> CreateUser(CreateUserRequest createUserRequest);
        Task<UserDto> UpdateUser(int id, UpdateUserRequest updateUserRequest);
        Task DeleteUser(int id);
    }
}
