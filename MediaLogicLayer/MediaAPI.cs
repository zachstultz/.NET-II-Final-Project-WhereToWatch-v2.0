using MediaDataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;
using System.Net;
using Newtonsoft.Json.Linq;
using HtmlAgilityPack;
using TMDbLib.Objects.TvShows;
using MediaDataAccess;
using TMDbLib.Objects.People;
using System.Text;

namespace MediaLogicLayer
{
    public class MediaAPI
    {
        private static readonly string APIKey = ""; // API Key for TheMovieDB
        TMDbClient client = new TMDbClient(APIKey); // TheMovieDB API Access Object.
        private static int currentItem = 0;
        private static int numOfSearchResults = 0;


        /// <summary>
        /// Scraps the inital listbox results. 
        /// This includes the name, id, and media type.
        /// </summary>
        /// <param name="input"></param>
        public List<Object> MediaSearch(string input)
        {
            SearchContainer<SearchBase> results = client.SearchMultiAsync(input).Result; // passes the user's query to a MultiAsyncSearch
            foreach (SearchBase result in results.Results) // loops through the results
            {
                string mediaType = result.MediaType.ToString().ToUpper(); // converts it to upper for the sake of style
                switch (mediaType)
                {
                    case "MOVIE":
                        TMDbLib.Objects.Movies.Movie movie = client.GetMovieAsync(result.Id).Result; // passes the movie ID gained from the SearchMultiAsync result
                                                                                                     //movie.
                        if (movie.ReleaseDate != null)                                              // and we pass it to GetMovieAsync methodt that pulls the items for the partial constructor.
                        {
                            MediaDataObjects.Movie movieObj = new MediaDataObjects.Movie(movie.Adult, movie.BackdropPath, movie.Genres, GetGenresInStringForm(movie.Genres), movie.Images, movie.ImdbId, movie.Keywords, movie.Id, movie.OriginalTitle, movie.Overview, movie.Popularity, movie.PosterPath, movie.ReleaseDate, "(" + Convert.ToDateTime(movie.ReleaseDate).Year.ToString() + ")", movie.Runtime, movie.Tagline, movie.Title, mediaType, movie.VoteAverage, movie.VoteCount);
                            MediaDataAccessor.AddMedia(movieObj, 0);//Adds the media object to the array in MediaDataAccessor.                                                     // with the results
                            currentItem++;
                        }
                        break;
                    case "TV":
                        TvShow tvShow = client.GetTvShowAsync(result.Id).Result;
                        if (tvShow.FirstAirDate != null)
                        {
                            TVShow tvShowObj = new TVShow(tvShow.BackdropPath, tvShow.FirstAirDate, tvShow.Genres, GetGenresInStringForm(tvShow.Genres), tvShow.Id, tvShow.Keywords, tvShow.Name, tvShow.Networks, tvShow.NumberOfEpisodes, tvShow.NumberOfSeasons, tvShow.OriginalName, tvShow.Overview, tvShow.Popularity, tvShow.PosterPath, "(" +Convert.ToDateTime(tvShow.FirstAirDate).Year.ToString() + ")", tvShow.Seasons, tvShow.Id, mediaType, tvShow.VoteAverage, tvShow.VoteCount);
                            MediaDataAccessor.AddMedia(tvShowObj, 0);
                            currentItem++;
                        }
                        break;
                    case "PERSON":
                        //else if (mediaType == "PERSON") {
                        //   Person person = client.GetPersonAsync(result.Id).Result;
                        //   if (person.Name != null) {
                        //      Actor actor = new Actor(1, person.Adult, person.AlsoKnownAs, person.Deathday, person.Gender, person.Id, person.Images, person.ImdbId, person.Name, person.Popularity, person.ProfilePath, person.TaggedImages);
                        //       MediaDataAccessor.AddMedia(actor, 0);
                        //         currentItem++;
                        //    }
                        //}
                        break;
                    default:
                        break;
                }
            }
            return MediaDataAccessor.RetrieveMediaList(0); // since we added the objects to the list over in MediaDataAccessor                                             // we retrieve that list and return it back to SearchResults, and again specifying 0 for the regular List, not favorites.
        }

        /// <summary>
        /// Gets the current count on where the loop is for the status on the MainWindow Interface.
        /// </summary>
        /// <returns></returns>
        public int GetCurrentItem() {
            return currentItem;
        }

        /// <summary>
        /// Returns the total number of restuls from the Media Search.
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfSearches() {
            return numOfSearchResults;
        }

