using AutoMapper;
using Bookshelved.Core.DomainModels.Book;
using Bookshelved.Core.DTOs;
using Bookshelved.Core.Interfaces.Repos;
using Bookshelved.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelved.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork<BookshelfContext> _unitOfWork;
        private readonly IRepository<Book> _bookRepo;
        private readonly IMapper _mapper;

        public BookController(IUnitOfWork<BookshelfContext> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _bookRepo = _unitOfWork.GetRepository<Book>();
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
                var book = _bookRepo.GetByID(id);
                if (book == null)
                    return NotFound($"The requested resource {id} was not found.");

                var bookDTO = _mapper.Map<BookDTO>(book);
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