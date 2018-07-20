using BookSearchLibrary.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSearchLibrary
{
    public class SQLiteHelper
    {
        private readonly string _cnnString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        /// <summary>
        /// Gets all books from the database.
        /// </summary>
        /// <returns>An observable collection of books.</returns>
        public async Task<ObservableCollection<Book>> GetAllBooksAsync()
        {
            using (IDbConnection cnn = new SQLiteConnection(_cnnString))
            {
                var output = await cnn.QueryAsync<Book>("SELECT * FROM Books;");

                return new ObservableCollection<Book>(output);
            }
        }

        /// <summary>
        /// Gets a certain book or books by doing a search.
        /// </summary>
        /// <param name="searchQuery">The keywords to search.</param>
        /// <param name="searchOption">Wether to match it by the title or author.</param>
        /// <returns>An observable collection of books.</returns>
        public async Task<ObservableCollection<Book>> GetBookAsync(string searchQuery, string searchOption)
        {
            using (IDbConnection cnn = new SQLiteConnection(_cnnString))
            {
                var output = await cnn.QueryAsync<Book>($"SELECT * FROM Books WHERE {searchOption} LIKE '%{searchQuery}%'");

                return new ObservableCollection<Book>(output);
            }
        }

        /// <summary>
        /// Saves a new book to the database.
        /// </summary>
        /// <param name="book">The book to save in the database.</param>
        public async Task SaveNewBook(Book book)
        {
            using (IDbConnection cnn = new SQLiteConnection(_cnnString))
            {
                await cnn.ExecuteAsync("INSERT INTO Books(Title, Author) VALUES (@Title, @Author);", book);
            }
        }
    }
}
