using AutoMapper;
using FluentValidation;
using LibraryManagement.Application.DTO.AuthorDtos;
using LibraryManagement.Application.DTO.BookDtos;
using LibraryManagement.Application.Repository.AuthorRepository;
using LibraryManagement.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorReadRepository _authorReadRepository;
        private readonly IAuthorWriteRepository _authorWriteRepository;
        IMapper _mapper;
        IValidator<CreateAuthorDto> _createValidator;
        IValidator<UpdateAuthorDto> _updateValidator;

        public AuthorController(IAuthorReadRepository authorReadRepository, IAuthorWriteRepository authorWriteRepository, IMapper mapper, IValidator<CreateAuthorDto> createValidator, IValidator<UpdateAuthorDto> updateValidator)
        {
            _authorReadRepository = authorReadRepository;
            _authorWriteRepository = authorWriteRepository;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var author = await _authorReadRepository.GetByIdAsync(id, false);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthor()
        {
            var query = _authorReadRepository.GetAll(false);
            var result = await query.ToListAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorDto dto)
        {
            var validationResult = await _createValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var author = _mapper.Map<Author>(dto);
            await _authorWriteRepository.AddAsync(author);
            return Ok(author);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] UpdateAuthorDto dto)
        {
            var author = await _authorReadRepository.GetByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            var validationResult = await _updateValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            _mapper.Map(author, dto); 
            await _authorWriteRepository.UpdateAsync(author);
            return Ok(author);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var result = await _authorWriteRepository.RemoveAsync(id);
            if (!result)
                return BadRequest("Bu yazara bağlı kitaplar olabilir.");
            return NoContent();
        }
    }
}
