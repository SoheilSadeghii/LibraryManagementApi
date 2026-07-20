using LibraryManagementApi.DTOs.Auth;
using LibraryManagementApi.Models;
using LibraryManagementApi.Repositories;
using LibraryManagementApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthController(IUserRepository userRepository, IJwtService jwtService, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
            _passwordHasher = passwordHasher;
        }
        
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(RegisterRequestDto registerRequestDto)
        {
            if (_userRepository.GetByUsername(registerRequestDto.Username) != null) 
                return BadRequest("Username already exists.");

            if (_userRepository.GetByEmail(registerRequestDto.Email) != null)
                return BadRequest("Email already exists.");

            var user = new User
            {
                Username = registerRequestDto.Username,
                Email = registerRequestDto.Email,
                Role = "User"
            };

            user.PasswordHash =
                _passwordHasher.HashPassword(user, registerRequestDto.Password);

            _userRepository.Create(user);

            return CreatedAtAction(
                nameof(Register),
                new { id = user.Id },
                null);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(LoginRequestDto loginRequestDto)
        {
            var user =
                _userRepository.GetByUsername(loginRequestDto.Username);

            if (user == null) return Unauthorized("Invalid username or password");

            var result =
                _passwordHasher.VerifyHashedPassword(
                    user,
                    user.PasswordHash,
                    loginRequestDto.Password);

            if (result == PasswordVerificationResult.Failed) return Unauthorized("Invalid username or password.");

            var token = _jwtService.GenerateToken(user);

            return Ok(new LoginResponseDto
            {
                Token = token
            });
        }
    }
}
