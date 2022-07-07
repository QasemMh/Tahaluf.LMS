using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.LMS.Core.Data;

namespace Tahaluf.LMS.Core.Repository
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        bool Create(Book book);
        bool Update(Book book);
        bool Delete(int id);
        Book GetBookById(int id);
        Book GetBookByDate(DateTime publishDate);
    }
}
