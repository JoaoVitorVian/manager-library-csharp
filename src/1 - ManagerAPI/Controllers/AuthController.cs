using AutoMapper;
using Manager.Core.Exceptions;
using Manager.Services.DTO;
using Manager.Services.Interfaces;
using ManagerAPI.ViewModels;
using ManagerAPI.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly IMapper _mapper;

        public AuthController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserViewModel loginUserViewModel)
        {
            try
            {
                var userDTO = _mapper.Map<UserDTO>(loginUserViewModel);
                var token = await _userService.AuthenticateAsync(userDTO.Email, userDTO.Password);
                return Ok(new { Token = token });
            }
            catch (DomainExceptions ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("secure-endpoint")]
        public IActionResult SecureEndpoint()
        {
            try
            {

                return Ok("Este é um endpoint protegido");
            }
            catch (DomainExceptions ex) {
                return Unauthorized(ex.Message);
            }
        }
    }
}
