using codeFirsto.Models;
using codeFirsto.Repositories.Interfaces;

namespace codeFirsto.Repositories
{
    public class BookRepository : IBookRepository
    {
        private BookStoreDBContext _context;
        public BookRepository(BookStoreDBContext context)
        {
            this._context = context;
        }
        public void Save(Book book)
        {            
            this._context.Books.Add(book);
        }
    }
}