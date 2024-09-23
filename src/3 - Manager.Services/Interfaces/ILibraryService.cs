using Manager.Services.DTO;

namespace Manager.Services.Interfaces
{
    public interface ILibraryService
    {
        Task<LibraryDTO> Create(LibraryDTO libraryDTO);

        Task<LibraryDTO> Update(LibraryDTO libraryDTO);

        Task Remove(Guid id);

        Task<LibraryDTO> Get(Guid id);

        Task<List<LibraryDTO>> GetAll();

        Task<List<LibraryDTO>> SearchByBooks(string book);

        Task<List<LibraryDTO>> SearchBySerial( long code);
    }
}