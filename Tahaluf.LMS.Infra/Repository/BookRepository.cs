using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using Tahaluf.LMS.Core.Common;
using Tahaluf.LMS.Core.Data;
using Tahaluf.LMS.Core.DTO;
using Tahaluf.LMS.Core.Repository;

namespace Tahaluf.LMS.Infra.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly IDbContext _context;

        public BookRepository(IDbContext context)
        {
            _context = context;
        }

        public bool Create(Book book)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Name", book.Name, dbType: DbType.String);
            parameters.Add("@Price", book.Price, dbType: DbType.Double);
            parameters.Add("@PublishDate", book.PublishDate, dbType: DbType.Date);
            parameters.Add("@CourseId", book.CourseId, dbType: DbType.Int32);

            var result = _context.Connection
                  .ExecuteAsync("Book_Package.CreateBook",
                                parameters, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool Update(Book book)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Name", book.Name, dbType: DbType.String);
            parameters.Add("@Price", book.Price, dbType: DbType.Double);
            parameters.Add("@PublishDate", book.PublishDate, dbType: DbType.Date);
            parameters.Add("@CourseId", book.CourseId, dbType: DbType.Int32);
            parameters.Add("@Id", book.Id, dbType: DbType.Int32);
            var result = _context.Connection
                .ExecuteAsync("Book_Package.UpdateBook",
                                parameters,
                                commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool Delete(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id, dbType: DbType.Int32);
            var result = _context.Connection
                .ExecuteAsync("Book_Package.DeleteBook",
                                parameters,
                                commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Book> GetAll()
        {
            var result = _context.Connection
               .QueryAsync<Book>("Book_Package.GetAllBooks",
                               commandType: CommandType.StoredProcedure);
            return result.Result.ToList();
        }

        public Book GetBookById(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id, dbType: DbType.Int32);
            var result = _context.Connection
                .QueryAsync<Book>("Book_Package.GetBookById",
                                parameters,
                                commandType: CommandType.StoredProcedure);
            return result.Result.FirstOrDefault();
        }

        public Book GetBookByDate(DateTime publishDate)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@PublishDate", publishDate, dbType: DbType.Date);
            var result = _context.Connection
                .QueryAsync<Book>("Book_Package.GetBookByDate",
                                parameters,
                                commandType: CommandType.StoredProcedure);
            return result.Result.FirstOrDefault();
        }


        public List<Book> SearchBook(BookSearchDTO bookDto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("bookName", bookDto.BookName, dbType: DbType.String);
            parameters.Add("courseName", bookDto.CourseName, dbType: DbType.String);
            parameters.Add("sDate", bookDto.StartDate, dbType: DbType.Date);
            parameters.Add("eDate", bookDto.EndDate, dbType: DbType.Date);
            var result = _context.Connection
              .QueryAsync<Book>("Book_Package.SearchBook",
                                parameters,
                                commandType: CommandType.StoredProcedure);
            return result.Result.ToList();
        }

    }
}
