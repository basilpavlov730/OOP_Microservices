using OOP_Microservices.Data;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace OOP_Microservices.Managers
{
    public class UsersManager : IUsersManger
    {
        private readonly HttpClient _httpClient;

        public UsersManager()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5001");
        }

        public async Task<List<UserDto>> Get()
        {
            return await _httpClient.GetFromJsonAsync<List<UserDto>>("/api/Users");
        }

        public async Task<UserDto> GetById(int id)
        {
            var result = await _httpClient.GetAsync($"/api/Users/{id}");


            return await result.Content.ReadFromJsonAsync<UserDto>() ;
        }

        public async Task<UserDto> CreateUser(CreateUserRequest createUserRequest)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/Users", createUserRequest);

            return await result.Content.ReadFromJsonAsync<UserDto>();
        }

        public async Task<UserDto> UpdateUser(int id, UpdateUserRequest updateUserRequest)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/Users/{id}", updateUserRequest);

            return await result.Content.ReadFromJsonAsync<UserDto>();
        }

        public async Task DeleteUser(int id)
        {
            await _httpClient.DeleteAsync($"/api/Users/{id}");
        }
    }
}
