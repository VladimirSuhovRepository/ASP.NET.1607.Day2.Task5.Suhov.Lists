using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET._1607.Day2.Task3.Suhov.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = new BookListService();
            books.AddBook(new Book(Author: "Ivanov", BookName: "IvanovBook", PagesCount: 321));
            books.AddBook(new Book(Author: "Suhov", BookName: "SuhovBook", PagesCount: 10000));
            try
            {
                books.AddBook(new Book(Author: "Suhov", BookName: "SuhovBook", PagesCount: 10000));
            }
            catch (InvalidBookException)
            {
                System.Console.WriteLine("Contains works fine-----");
            }
            books.AddBook(new Book(Author: "Petrov", BookName: "PetrovBook", PagesCount: 222));
            books.AddBook(new Book(Author: "Sidorov", BookName: "SidorovBook", PagesCount: 999));
            books.Books.ForEach(delegate(Book book) {
                System.Console.WriteLine(book.ToString());
            });
            System.Console.WriteLine("-------------------");
            books.RemoveBook(new Book(Author: "Ivanov", BookName: "IvanovBook", PagesCount: 321));
            books.Books.ForEach(delegate (Book book) {
                System.Console.WriteLine(book.ToString());
            });
            System.Console.WriteLine("Compare by author-------------------");
            books.Sort(BookListService.CompareByAuthor);
            books.Books.ForEach(delegate (Book book) {
                System.Console.WriteLine(book.ToString());
            });
            System.Console.WriteLine("Compare by Page Nums-------------------");
            books.Sort(BookListService.CompareByPageNums);
            books.Books.ForEach(delegate (Book book) {
                System.Console.WriteLine(book.ToString());
            });
            System.Console.WriteLine("Find by author-------------------");
            var booksFiltered=books.FindByTag(BookListService.FindByAuthor,"Suhov");
            booksFiltered.ForEach(delegate (Book book) {
                System.Console.WriteLine(book.ToString());
            });
            System.Console.ReadKey();
        }
    }
}
