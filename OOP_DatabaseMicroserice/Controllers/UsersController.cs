using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OOP_Microservices.Data;
using OOP_Microservices.Managers;

namespace OOP_DatabaseMicroserice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersManger _usersManger;
       
        public UsersController(IUsersManger usersManger)
        {
            _usersManger = usersManger;
        }

        [HttpGet]
        public async  Task<List<UserDto>> GetUsers()
        {
            return await _usersManger.Get();
        }        

        [HttpGet("{Id:int}")]
        public async Task<UserDto> GetUserById(int Id)
        {
            return await _usersManger.GetById(Id);
        }

        [HttpPost]
        public async Task<UserDto> CreateUser([FromBody] CreateUserRequest request)
        {
            return await _usersManger.CreateUser(request);
        }

        [HttpPut("{Id:int}")]
        public async Task<UserDto> UpdateUser(int Id, [FromBody] UpdateUserRequest request)
        {
            return await _usersManger.UpdateUser(Id, request);
        }
    }
}
