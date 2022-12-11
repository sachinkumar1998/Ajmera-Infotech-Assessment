using Assessment.Models;
using Assessment.Repo;
using Assessment.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Services
{
    public class BookServices : IBookServices
    {
        private readonly BookContext _bookContext;
        public BookServices(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        //Get List of books


        //Add a book
        public async Task<int> AddBook(Book book)
        {
            try
            {
                book.Id = Guid.NewGuid().ToString();
                _bookContext.BookDbSet.Add(book);
                return await _bookContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Book GetBookById(string id)
        {
            return _bookContext.BookDbSet.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            try
            {
                var books = await _bookContext.BookDbSet.ToListAsync();
                return books;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
