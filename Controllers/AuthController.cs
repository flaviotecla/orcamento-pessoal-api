using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using orcamento_pessoal_api.Models.Dto;

namespace orcamento_pessoal_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginRequest request)
        {
            var users = new List<LoginRequest>
            {
                new LoginRequest { UserName = "pedro", Password = "123456" },
                new LoginRequest { UserName = "sandro", Password = "123456" }
            };

            var user = users
                .FirstOrDefault(
                    u => u.UserName == request.UserName &&
                    u.Password == request.Password
                );

            if (user == null)
            {
                return Unauthorized(new { Message = "Invalid username or password" });
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var claimsIdentity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.Now.AddMinutes(30) // Set cookie expiration time
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties
            );

            var response = new LoginResponse
            {
                Message = "Login successful",
                UserName = user.UserName,
                ExpiresAt = DateTime.Now.AddMinutes(30) // Set expiration time for the response
            };

            return Ok(response);
        }
        
        [HttpPost("logout")]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok(new { Message = "Logged out successfully" });
        }
    }
}