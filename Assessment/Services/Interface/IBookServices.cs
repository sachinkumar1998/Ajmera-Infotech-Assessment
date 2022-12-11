using System.Collections.Generic;
using System.Threading.Tasks;
using Assessment.Models;

namespace Assessment.Services.Interface
{
    public interface IBookServices
    {
        Book GetBookById(string id);
        Task<List<Book>> GetBooksAsync();
        Task<int> AddBook(Book book);

    }
}
