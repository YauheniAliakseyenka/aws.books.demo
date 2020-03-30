using Books.Application.DTO;
using System.Threading.Tasks;

namespace Books.Application.Contracts
{
    public interface IBookService
    {
        Task<Book> Get(string isbn);
    }
}
