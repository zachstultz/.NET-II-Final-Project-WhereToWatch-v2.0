using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TMDbLib.Objects.Changes;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Reviews;
using TMDbLib.Objects.Search;

namespace MediaDataObjects
{
    /// <summary>
    /// The Movie object class to store everything related to a movie.
    /// </summary>
    public class Movie
    {
        public AccountState AccountStates { get; set; }
        public bool Adult { get; set; }
        public AlternativeTitles AlternativeTitles { get; set; }
        public string BackdropPath { get; set; }
        public SearchCollection BelongsToCollection { get; set; }
        public long Budget { get; set; }
        public ChangesContainer Changes { get; set; }
        public Credits Credits { get; set; }
        public List<Genre> Genres { get; set; }
        public string GenresString { get; set; }
        public string Homepage { get; set; }
        public Images Images { get; set; }
        public string ImdbId { get; set; }
        public KeywordsContainer Keywords { get; set; }
        public SearchContainer<ListResult> Lists { get; set; }
        public int MovieId { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }
        public string PosterPath { get; set; }
        public List<ProductionCompany> ProductionCompanies { get; set; }
        public List<ProductionCountry> ProductionCountries { get; set; }
        public SearchContainer<SearchMovie> Recommendations { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string ReleaseDateString { get; set; }
        public ResultContainer<ReleaseDatesContainer> ReleaseDates { get; set; }
        public Releases Releases { get; set; }
        public long Revenue { get; set; }
        public SearchContainer<ReviewBase> Reviews { get; set; }
        public int? Runtime { get; set; }
        public SearchContainer<SearchMovie> Similar { get; set; }
        public List<SpokenLanguage> SpokenLanguages { get; set; }
        public string Status { get; set; }
        public string StreamOnLogo { get; set;}
        public string StreamOn { get; set; }
        public string Tagline { get; set; }
        public string Title { get; set; }
        public string Trailer { get; set; }
        public string Type { get; set; }
        public TranslationsContainer Translations { get; set; }
        public bool Video { get; set; }
        public ResultContainer<Video> Videos { get; set; }
        public double VoteAverage { get; set; }
        public int VoteCount { get; set; }

        /// <summary>
        /// Full Constructor
        /// </summary>
        /// <param name="accountStates"></param>
        /// <param name="adult"></param>
        /// <param name="alternativeTitles"></param>
        /// <param name="backdropPath"></param>
        /// <param name="belongsToCollection"></param>
        /// <param name="budget"></param>
        /// <param name="changes"></param>
        /// <param name="credits"></param>
        /// <param name="genres"></param>
        /// <param name="homepage"></param>
        /// <param name="images"></param>
        /// <param name="imdbId"></param>
        /// <param name="keywords"></param>
        /// <param name="lists"></param>
        /// <param name="movieId"></param>
        /// <param name="originalLanguage"></param>
        /// <param name="originalTitle"></param>
        /// <param name="overview"></param>
        /// <param name="popularity"></param>
        /// <param name="posterPath"></param>
        /// <param name="productionCompanies"></param>
        /// <param name="productionCountries"></param>
        /// <param name="recommendations"></param>
        /// <param name="releaseDate"></param>
        /// <param name="releaseDates"></param>
        /// <param name="releases"></param>
        /// <param name="revenue"></param>
        /// <param name="reviews"></param>
        /// <param name="runtime"></param>
        /// <param name="similar"></param>
        /// <param name="spokenLanguages"></param>
        /// <param name="status"></param>
        /// <param name="streamOnLogo"></param>
        /// <param name="streamOn"></param>
        /// <param name="tagline"></param>
        /// <param name="title"></param>
        /// <param name="trailer"></param>
        /// <param name="type"></param>
        /// <param name="translations"></param>
        /// <param name="video"></param>
        /// <param name="videos"></param>
        /// <param name="voteAverage"></param>
        /// <param name="voteCount"></param>
        public Movie(AccountState accountStates, bool adult, AlternativeTitles alternativeTitles, string backdropPath, SearchCollection belongsToCollection, long budget, ChangesContainer changes, Credits credits, List<Genre> genres, string genresString, string homepage, Images images, string imdbId, KeywordsContainer keywords, SearchContainer<ListResult> lists, int movieId, string originalLanguage, string originalTitle, string overview, double popularity, string posterPath, List<ProductionCompany> productionCompanies, List<ProductionCountry> productionCountries, SearchContainer<SearchMovie> recommendations, DateTime? releaseDate,  string releaseDateString, ResultContainer<ReleaseDatesContainer> releaseDates, Releases releases, long revenue, SearchContainer<ReviewBase> reviews, int? runtime, SearchContainer<SearchMovie> similar, List<SpokenLanguage> spokenLanguages, string status, string streamOnLogo, string streamOn, string tagline, string title, string trailer, string type, TranslationsContainer translations, bool video, ResultContainer<Video> videos, double voteAverage, int voteCount)
        {
            AccountStates = accountStates;
            Adult = adult;
            AlternativeTitles = alternativeTitles;
            BackdropPath = backdropPath;
            BelongsToCollection = belongsToCollection;
            Budget = budget;
            Changes = changes;
            Credits = credits;
            if (genres == null)
            {
                throw new ArgumentNullException(nameof(genres));
            }
            else
            {
                Genres = genres;
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
                genresString = build.ToString();
            }
            Homepage = homepage;
            Images = images;
            ImdbId = imdbId ?? throw new ArgumentNullException(nameof(imdbId));
            Keywords = keywords;
            Lists = lists;
            this.MovieId = movieId;
            OriginalLanguage = originalLanguage;
            OriginalTitle = originalTitle;
            Overview = overview;
            Popularity = popularity;
            if (posterPath == null || PosterPath == "")
            {
                PosterPath = "https://josselyn.org/wp-content/themes/qube/assets/images/no-image/No-Image-Found-400x264.png";
            }
            else
            {
                PosterPath = "http://image.tmdb.org/t/p/w500" + posterPath;
            }
            ProductionCompanies = productionCompanies;
            ProductionCountries = productionCountries;
            Recommendations = recommendations;
            ReleaseDate = releaseDate;
            ReleaseDateString = releaseDateString;
            ReleaseDates = releaseDates;
            Releases = releases;
            Revenue = revenue;
            Reviews = reviews;
            Runtime = runtime;
            Similar = similar;
            SpokenLanguages = spokenLanguages;
            Status = status ?? throw new ArgumentNullException(nameof(status));
            StreamOnLogo = streamOnLogo;
            StreamOn = streamOn;
            Tagline = tagline;
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Trailer = trailer;
            Type = type;
            Translations = translations;
            Video = video;
            Videos = videos;
            VoteAverage = voteAverage;
            VoteCount = voteCount;
        }

        /// <summary>
        /// Partial Constructor
        /// </summary>
        /// <param name="adult"></param>
        /// <param name="backdropPath"></param>
        /// <param name="genres"></param>
        /// <param name="images"></param>
        /// <param name="imdbId"></param>
        /// <param name="keywords"></param>
        /// <param name="movieId"></param>
        /// <param name="originalTitle"></param>
        /// <param name="overview"></param>
        /// <param name="popularity"></param>
        /// <param name="posterPath"></param>
        /// <param name="releaseDate"></param>
        /// <param name="runtime"></param>
        /// <param name="tagline"></param>
        /// <param name="title"></param>
        /// <param name="type"></param>
        /// <param name="voteAverage"></param>
        /// <param name="voteCount"></param>
        public Movie(bool adult, string backdropPath, List<Genre> genres, string genresString, Images images, string imdbId, KeywordsContainer keywords, int movieId, string originalTitle, string overview, double popularity, string posterPath, DateTime? releaseDate, string releaseDateString, int? runtime, string tagline, string title, string type, double voteAverage, int voteCount)
        {
            Adult = adult;
            BackdropPath = backdropPath;
            if (genres == null)
            {
                throw new ArgumentNullException(nameof(genres));
            }
            else
            {
                Genres = genres;
                GenresString = genresString;
            }
            Images = images;
            ImdbId = imdbId;
            Keywords = keywords;
            this.MovieId = movieId;
            OriginalTitle = originalTitle;
            Overview = overview;
            Popularity = popularity;
            if (posterPath == null || PosterPath == "")
            {
                PosterPath = "https://josselyn.org/wp-content/themes/qube/assets/images/no-image/No-Image-Found-400x264.png";
            }
            else
            {
                PosterPath = "http://image.tmdb.org/t/p/w500" + posterPath;
            }
            ReleaseDate = releaseDate;
            ReleaseDateString = releaseDateString;
            Runtime = runtime;
            Tagline = tagline;
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Type = type;
            VoteAverage = voteAverage;
            VoteCount = voteCount;
        }
    }
}
