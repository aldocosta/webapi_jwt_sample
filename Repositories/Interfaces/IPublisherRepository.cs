using System.Collections.Generic;
using System.Threading.Tasks;
using codeFirsto.Models;

namespace codeFirsto.Repositories.Interfaces
{
    public interface IPublisherRepository
    {
         void Save(Publisher publisher);
         Task<List<Publisher>> getAll(int id);
    }
}