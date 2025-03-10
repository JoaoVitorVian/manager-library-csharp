using Manager.Domain.Entities;

namespace Manager.Infra.Interfaces
{
    public interface ILibraryRepository : IBaseRepository<Book>
    {
        Task<List<Book>> SearchByBooks(string books);

        Task<List<Book>> SearchBySerial(long serial);
    }
}