using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MediaDataAccess;
using MediaDataObjects;

namespace Final_Project
{
    /// <summary>
    /// Interaction logic for MediaMovieResultPage.xaml
    /// </summary>
    public partial class MediaMovieResultPage : Window
    {
        /// <summary>
        /// Temporairily holds our trailerURL so it's accessible by our 
        /// BtnOpenTrailer_Click().
        /// </summary>
        public string tempURL;

        /// <summary>
        /// The current media object, static so it can be used in the BtnFavorite_Click() method.
        /// </summary>
        public static Object _currentObject = new Object();

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public MediaMovieResultPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Movie-Object Constructor
        /// </summary>
        /// <param name="movie"></param>
        public MediaMovieResultPage(Movie movie)
        {
            InitializeComponent();
            _currentObject = movie;
            string title = movie.Title; string releaseDate = Convert.ToDateTime(movie.ReleaseDate).Year.ToString();
            string titleBar = "WhereToWatch v2.0 Result: " + title + " (" + releaseDate + ")";
            string userScore = (movie.VoteAverage * 10).ToString() + "%";
            SetFormValuesAndText(movie.PosterPath, movie.Overview, movie.Title, "WhereToWatch v2.0 Result - " + movie.Title + " (" + 
                Convert.ToDateTime(movie.ReleaseDate).Year.ToString() + ")", movie.StreamOn, userScore, movie, 0,0, 
                Convert.ToDateTime(movie.ReleaseDate).Year.ToString()); // passes our variables to set them all.
            MovieNullCheck(movie);
            tbGenresContent.Text = GetGenresForMedia(movie);
        }

        /// <summary>
        /// TVShow-Object Constructor
        /// </summary>
        /// <param name="tvShow"></param>
        public MediaMovieResultPage(TVShow tvShow)
        {
            InitializeComponent();
            _currentObject = tvShow;
            string title = tvShow.Title; string releaseDate = Convert.ToDateTime(tvShow.FirstAirDate).Year.ToString();
            string titleBar = "WhereToWatch v2.0 Result: " + title + " (" + releaseDate + ")"; string userScore = (tvShow.VoteAverage * 10).ToString() + "%";
            SetFormValuesAndText(tvShow.PosterPath, tvShow.Overview, title, titleBar, tvShow.StreamOn, userScore, _currentObject, tvShow.NumberOfSeasons, tvShow.NumberOfEpisodes, releaseDate); // passes our variables to set them all.
            tbGenresContent.Text = GetGenresForMedia(_currentObject);
            tbStudiosContent.Text = GetCredits(tvShow);
            FormElementChecks(tvShow.Trailer, tvShow.StreamOnLogo, 0); // runs various checks on the items passed before setting them.
        }
        
        /// <summary>
        /// Actor-Object Constcutor
        /// </summary>
        /// <param name="actor"></param>
        public MediaMovieResultPage(Actor actor)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets all the form elements for both a Movie Object and a TV Object.
        /// </summary>
        /// <param name="Poster"></param>
        /// <param name="Summary"></param>
        /// <param name="Title"></param>
        /// <param name="TitleBar"></param>
        /// <param name="StreamOn"></param>
        private void SetFormValuesAndText(string Poster, string Summary, string Title, string TitleBar, string StreamOn, string UserScore, Object obj, int NumberOfSeasons = 0, int NumberOfEpisodes = 0, string releaseDate = "")
        {
            Uri uri = new Uri(Poster, UriKind.Absolute);
            ImageSource imgSource = new BitmapImage(uri);
            imgPosterArt.Source = imgSource;
            this.tbOverviewContent.Text = Summary;
            this.tbTitle.Text = Title;
            this.windowMediaResultPage.Title = TitleBar;
            this.tbStreamOnContent.Text = StreamOn;
            this.tbRanking.Text = UserScore;
            if (obj is Movie)
            {
                tbTypeContent.Text = "Movie";
                tbSeasonsTitle.Visibility = Visibility.Hidden;
                tbSeasonsContent.Visibility = Visibility.Hidden;
                tbEpisodesTitle.Visibility = Visibility.Hidden;
                tbEpisodesContent.Visibility = Visibility.Hidden;
                tbBroadcastContent.Visibility = Visibility.Hidden;
                tbBroadcastTitle.Visibility = Visibility.Hidden;
                this.rdSeasons.Height = new GridLength(0);
                this.rdEpisodes.Height = new GridLength(0);
                this.rdBroadcast.Height = new GridLength(0);
                tbReleaseDate.Text = releaseDate;
            }
            else if (obj is TVShow)
            {
                tbTypeContent.Text = "TV Show";
                tbSeasonsContent.Text = NumberOfSeasons.ToString();
                tbEpisodesContent.Text = NumberOfEpisodes.ToString();
                tbReleaseDate.Text = releaseDate;
            }
        }

