using BookSearchLibrary;
using BookSearchLibrary.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSearchUI.ViewModels
{
    public class MainSearchViewModel : Screen
    {
        private readonly SQLiteHelper _helper;

        private ObservableCollection<Book> _searchResults;

        public ObservableCollection<Book> SearchResults
        {
            get { return _searchResults; }
            set
            {
                _searchResults = value;
                NotifyOfPropertyChange(() => SearchResults);
            }
        }

        public MainSearchViewModel(SQLiteHelper helper)
        {
            _helper = helper;
            Initialize();
        }

        private async void Initialize()
        {
            SearchResults = await _helper.GetAllBooksAsync();
        }
    }
}