        public string GetGenresInStringForm(List<Genre> genres) {
            StringBuilder build = new StringBuilder();
            for (int i = 0; i < genres.Count; i++)
            {
                if (i == genres.Count - 1)
                {
                    build.Append(genres[i].Name);
                }
                else
                {
                    build.Append(genres[i].Name + " , ");
                }
            }
            return build.ToString();
        }
    

        /// <summary>
        /// Sends the user's initial search off and returns the number of results found.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public int GetNumOfSearchResults(string input)
        {
            SearchContainer<SearchBase> results = client.SearchMultiAsync(input).Result;
             numOfSearchResults = results.Results.Count;
            return numOfSearchResults;
        }

            /// <summary>
            /// Scrapes the meta data for the Movie Object passed to it, creates a Movie Object with it, and returns it.
            /// </summary>
            /// <param name="passedMovie"></param>
            /// <param name="id"></param>
            /// <param name="mediaType"></param>
            /// <returns></returns>
            public MediaDataObjects.Movie ScrapeMetaData(MediaDataObjects.Movie passedMovie, int id)
        {
            TMDbLib.Objects.Movies.Movie movie = client.GetMovieAsync(id).Result; // we pass the id over to movie results to scrape all the meta information about the movie.
            string movieTrailerURL = TrailerKeyEmptyCheck(ScrapJsonPage(passedMovie, id, APIKey)); // This assigns the Scrapped JSON to the movie trailerURL, while also checking it for empty.
            string[] movieScrappedHtml = ScrapHtmlPage("https://www.themoviedb.org/movie/" + id); // holds the Scrapped html, being the service the movie is available on, and the logo for it.
            MediaDataObjects.Movie movieObj = new Movie(movie.AccountStates, movie.Adult, movie.AlternativeTitles, movie.BackdropPath, movie.BelongsToCollection, movie.Budget, movie.Changes, movie.Credits, movie.Genres, "", movie.Homepage, movie.Images, movie.ImdbId, movie.Keywords, movie.Lists, movie.Id, movie.OriginalLanguage, movie.OriginalTitle, movie.Overview, movie.Popularity, movie.PosterPath, movie.ProductionCompanies, movie.ProductionCountries, movie.Recommendations, movie.ReleaseDate, "(" + Convert.ToDateTime(movie.ReleaseDate).Year.ToString() + ")", movie.ReleaseDates, movie.Releases, movie.Revenue, movie.Reviews, movie.Runtime, movie.Similar, movie.SpokenLanguages, movie.Status, movieScrappedHtml[1], movieScrappedHtml[0], movie.Tagline, movie.Title, movieTrailerURL, "MOVIE", movie.Translations, movie.Video, movie.Videos, movie.VoteAverage, movie.VoteCount);
            return movieObj; // and return it back to the Search Form so the Search Form can pass it to the Results Form.
        }

        /// <summary>
        /// Scrapes the meta data for the TVShow Object passed to it, creates a TVShow Object with it, and returns it.
        /// </summary>
        /// <param name="passedTv"></param>
        /// <param name="id"></param>
        /// <param name="mediaType"></param>
        /// <returns></returns>
        public TVShow ScrapeMetaData(MediaDataObjects.TVShow passedTv, int id) // all the same as the movie object above, 
        {                                                                                       //just for tv object.
            TvShow tvShow = client.GetTvShowAsync(id).Result; // GetTVShowAsync instead of GetMovieAsync
            string tvTrailerURL = TrailerKeyEmptyCheck(ScrapJsonPage(passedTv, id, APIKey)); //trailer empty check and scrapping the json page.
            string[] tvScrappedHtml = ScrapHtmlPage("https://www.themoviedb.org/tv/" + id); // scraping the html page and assigning it to an array.
            TVShow tvObj = new TVShow("https://image.tmdb.org/t/p/w780/" + tvShow.BackdropPath, tvShow.CreatedBy, tvShow.Credits, tvShow.FirstAirDate, tvShow.Genres, "", tvShow.Homepage, tvShow.Id, tvShow.Keywords, tvShow.Name, tvShow.Networks, tvShow.NumberOfEpisodes, tvShow.NumberOfSeasons, tvShow.OriginalName, tvShow.Overview, tvShow.Popularity, tvShow.PosterPath, "(" + Convert.ToDateTime(tvShow.FirstAirDate).Year.ToString() + ")", tvShow.Seasons, tvShow.Status, tvScrappedHtml[1], tvScrappedHtml[0], tvTrailerURL, 1, tvShow.Type, tvShow.Videos, tvShow.VoteAverage, tvShow.VoteCount);
            return tvObj; // returning it back to the MediaSearchForm so it can pass it to the MediaResultsForm
        }

