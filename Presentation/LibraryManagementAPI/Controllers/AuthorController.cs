using AutoMapper;
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

        public AuthorController(IAuthorReadRepository authorReadRepository, IAuthorWriteRepository authorWriteRepository, IMapper mapper)
        {
            _authorReadRepository = authorReadRepository;
            _authorWriteRepository = authorWriteRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
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
            var author = _mapper.Map<Author>(dto);
            await _authorWriteRepository.AddAsync(author);
            return Ok(author);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorDto dto,string id)
        {
            var updated = await _authorReadRepository.GetByIdAsync(id);
            var newupdated = _mapper.Map<Author>(dto);
            _authorWriteRepository.Update(newupdated);
            return Ok(updated); 
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(string id)
        {
            var result = await _authorWriteRepository.RemoveAsync(id);
            if (!result)
                return BadRequest("Bu yazara bağlı kitaplar olabilir.");
            return NoContent();
        }
    }
}
