using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.LMS.Core.Data;
using Tahaluf.LMS.Core.DTO;

namespace Tahaluf.LMS.Core.Service
{
    public interface IBookService
    {
        List<Book> GetAll();
        bool Create(Book book);
        bool Update(Book book);
        bool Delete(int id);
        Book GetBookById(int id);
        Book GetBookByDate(DateTime publishDate);
        List<Book> SearchBook(BookSearchDTO bookDto);

    }
}
