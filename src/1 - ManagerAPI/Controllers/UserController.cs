using AutoMapper;
using Manager.Core.Exceptions;
using Manager.Services.DTO;
using Manager.Services.Interfaces;
using ManagerAPI.ViewModels;
using ManagerAPI.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace ManagerAPI.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/api/v1/users/getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var allUsers = await _userService.GetAll();

                return Ok(new ResultViewModel
                {
                    Message = "Successfully",
                    Success = true,
                    Data = allUsers
                });
            }
            catch (DomainExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("/api/v1/users/getById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var usersById = await _userService.Get(id);

                return Ok(new ResultViewModel
                {
                    Message = "Successfully",
                    Success = true,
                    Data = usersById
                });
            }
            catch (DomainExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("/api/v1/users/create")]
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel userViewModel)
        {
            try
            {
                var userDTO = _mapper.Map<UserDTO>(userViewModel);
                var userCreated = await _userService.Create(userDTO);

                return Ok(new ResultViewModel
                {
                    Message = "User created successfully",
                    Success = true,
                    Data = userCreated
                });
            }
            catch (DomainExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("/api/v1/users/update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserViewModel userViewModel)
        {
            try
            {
                var userDTO = _mapper.Map<UserDTO>(userViewModel);
                var userUpdated = await _userService.Update(userDTO);

                return Ok(new ResultViewModel
                {
                    Message = "User updated successfully",
                    Success = true,
                    Data = userUpdated
                });
            }
            catch (DomainExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("/api/v1/users/delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _userService.Remove(id);

                return Ok(new ResultViewModel
                {
                    Message = "User removed successfully",
                    Success = true,
                    Data = null
                });
            }
            catch (DomainExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("/api/v1/users/authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginUserViewModel authenticateUserViewModel)
        {
            try
            {
                var token = await _userService.AuthenticateAsync(authenticateUserViewModel.Email, authenticateUserViewModel.Password);

                return Ok(new ResultViewModel
                {
                    Message = "User authenticated successfully",
                    Success = true,
                    Data = token
                });
            }
            catch (DomainExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
