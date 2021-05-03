using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using codeFirsto.Models;
using codeFirsto.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace codeFirsto.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private BookStoreDBContext _context;
        public PublisherRepository(BookStoreDBContext context)
        {
            _context = context;
        }

        public async Task<List<Publisher>> getAll(int id)
        {
            return await this._context.Publishers.Where(p => p.PublisherId == id).ToListAsync();
        }

        public void Save(Publisher publisher)
        {
            this._context.Publishers.Add(publisher);
        }
    }
}