using AutoMapper;
using Bookshelved.Core.DomainModels.Book;
using Bookshelved.Core.DTOs.Book;
using Bookshelved.Core.Interfaces.Repos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookshelved.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBookRepository _bookRepo;
        private readonly IMapper _mapper;

        public BookController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _bookRepo = (IBookRepository)_unitOfWork.GetRepository<Book>();
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var book = await _bookRepo.GetBookDetails(id);
                if (book == null)
                    return NotFound($"The requested resource {id} was not found.");

                var bookDTO = _mapper.Map<BookDetailsDTO>(book);
                return Ok(bookDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Something unexpected happened!");
            }
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}