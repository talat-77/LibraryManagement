using AutoMapper;
using FluentValidation;
using LibraryManagement.Application.DTO.BookDtos;
using LibraryManagement.Application.Repository;
using LibraryManagement.Application.Repository.BookRepository;
using LibraryManagement.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookWriteRepository _bookWriteRepository;

        private readonly IBookReadRepository _bookReadRepository;
        private readonly IMapper _mapper;
        IValidator<UpdateBookDto> _updateValidator;
        IValidator<CreateBookDto> _createValidator;


        public BookController(IBookWriteRepository bookWriteRepository, IBookReadRepository bookReadRepository, IMapper mapper, IValidator<UpdateBookDto> updateValidator, IValidator<CreateBookDto> createValidator)
        {
            _bookWriteRepository = bookWriteRepository;
            _bookReadRepository = bookReadRepository;
            _mapper = mapper;
            _updateValidator = updateValidator;
            _createValidator = createValidator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _bookReadRepository.GetByIdAsync(id, false);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBook()
        {
            var query = _bookReadRepository.GetAll(false);
            var result = await query.ToListAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookDto dto)
        {
            var validationResult = await _createValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var book = _mapper.Map<Book>(dto);
            await _bookWriteRepository.AddAsync(book);
            return Ok(book);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _bookWriteRepository.RemoveAsync(id);
            if (!result)
                return BadRequest("Kitap silinemedi.");
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, UpdateBookDto dto)
        {
            var validationResult = await _updateValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var book = await _bookReadRepository.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound($"Book with ID {id} not found.");
            }
            _mapper.Map(dto, book); 
            await _bookWriteRepository.UpdateAsync(book);
            return Ok(book);
        }


    }
}
