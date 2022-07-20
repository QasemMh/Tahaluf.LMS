using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.LMS.Core.Data;
using Tahaluf.LMS.Core.DTO;
using Tahaluf.LMS.Core.Repository;
using Tahaluf.LMS.Core.Service;

namespace Tahaluf.LMS.Infra.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        
        public bool Create(Book book)
        {
            return _bookRepository.Create(book);
        } 

        public bool Delete(int id)
        {
            return _bookRepository.Delete(id);
        }

        public List<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public Book GetBookByDate(DateTime publishDate)
        {
            return _bookRepository.GetBookByDate(publishDate);
        }

        public Book GetBookById(int id)
        {
            return _bookRepository.GetBookById(id);
        }

        public List<Book> SearchBook(BookSearchDTO bookDto)
        {
            return _bookRepository.SearchBook(bookDto);
        }

        public bool Update(Book book)
        {
            return _bookRepository.Update(book);
        }
    }
}
