using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ASP.NET._1607.Day2.Task3.Suhov.BookListService;

namespace ASP.NET._1607.Day2.Task3.Suhov
{
    interface IBookList
    {
        void AddBook(Book book);
        void RemoveBook(Book book);
        void Sort(CompareBooks Compare);
        List<Book> FindByTag(FindBook Compare, object criteria);
    }
}
