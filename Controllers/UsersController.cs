using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using orcamento_pessoal_api.Models.Dto;
using orcamento_pessoal_api.Services.Interfaces;

namespace orcamento_pessoal_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create")]
        public IActionResult CreateUser(CreateUserRequest request)
        {
            _userService.CreateUser(request);
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult LoginUser(LoginUserRequest request)
        {
            var result = _userService.ValidateLogin(request);

            if (!result)
                return Unauthorized();

            return Ok();
        }
    }
}