using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using MediaDataAccess;
using MediaDataObjects;
using MediaLogicLayer;

namespace Final_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Sends the user's query off to the MediaSearch method in the MediaAPI class
        /// to scrape search results for the user. It then adds that to the ListBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            dgMediaResults.HeadersVisibility = DataGridHeadersVisibility.Column;
            this.dgMediaResults.Items.Clear(); // clears out the Search Results so future searches aren't piling ontop of eachother.
            MediaDataAccessor.ClearMediaList(0);    // Clears the default array in the MediaDataAccessor.
            this.dgMediaResults.Items.Clear();    // We pass 0 to specify the regular array, not the favorites.
            MediaAPI test = new MediaAPI();
            try
            {
                int count = test.GetNumOfSearchResults(this.txtSearchBox.Text);
                this.lblResults.Content = "Loading " + count + " Results...";
                // goes through once to get the amount of results to be
                for (int i = 0; i < count; i++)                                         // looped through
                {
                    Object t = test.MediaSearch(txtSearchBox.Text)[i];
                    if (t is Movie)
                    {
                        Movie movie = (Movie)t;
                        dgMediaResults.Items.Add(movie);
                        
                    }
                    else if (t is TVShow)
                    {
                        TVShow tv = (TVShow)t;
                        dgMediaResults.Items.Add(tv);
                    }
                    else if (t is Actor)
                    {
                        Actor actor = (Actor)t;
                        dgMediaResults.Items.Add(actor);
                    }                                                                                // User friendly loading text while it pulls results.
                }
                if (this.dgMediaResults.Items.Count > 0) // check to see if there's any results, otherwise
                {                                                   // we set the no results found below.
                    this.lblResults.Content = "Loaded: " + count + " Results";
                    //this.cbSortOptions.Enabled = true; // if we have results, then we enable the sort options for them.
                }
                else
                {
                    this.lblResults.Content = "No Results Found.";
                }
            }
            catch (Exception ex)
            { // this catches Exception when the exceptions that occur when there's no active internet connection. 
                if (ex is HttpRequestException || ex is WebException || ex is AggregateException)
                {     // when searching or opening a result.
                    MessageBox.Show("Search Functionality Requires An Active Internet Connection.", "No Internet Connection");
                }
            }

        }

        /// <summary>
        /// Calls the Search Function when the user Returns.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return && txtSearchBox.Text.Length != 0)        // if the key they press is enter, then it activates the Search, so they don't
            {                                                       // have to drag the mouse and click it.
                lblResults.Visibility = Visibility.Visible;
                BtnSearch_Click(this, new EventArgs());
            }
        }

        /// <summary>
        /// What executes when an item within the DataGrid is doubleclicked on.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgMediaResults_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow dataGrid = (DataGridRow)sender;
            sender = dataGrid.Item;
            MediaAPI mediaAPI = new MediaAPI();
            try
            {
                if (sender is Movie) // checks for [MOVIE] and
                {                                                                   // then creates a movie object with the item
                                                                                    // then passes it to ScrapeMetaData(), and the result of that
                    Movie movie = (Movie)sender;     // method gets sent to the MediaResultsForm.
                    MediaMovieResultPage mediaResultsForm = new MediaMovieResultPage(mediaAPI.ScrapeMetaData(movie, movie.MovieId));
                    mediaResultsForm.Show(); // shows the results form to the user.
                }
                else if (sender is TVShow) // same as above, but for the TV Object.
                {
                    TVShow tv = (TVShow)sender;
                    MediaMovieResultPage mediaResultsForm = new MediaMovieResultPage(mediaAPI.ScrapeMetaData(tv, tv.Id));
                    mediaResultsForm.Show();
                }
                else if (sender is Actor)
                {
                    Actor actor = (Actor)sender;
                    MediaMovieResultPage mediaResultsForm = new MediaMovieResultPage(actor);
                    mediaResultsForm.Show();
                }
            }
            catch (Exception ex) // catches Exception if the no internet exceptions get thrown.
            {
                if (ex is HttpRequestException || ex is WebException || ex is AggregateException)
                {
                    MessageBox.Show("Results Functionality Requires An Active Internet Connection.", "No Internet Connection");
                }
                if (ex is NullReferenceException)
                { // catches a NullReferenceException when the user tries to double click randomly
                }                                   // on the results list, but no result is selected and the area they're double clicking
            }                                       // is empty.
        }

        /// <summary>
        /// Opens the About Page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuAbout_Click(object sender, RoutedEventArgs e)
        {
            MediaAboutPage media = new MediaAboutPage();
            media.Show();
        }

        /// <summary>
        /// Replaces the window list with favorites.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowFavorites_Click(object sender, RoutedEventArgs e)
        {
            if (MediaDataAccessor.RetrieveMediaList(1) == null || MediaDataAccessor.RetrieveMediaList(1).Count <= 0) // Checks if the favorites list
            {                                                                                                        // has anything.
                MessageBox.Show("There Are No Items In Your Favorite List.", "Empty Favorites List");
            }
            else
            {
                MediaDataAccessor.ClearMediaList(0); // Clears the default media results list, incase the user clicks Show Favorites
                this.dgMediaResults.Items.Clear();    // when they already have regular results.
                List<Object> _usersFavorites = MediaDataAccessor.RetrieveMediaList(1); // Retrives the user's favorites list and assigns it
                int count = _usersFavorites.Count;           //  to a new object list to be looped through here.
                for (int i = 0; i < count; i++)         // loops through the list and adds them to the listbox.
                {
                    this.dgMediaResults.Items.Add(_usersFavorites[i]);
                    this.lblResults.Content = "Loading " + count + " Results..."; // flavor text for the user.
                }
                this.lblResults.Content = "Loaded: " + count + " Results"; // flavor text for the user.
            }
        }
    }
}
