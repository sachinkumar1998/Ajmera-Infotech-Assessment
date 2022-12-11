using Assessment.Models;
using Assessment.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly IBookServices _iBookService;
        public BooksController(IBookServices iBookService)
        {
            try
            {
                _iBookService = iBookService;
            }
            catch(Exception ex) 
            {
                throw ex.InnerException;
            }
        }

        [HttpGet("GetBooks")]
        public async Task<List<Book>> GetBooks()
        {
            try
            {
                var books = await _iBookService.GetBooksAsync();
                return books;
            }
            catch(Exception ex)
            {
                throw ex.InnerException;
            }
        }

        [HttpGet("GetBook")]

        public Book GetBook(string id)
        {
            try
            {
                var book = _iBookService.GetBookById(id);
                return book;
            }
            catch(Exception ex)
            {
                throw ex.InnerException;
            }
        }

        [HttpPost("AddBook")]
        public async Task<string> AddBook([FromBody] Book book)
        {
            try
            {
                await _iBookService.AddBook(book);
                return "Book has been added to the database with id : " + book.Id ;
            }
            catch(Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
