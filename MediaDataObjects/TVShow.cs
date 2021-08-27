using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TMDbLib.Objects.Changes;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Reviews;
using TMDbLib.Objects.Search;
using TMDbLib.Objects.TvShows;
using TMDbLib.Utilities.Converters;
using Credits = TMDbLib.Objects.TvShows.Credits;

namespace MediaDataObjects
{
    /// <summary>
    /// The TVShow Object class to store everything related to a tv show.
    /// </summary>
    public class TVShow
    {
        public string BackdropPath { get; set; }
        public List<CreatedBy> CreatedBy { get; set; }
        public Credits Credits { get; set; }
        public DateTime? FirstAirDate { get; set; }
        public List<Genre> Genres { get; set; }
        public string GenresString { get; set; }
        public string Homepage { get; set; }
        public int Id { get; set; }
        public ResultContainer<Keyword> Keywords { get; set; }
        public string Name { get; set; }
        public List<NetworkWithLogo> Networks { get; set; }
        public int NumberOfEpisodes { get; set; }
        public int NumberOfSeasons { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }
        public string PosterPath { get; set; }
        public string ReleaseDateString { get; set; }
        public List<SearchTvSeason> Seasons { get; set; }
        public string Status { get; set; }
        public string StreamOnLogo { get; set; }
        public string StreamOn { get; set; }
        public string Trailer { get; set; }
        public int TVShowID { get; set; }
        public string Type { get; set; }
        public ResultContainer<Video> Videos { get; set; }
        public double VoteAverage { get; set; }
        public int VoteCount { get; set; }

        /// <summary>
        /// Full Constructor
        /// </summary>
        /// <param name="backdropPath"></param>
        /// <param name="createdBy"></param>
        /// <param name="credits"></param>
        /// <param name="firstAirDate"></param>
        /// <param name="genres"></param>
        /// <param name="homepage"></param>
        /// <param name="id"></param>
        /// <param name="keywords"></param>
        /// <param name="name"></param>
        /// <param name="networks"></param>
        /// <param name="numberOfEpisodes"></param>
        /// <param name="numberOfSeasons"></param>
        /// <param name="title"></param>
        /// <param name="overview"></param>
        /// <param name="popularity"></param>
        /// <param name="posterPath"></param>
        /// <param name="seasons"></param>
        /// <param name="status"></param>
        /// <param name="streamOnLogo"></param>
        /// <param name="streamOn"></param>
        /// <param name="trailer"></param>
        /// <param name="tVShowID"></param>
        /// <param name="type"></param>
        /// <param name="videos"></param>
        /// <param name="voteAverage"></param>
        /// <param name="voteCount"></param>
        public TVShow(string backdropPath, List<CreatedBy> createdBy, Credits credits, DateTime? firstAirDate, List<Genre> genres, string genresString, string homepage, int id, ResultContainer<Keyword> keywords, string name, List<NetworkWithLogo> networks, int numberOfEpisodes, int numberOfSeasons, string title, string overview, double popularity, string posterPath, string releaseDateString, List<SearchTvSeason> seasons, string status, string streamOnLogo, string streamOn, string trailer,int tVShowID, string type, ResultContainer<Video> videos, double voteAverage, int voteCount)
        {

            BackdropPath = backdropPath;
            CreatedBy = createdBy;
            Credits = credits;
            FirstAirDate = firstAirDate;
            if (genres == null)
            {
                throw new ArgumentNullException(nameof(genres));
            }
            else {
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
            Id = id;
            Keywords = keywords;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Networks = networks ?? throw new ArgumentNullException(nameof(networks));
            NumberOfEpisodes = numberOfEpisodes;
            NumberOfSeasons = numberOfSeasons;
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Overview = overview;
            Popularity = popularity;
            if (posterPath == null || PosterPath == "")
            {
                PosterPath = "https://josselyn.org/wp-content/themes/qube/assets/images/no-image/No-Image-Found-400x264.png";
            }
            else {
                PosterPath = "http://image.tmdb.org/t/p/w500" + posterPath;
            }
            ReleaseDateString = releaseDateString;
            Seasons = seasons;
            Status = status ?? throw new ArgumentNullException(nameof(status));
            StreamOnLogo = streamOnLogo;
            StreamOn = streamOn;
            Trailer = trailer;
            TVShowID = tVShowID;
            Type = type;
            Videos = videos;
            VoteAverage = voteAverage;
            VoteCount = voteCount;
        }

        /// <summary>
        /// Partical Constructor
        /// </summary>
        /// <param name="backdropPath"></param>
        /// <param name="firstAirDate"></param>
        /// <param name="genres"></param>
        /// <param name="id"></param>
        /// <param name="keywords"></param>
        /// <param name="name"></param>
        /// <param name="networks"></param>
        /// <param name="numberOfEpisodes"></param>
        /// <param name="numberOfSeasons"></param>
        /// <param name="title"></param>
        /// <param name="overview"></param>
        /// <param name="popularity"></param>
        /// <param name="posterPath"></param>
        /// <param name="seasons"></param>
        /// <param name="tVShowID"></param>
        /// <param name="type"></param>
        /// <param name="voteAverage"></param>
        /// <param name="voteCount"></param>
        public TVShow(string backdropPath, DateTime? firstAirDate, List<Genre> genres, string genresString, int id, ResultContainer<Keyword> keywords, string name, List<NetworkWithLogo> networks, int numberOfEpisodes, int numberOfSeasons, string title, string overview, double popularity, string posterPath, string releaseDateString, List<SearchTvSeason> seasons, int tVShowID, string type, double voteAverage, int voteCount)
        {
            BackdropPath = backdropPath;
            FirstAirDate = firstAirDate;
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
            Id = id;
            Keywords = keywords;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Networks = networks ?? throw new ArgumentNullException(nameof(networks));
            NumberOfEpisodes = numberOfEpisodes;
            NumberOfSeasons = numberOfSeasons;
            Title = title ?? throw new ArgumentNullException(nameof(title));
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
            ReleaseDateString = releaseDateString;
            Seasons = seasons ?? throw new ArgumentNullException(nameof(seasons));
            TVShowID = tVShowID;
            Type = type;
            VoteAverage = voteAverage;
            VoteCount = voteCount;
        }
    }
}
