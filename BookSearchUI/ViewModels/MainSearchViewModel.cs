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

        private string _searchQuery;
        private string _searchOptionSelected;
        private string _numberOfBooksFound = string.Empty;
        private ObservableCollection<Book> _searchResults = new ObservableCollection<Book>();
        private ObservableCollection<string> _searchOptions = new ObservableCollection<string>();




        public string SearchQuery
        {
            get { return _searchQuery; }
            set
            {
                _searchQuery = value;
                NotifyOfPropertyChange(() => SearchQuery);
            }
        }
        public string SearchOptionSelected
        {
            get { return _searchOptionSelected; }
            set
            {
                _searchOptionSelected = value;
                NotifyOfPropertyChange(() => SearchOptionSelected);
            }
        }
        public string NumberOfBooksFound
        {
            get { return _numberOfBooksFound; }
            set
            {
                _numberOfBooksFound = value;
                NotifyOfPropertyChange(() => NumberOfBooksFound);
            }
        }
        public ObservableCollection<Book> SearchResults
        {
            get { return _searchResults; }
            set
            {
                _searchResults = value;
                NotifyOfPropertyChange(() => SearchResults);
            }
        }
        public ObservableCollection<string> SearchOptions
        {
            get { return _searchOptions; }
            set
            {
                _searchOptions = value;
                NotifyOfPropertyChange(() => SearchOptions);
            }
        }

        public MainSearchViewModel(SQLiteHelper helper)
        {
            _helper = helper;
            Initialize();
        }

        private void Initialize()
        {
            SearchOptions.Add("Title");
            SearchOptions.Add("Author");
            SearchOptionSelected = SearchOptions[0];
        }

        public bool CanSearch(string searchQuery)
        {
            return !string.IsNullOrWhiteSpace(searchQuery);
        }

        public async Task Search(string searchQuery)
        {
            SearchResults = await _helper.GetBookAsync(SearchQuery, SearchOptionSelected);
            NumberOfBooksFound = $"{ SearchResults.Count } Books Found";
        }
    }
}
