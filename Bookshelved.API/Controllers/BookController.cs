using AutoMapper;
using Bookshelved.API.Filters;
using Bookshelved.API.Options;
using Bookshelved.Core.DomainModels.Book;
using Bookshelved.Core.DTOs;
using Bookshelved.Core.DTOs.Book;
using Bookshelved.Core.Interfaces.Repos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        //[HttpGet]
        //public async Task<IActionResult> Get(BookOptions bookOptions)
        //{
        //    try
        //    {
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            try
            {
                var book = _bookRepo.GetByID(id);
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

        /// <summary>
        /// Retrieves the full details about a book.
        /// </summary>
        /// <param name="id">The unique identifier of a book.</param>
        /// <returns>200 OK status with the book JSON.</returns>
        [HttpGet("{id}/Details")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetBookDetails(int id)
        {
            try
            {
                var book = await _bookRepo.GetBookDetails(id);
                if (book == null)
                    return NotFound($"The requested resource {id} was not found.");

                if (id <= 0)
                    return BadRequest($"Resource ID {id} was not acceptable.");

                var bookDTO = _mapper.Map<BookDetailsDTO>(book);
                return Ok(bookDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Something unexpected happened!");
            }
        }

        [HttpPost]
        [Validate]
        public async Task<IActionResult> AddBook([FromBody] BookDTO bookDTO)
        {
            try
            {
                // Author/series etc. will be selected from a dropdown, Store the ID from there. If they don't
                // exist, separate screen to create them.

                if (bookDTO == null)
                    return BadRequest("Please supply a non-null object.");

                // see for validation: https://docs.microsoft.com/en-us/aspnet/web-api/overview/formats-and-model-binding/model-validation-in-aspnet-web-api

                //if (!ModelState.IsValid)
                //    return BadRequest(ModelState.)

                var book = _mapper.Map<Book>(bookDTO);

                //_bookRepo.Get(o => o.AuthorID == 1, p => p.OrderBy)

                _bookRepo.Insert(book);
                await _unitOfWork.Save();

                return Ok(book.ID);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Something unexpected happened!");
            }
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