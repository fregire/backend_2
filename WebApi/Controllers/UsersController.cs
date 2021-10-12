using System;
using System.Security.Policy;
using AutoMapper;
using Game.Domain;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        IUserRepository userRepository;

        IMapper mapper;
        // Чтобы ASP.NET положил что-то в userRepository требуется конфигурация
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        [Produces("application/json", "application/xml")]
        [HttpGet("{userId}")]
        public ActionResult<UserDto> GetUserById([FromRoute] Guid userId)
        {
            var user = userRepository.FindById(userId);
            var res = mapper.Map<UserEntity, UserDto>(user);
            
            return Ok(res);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] NewUserDto user)
        {

            return Ok();
        }
    }
}