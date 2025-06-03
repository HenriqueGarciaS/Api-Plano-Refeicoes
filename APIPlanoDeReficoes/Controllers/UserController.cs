using APIPlanoDeReficoes.Models;
using APIPlanoDeReficoes.Repositories;
using APIPlanoDeReficoes.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace APIPlanoDeReficoes.Controllers
{
    [ApiController]
    [Route ("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly TokenService _tokenService;

        public UserController(IUserRepository userRepository, TokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        [HttpPost("login", Name = "login")]
        public  async Task<ActionResult<string>> Login([FromBody] User user)
        {
            var userFromDatabase = await _userRepository.GetUser(user.Name, user.Password);
            var jwt = _tokenService.GenerateToken(userFromDatabase);
            return Ok(jwt);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] User user)
        {
            var userCreated = await _userRepository.Create(user);
            return Ok(userCreated);
        }
    }
}
