using LibraryManagementApi.DTOs.Auth;
using LibraryManagementApi.Models;
using LibraryManagementApi.Repositories;
using LibraryManagementApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public AuthController(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequestDto registerRequestDto)
        {
            var usernamerExists =
                _userRepository.GetByUsername(registerRequestDto.Username);

            if (usernamerExists != null) return BadRequest("Username already exists.");

            var emailExists =
                _userRepository.GetByEmail(registerRequestDto.Email);

            if (emailExists != null) return BadRequest("Email already exists.");

            var user = new User
            {
                Username = registerRequestDto.Username,
                Email = registerRequestDto.Email,
                Role = "User"
            };

            var passwordHasher = new PasswordHasher<User>();

            user.PasswordHash =
                passwordHasher.HashPassword(
                    user,
                    registerRequestDto.Password);

            _userRepository.Create(user);

            return CreatedAtAction(
                nameof(Register),
                new { id = user.Id },
                null);
        }
    }
}