        /// <summary>
        /// Loops our Genres Object contained within our Object and concatenates it.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static string GetGenresForMedia(Object obj)
        {
            StringBuilder genres = new StringBuilder();
            if (obj is Movie)
            {
                Movie movie = (Movie)obj;
                for (int i = 0; i < movie.Genres.Count; i++)
                {
                    if (i == movie.Genres.Count - 1)
                    {
                        genres.Append(movie.Genres[i].Name);
                    }
                    else
                    {
                        genres.Append(movie.Genres[i].Name + " | ");
                    }
                }
            }
            else if (obj is TVShow)
            {
                TVShow tvShow = (TVShow)obj;
                genres = new StringBuilder();
                for (int i = 0; i < tvShow.Genres.Count; i++)
                {
                    if (i == tvShow.Genres.Count - 1)
                    {
                        genres.Append(tvShow.Genres[i].Name);
                    }
                    else
                    {
                        genres.Append(tvShow.Genres[i].Name + " | ");
                    }
                }
            }
            return genres.ToString();
        }

        /// <summary>
        /// Checks if our Movie Object Runtime is null, then acts accordingly.
        /// </summary>
        /// <param name="movie"></param>
        private void MovieNullCheck(Movie movie)
        {
            if (movie.Runtime == null) // if the media doesn't have any runtime, we pass a 0, which is checked for and it disables  
            {                               // the visability of the Runtime as a result.
                FormElementChecks(movie.Trailer, movie.StreamOnLogo, 0, movie.Tagline);
            }
            else
            {
                FormElementChecks(movie.Trailer, movie.StreamOnLogo, (int)movie.Runtime, movie.Tagline);
            }
        }

        /// <summary>
        /// Loops our CreatedBy Object contained within our TVShow Object and concatenates it.
        /// </summary>
        /// <param name="tvShow"></param>
        /// <returns></returns>
        private static string GetCredits(TVShow tvShow)
        {
            StringBuilder createdBy = new StringBuilder();
            for (int i = 0; i < tvShow.CreatedBy.Count; i++)
            {
                if (i == tvShow.CreatedBy.Count - 1)
                {
                    createdBy.Append(tvShow.CreatedBy[i].Name);
                }
                else
                {
                    createdBy.Append(tvShow.CreatedBy[i].Name + " | ");
                }
            }
            return createdBy.ToString();
        }

        /// <summary>
        /// Runs our values through some null and value checks and sets values
        /// according to the results.
        /// </summary>
        /// <param name="TrailerURL"></param>
        /// <param name="StreamOnLogo"></param>
        /// <param name="Runtime"></param>
        /// <param name="Tagline"></param>
        private void FormElementChecks(string TrailerURL, string StreamOnLogo, int Runtime, string Tagline = null)
        {
            if (TrailerURL == null) // if there's no trailer because it's null, we set the text and disable the button.
            {
                this.btnTrailer.Content = "N/A";
            }
            else
            {
                tempURL = TrailerURL; // else allow the tempURL to become the trailerURL.
            }
            if (Tagline == null || Tagline == "") // if our tagline is null or empty, then we hide it and move the media title
            {                                     // slightly down. (TV Shows almost never have taglines, but movies usually do)
                //this.lblMediaTagline.Visible = false;
                //this.lblMediaTitle.Location = new Point(204, 18);
            }
            else
            {
                //this.lblMediaTagline.Text = Tagline;    // else set it.
            }
            if (Runtime == 0) // if our runtime is empty or null, we hide the runtime label.
            {
                this.tbRunTime.IsEnabled = false;
                this.tbRunTime.Visibility = Visibility.Hidden;
                this.rdLength.Height = new GridLength(0);
            }
            else
            {
                ConvertRuntime(Runtime);
            }
        }

        /// <summary>
        /// Converts our Runtime to a readable hours & minute format
        /// </summary>
        /// <param name="Runtime"></param>
        private void ConvertRuntime(int Runtime)
        {
            int hours = (Runtime / 60); // set the hours of runtime.
            int minutes = (Runtime - (60 * hours)); // sets our minutes of runtime.
            if (hours < 1) // if hours is <1, then we only use minutes.
            {
                this.tbRunTime.Text = minutes + "m";
            }
            else // else then we use both.
            {
                this.tbRunTime.Text = hours + "h" + " " + minutes + "m";
            }
        }

        /// <summary>
        /// Adds the piece of media to the user's favorites list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTrailer_Click(object sender, RoutedEventArgs e)
        {
            try{System.Diagnostics.Process.Start(tempURL); }                                              
            catch (Win32Exception w){Console.WriteLine(w.Message);}
            catch (InvalidOperationException ie){Console.WriteLine(ie.Message); MessageBox.Show("No Trailer Available!", "No Trailer");}
        }

        /// <summary>
        /// Adds the piece of media to the user's favorites list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddToFavorites_Click(object sender, RoutedEventArgs e)
        {
            MediaDataAccessor.AddMedia(_currentObject, 1);          // adds the object that was passed over to the results form, then assigned to _currentObject
            MessageBox.Show("Media added to favorites!", "Item Favorited");             // method to be written to an XML file.
            btnAddToFavorites.IsEnabled = false; // disables button after one use.
        }
    }
}
