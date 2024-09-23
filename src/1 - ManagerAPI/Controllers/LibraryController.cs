using AutoMapper;
using Manager.Core.Exceptions;
using Manager.Services.DTO;
using Manager.Services.Interfaces;
using ManagerAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagerAPI.Controllers
{
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _libraryService;
        private readonly IMapper _mapper;

        public LibraryController(ILibraryService libraryService, IMapper mapper)
        {
            _libraryService = libraryService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/api/v1/library/getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var allBooks = await _libraryService.GetAll();

                return Ok(new ResultViewModel
                {
                    Message = "Successfully",
                    Success = true,
                    Data = allBooks
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
        [Route("/api/v1/library/getById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var booksById = await _libraryService.Get(id);

                return Ok(new ResultViewModel
                {
                    Message = "Successfully",
                    Success = true,
                    Data = booksById
                });
            }
            catch (DomainExceptions ex)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro");
            }
        }

        [HttpPost]
        [Authorize]
        [Route("/api/v1/library/create")]
        public async Task<IActionResult> Create([FromBody] CreateLibraryViewModel libraryViewModel)
        {
            try
            {
                var libraryDTO = _mapper.Map<LibraryDTO>(libraryViewModel);
                var libraryCreated = await _libraryService.Create(libraryDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Library created successfully",
                    Success = true,
                    Data = libraryCreated
                });
            }
            catch (DomainExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro");
            }
        }

        [HttpPut]
        [Authorize]
        [Route("/api/v1/library/update/{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateLibraryViewModel libraryViewModel)
        {
            try
            {
                if (id != libraryViewModel.Id)
                {
                    return BadRequest("ID mismatch");
                }

                var libraryDTO = _mapper.Map<LibraryDTO>(libraryViewModel);
                var libraryUpdated = await _libraryService.Update(libraryDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Library updated successfully",
                    Success = true,
                    Data = libraryUpdated
                });
            }
            catch (DomainExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro");
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("/api/v1/library/remove/{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            try
            {
                await _libraryService.Remove(id);
                return Ok(new ResultViewModel
                {
                    Message = "Library removed successfully",
                    Success = true,
                    Data = null
                });
            }
            catch (DomainExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro");
            }
        }
    }
}
