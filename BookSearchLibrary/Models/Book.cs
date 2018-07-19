using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSearchLibrary.Models
{
    /// <summary>
    /// A class that represents a book.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// The id of the book.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The title of the book.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The author of the book.
        /// </summary>
        public string Author { get; set; }
    }
}