        /// <summary>
        /// Scrapes the meta data for the Actor Object passed to it, creates an Actor Object with it, and returns it.
        /// </summary>
        /// <param name="passedTv"></param>
        /// <param name="id"></param>
        /// <param name="mediaType"></param>
        /// <returns></returns>
        public Actor ScrapeMetaData(Actor passedActor, int id, string mediaType) // all the same as the movie object above, 
        {                                                                                       //just for tv object.
            Person person = client.GetPersonAsync(passedActor.Id).Result; // GetTVShowAsync instead of GetMovieAsync
            Actor actor = new Actor(1, person.Adult, person.AlsoKnownAs, person.Biography, person.Birthday, person.Changes, person.Deathday, person.ExternalIds, person.Gender, person.Homepage, person.Id, person.Images, person.ImdbId, person.MovieCredits, person.Name, person.PlaceOfBirth, person.Popularity, person.ProfilePath, person.TaggedImages, person.TvCredits);
            return actor; // returning it back to the MediaSearchForm so it can pass it to the MediaResultsForm
        }

        /// <summary>
        /// Takes a trailer URL and checks if the url has a KEY appended
        /// on the end of it, if it does, it's returned, if it doesn't, then we return set it's value to
        /// null and return it.
        /// </summary>
        /// <param name="trailerURL"></param>
        /// <returns></returns>
        private string TrailerKeyEmptyCheck(string trailerURL)
        {
            if (trailerURL == "https://www.youtube.com/watch?v=") // if the youtube link URL doesn't have the key on the end.
            {                                                      //then set null, which I have a check for in the MediaResultsForm
                return null;                                       // otherwise return the URL as-is.
            }
            else
            {
                return trailerURL;
            }
        }

        /// <summary>
        /// Scraps the JSON page for the variable KEY, 
        /// KEY is the value that we append to the end of a youtube link, which links to the trailer.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private string ScrapJsonPage(Object obj, int id, string APIKey)
        {
            string mediaType = "";
            if (obj is Movie)
            {
                mediaType = "movie";
            }
            else if (obj is TVShow) {
                mediaType = "tv";
            }
            string url = "https://api.themoviedb.org/3/" + mediaType.ToLower() + "/" + id +
            "/videos?api_key=" + APIKey + "&language=en-us"; // the API page to parse the JSON from.
            using (WebClient wc = new WebClient())  // use WebClient to download it, and the using to automatically close it.
            {
                string rawJson = wc.DownloadString(url); // the JSON downloaded and put into a string variable.
                JObject o = JObject.Parse(rawJson); // Parses it into a JObject.
                JToken token = o.SelectToken("$..results[0].key"); // Parses the JSON and gets the KEY attribute.
                return "https://www.youtube.com/watch?v=" + token; //the reutrned youtube link with the token/key appended
            }
        }


        /// <summary>
        /// Scraps the HTML page for the stremaing service text that the media is available on,
        /// and the matching logo for the streaming service.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private string[] ScrapHtmlPage(string url)
        {
            var html = @url; // the url to scrape.
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html); // we load the html and put it into a HtmlDocument
            htmlDoc.OptionEmptyCollection = true; // gets rid of error.
            var availableOn = htmlDoc?.DocumentNode?.SelectNodes("//div[contains(@class, 'provider')]")?.Descendants("img")
                ?.FirstOrDefault()?.GetAttributeValue("alt", null); // the text for what streaming service it's available on.
            var logo = htmlDoc?.DocumentNode?.SelectNodes("//div[contains(@class, 'provider')]")
                ?.Descendants("img")?.FirstOrDefault()?.GetAttributeValue("src", null); // the corresponding logo image url for the service.
            if (availableOn == null) // if we can't find a service to stream/purchase from, we set that string.
            {
                availableOn = "No Available Streaming Service/Purchase Option Found.";
            }
            if (logo == null) // if there's no logo, we set the url for the logo to an empty string, which is checked for in the
            {                       // Results Form.
                logo = "";
            }
            string[] scrappedhtml = { availableOn, logo }; // we put the two in an arry so I can return both values from the method.
            return scrappedhtml; // we return the array for use above in the ScrapMetaData method's.
        }
    }
}
