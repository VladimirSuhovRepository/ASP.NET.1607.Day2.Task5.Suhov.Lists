using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET._1607.Day2.Task3.Suhov
{
    public class Book:IEquatable<Book>
    {
        #region Private Fields
        private readonly int _pagesCount;
        private readonly string _bookName;
        private readonly string _author;
        #endregion
        /// <summary>
        /// Public property returns authour of the book
        /// </summary> 
        public string Author { get { return _author; } }
        /// <summary>
        /// Public property returns name of the book
        /// </summary> 
        public string BookName { get { return _bookName; } }
        /// <summary>
        /// Public property returns pages count of the book
        /// </summary> 
        public int PagesCount { get { return _pagesCount; } }
        /// <summary>
        /// Default constructor without parameters
        /// </summary> 
        public Book() { }
        /// <summary>
        /// Constructor with parameters to initialize private fields
        /// </summary> 
        public Book(string Author, string BookName, int PagesCount)
        {
            _author = Author;
            _bookName = BookName;
            _pagesCount = PagesCount;
        }
        /// <summary>
        /// Returns hash code of the book instance
        /// </summary> 
        public override int GetHashCode()
        {
            return _pagesCount * _bookName.GetHashCode() * _author.GetHashCode();
        }
        /// <summary>
        /// Implements IEquatable interface
        /// </summary> 
        public bool Equals(Book obj)
        {
            // If parameter is null return false.
            if (obj == null) return false;
            // Return true if the fields match:
            return (_pagesCount == obj._pagesCount) && (_author == obj._author) && (_bookName == obj._bookName);

        }
        /// <summary>
        /// Returns test information about the book
        /// </summary> 
        public override string ToString()
        {
            return $"The book {_bookName} has author {_author} and pages count {_pagesCount}";
        }

    }
}

