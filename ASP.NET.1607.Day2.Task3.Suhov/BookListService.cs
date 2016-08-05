using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET._1607.Day2.Task3.Suhov
{
    public class BookListService: IBookList
    {
        #region Private Fields
        private static Logger log= LogManager.GetCurrentClassLogger();
        private List<Book> _bookList= new List<Book>();
        #endregion
        /// <summary>
        /// Default constructor, initialize variables with default values
        /// </summary>
        public BookListService() { }
        /// <summary>
        /// Constructor with parameters, initialize variables with the parameters value
        /// </summary>
        public BookListService(List<Book> books)
        {
            _bookList = books;
        }
        /// <summary>
        /// Books property, returns book list for readonly
        /// </summary>
        public List<Book> Books { get { return CopyBooks(); } }
        /// <summary>
        /// Add new Book into list
        /// </summary>
        public void AddBook(Book book)
        {
            if (_bookList.Contains(book))
            {
                log.Error($"The book is already added!");
                throw new InvalidBookException("The book is already added!");
            }
            _bookList.Add(book);
        }
        /// <summary>
        /// Removes book from list
        /// </summary>
        public void RemoveBook(Book book)
        {
            if (!_bookList.Contains(book))
            {
                log.Error($"The book is not exists in List!");
                throw new InvalidBookException("The book is not exists in List!");
            }
            _bookList.Remove(book);
        }
        /// <summary>
        /// Delegate for finding books
        /// </summary>
        public delegate bool FindBook(Book book, object criteria);
        /// <summary>
        /// Delegate for comparing books
        /// </summary>
        public delegate int CompareBooks(Book book1, Book book2);
        /// <summary>
        /// Find book with defined comparer
        /// </summary>
        public List<Book> FindByTag(FindBook Compare, object criteria)
        {
            var result = new List<Book>();
            _bookList.ForEach(delegate (Book book) {
                if (Compare(book, criteria)) result.Add(book);
            });
            return result;
        }
        /// <summary>
        /// Sort method with delegate parameter for sorting type
        /// </summary>
        public void Sort(CompareBooks Compare)
        {
            if (_bookList == null)
                throw new ArgumentNullException(nameof(_bookList));
            if (Compare == null)
                throw new ArgumentNullException(nameof(Compare));
            for (int i = _bookList.Count-1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (Compare(_bookList[j], _bookList[j+1]) > 0)
                    {
                        Book itemToSwap = _bookList[j];
                        _bookList[j] = _bookList[j + 1];
                        _bookList[j + 1] = itemToSwap;
                    }
                }
            }
        }
        /// <summary>
        /// Static method for finding delegate by author
        /// </summary>
        public static bool FindByAuthor(Book book, object criteria)
        {
            if(criteria==null) throw new ArgumentNullException(nameof(criteria));
            if (!(criteria is string)) throw new ArgumentException("The argument has incorrect type");
            return book.Author==criteria as string;
        }
        /// <summary>
        /// Static method for finding delegate by bookName
        /// </summary>
        public static bool FindByBookName(Book book, object criteria)
        {
            if (criteria == null) throw new ArgumentNullException(nameof(criteria));
            if (!(criteria is string)) throw new ArgumentException("The argument has incorrect type");
            return book.BookName == criteria as string;
        }
        /// <summary>
        /// Static method for finding delegate by PageNums
        /// </summary>
        public static bool FindByPageNums(Book book, object criteria)
        {
            if (criteria == null) throw new ArgumentNullException(nameof(criteria));
            if (!(criteria is int)) throw new ArgumentException("The argument has incorrect type");
            return book.PagesCount == (int)criteria;
        }
        /// <summary>
        /// Static method for sorting delegate by author
        /// </summary>
        public static int CompareByAuthor(Book book1, Book book2)
        {
            return String.Compare(book1.Author, book2.Author);
        }
        /// <summary>
        /// Static method for sorting delegate by bookName
        /// </summary>
        public static int CompareByBookName(Book book1, Book book2)
        {
            return String.Compare(book1.BookName, book2.BookName);
        }
        /// <summary>
        /// Static method for sorting delegate by pageNums
        /// </summary>
        public static int CompareByPageNums(Book book1, Book book2)
        {
            if (book1.PagesCount > book2.PagesCount)
                return 1;
            else
                if (book1.PagesCount == book2.PagesCount)
                return 0;
            else
                return -1;
        }
        #region Private Methods
        private List<Book> CopyBooks()
        {
            var result = new List<Book>();
            _bookList.ForEach(delegate (Book book) {
                result.Add(book);
            });
            return result;
        }
        #endregion
    }
}
