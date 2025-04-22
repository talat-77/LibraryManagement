using AutoMapper;
using LibraryManagement.Application.DTO.BookDtos;
using LibraryManagement.Application.Repository;
using LibraryManagement.Application.Repository.BookRepository;
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

        public BookController(IBookWriteRepository bookWriteRepository, IBookReadRepository bookReadRepository, IMapper mapper)
        {
            _bookWriteRepository = bookWriteRepository;
            _bookReadRepository = bookReadRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
        var book = await _bookReadRepository.GetByIdAsync(id,false);
            if(book == null)
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
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);  
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookDto dto)
        {
            await _bookWriteRepository.AddAsync(dto)
        }
    }
}
