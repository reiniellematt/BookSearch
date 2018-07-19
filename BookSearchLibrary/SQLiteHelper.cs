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

        public async Task<ObservableCollection<Book>> GetAllBooksAsync()
        {
            using (IDbConnection cnn = new SQLiteConnection(_cnnString))
            {
                var output = await cnn.QueryAsync<Book>("SELECT * FROM Books;");

                return new ObservableCollection<Book>(output);
            }
        }
    }
}
