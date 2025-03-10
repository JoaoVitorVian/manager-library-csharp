using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;
using Manager.Infra.Context;

namespace Manager.Infra.Repositories
{
    public class LibraryRepository : BaseRepository<Book>, ILibraryRepository
    {
        private readonly ManagerContext _context;

        public LibraryRepository(ManagerContext context) : base(context)
        {
          _context = context;
        }

        public async Task<List<Book>> SearchByBooks(string books)
        {
                var allBooks = await _context.Librarys
                                             .Where(
                                              x => x.BookName.ToLower().Contains(books.ToLower()))
                                             .AsNoTracking()
                                             .ToListAsync();
                                     
                return allBooks;
        }

        public async Task<List<Book>> SearchBySerial(long serial)
        {
            var allBooks = await _context.Librarys
                                         .Where(x => x.BookCodeSerial == serial)
                                         .AsNoTracking()
                                         .ToListAsync();
                                        
            return allBooks;
        }
    }
}