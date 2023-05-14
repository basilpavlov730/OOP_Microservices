using Microsoft.AspNetCore.Mvc;
using OOP_Microservices.Data;
using OOP_Microservices.Managers;

namespace OOP_Microservices.Controllers
{
    // Аттрибут, задающий путь, по которому будут доступны методы данного контроллера
    // http://localhost:5000/api/Users 
    // Порт, на котором запускается приложение определяется в launchSettings (в соответствующей секции)
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersManger _usersManger;

        // Параметр IUsersManger будет передан из DI Container (см. Program.cs)
        public UsersController(IUsersManger usersManger)
        {
            _usersManger = usersManger;
        }

        // Аттрибут, задающий тип HTTP запроса. Метод Get используется для получения данных из контроллера
        // В данном случае мы не передаем никаких значений в метод и выбраны будут все пользователи
        [HttpGet]
        public async Task<List<UserDto>> GetUsers()
        {
            return await _usersManger.Get();
        }

        // Мы можем определить конкретный идентификатор пользователя, который будет передан в контроллер
        // Параметр передается в адресной строке [FromQuery] (необязательный аттрибут)
        // http://localhost:5000/api/Users/1 <= 1 будет передана в метод

        [HttpGet("{Id:int}")]
        public async Task<UserDto> GetUserById(int Id)
        {
            return await _usersManger.GetById(Id);
        }

        // Метод Post используется для создания сущностей
        // Передавать параметры в метод можно через тело запроса [FromBody] (просто так в браузере не получится вызвать метод Post и передать в теле запрос (Request). Для этого можно использовать дополнительные инструменты Swagger или PostMan)
        [HttpPost]
        public async Task<UserDto> CreateUser([FromBody] CreateUserRequest request)
        {
            return await _usersManger.CreateUser(request);
        }

        // Метод Put используется для обновления сущностей
        // Мы можем объединять передачу параметров в адресной строке [FromQuery] и в теле запроса [FromBody]
        [HttpPut("{Id:int}")]
        public async Task<UserDto> UpdateUser(int Id, [FromBody] UpdateUserRequest request)
        {
            return await _usersManger.UpdateUser(Id, request);
        }

    }
}
