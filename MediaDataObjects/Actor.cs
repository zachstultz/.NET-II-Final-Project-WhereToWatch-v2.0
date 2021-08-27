using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDbLib.Objects.Changes;
using TMDbLib.Objects.General;
using TMDbLib.Utilities.Converters;
using TMDbLib.Objects.People;

namespace MediaDataObjects
{
    /// <summary>
    /// Our Actor Object.
    /// </summary>
    public class Actor
    {
        public int ActorID { get; set; }
        public bool Adult { get; set; }
        public List<string> AlsoKnownAs { get; set; }
        public string Biography { get; set; }
        public DateTime? Birthday { get; set; }
        public ChangesContainer Changes { get; set; }
        public DateTime? Deathday { get; set; }
        public ExternalIdsPerson ExternalIds { get; set; }
        public PersonGender Gender { get; set; }
        public string Homepage { get; set; }
        public int Id { get; set; }
        public ProfileImages Images { get; set; }
        public string ImdbId { get; set; }
        public MovieCredits MovieCredits { get; set; }
        public string Name { get; set; }
        public string PlaceOfBirth { get; set; }
        public double Popularity { get; set; }
        public string ProfilePath { get; set; }
        public SearchContainer<TaggedImage> TaggedImages { get; set; }
        public TvCredits TvCredits { get; set; }

        /// <summary>
        /// Full Constructor
        /// </summary>
        /// <param name="actorID"></param>
        /// <param name="adult"></param>
        /// <param name="alsoKnownAs"></param>
        /// <param name="biography"></param>
        /// <param name="birthday"></param>
        /// <param name="changes"></param>
        /// <param name="deathday"></param>
        /// <param name="externalIds"></param>
        /// <param name="gender"></param>
        /// <param name="homepage"></param>
        /// <param name="id"></param>
        /// <param name="images"></param>
        /// <param name="imdbId"></param>
        /// <param name="movieCredits"></param>
        /// <param name="name"></param>
        /// <param name="placeOfBirth"></param>
        /// <param name="popularity"></param>
        /// <param name="profilePath"></param>
        /// <param name="taggedImages"></param>
        /// <param name="tvCredits"></param>
        public Actor(int actorID, bool adult, List<string> alsoKnownAs, string biography, DateTime? birthday, ChangesContainer changes, DateTime? deathday, ExternalIdsPerson externalIds, PersonGender gender, string homepage, int id, ProfileImages images, string imdbId, MovieCredits movieCredits, string name, string placeOfBirth, double popularity, string profilePath, SearchContainer<TaggedImage> taggedImages, TvCredits tvCredits)
        {
            ActorID = actorID;
            Adult = adult;
            AlsoKnownAs = alsoKnownAs;
            Biography = biography;
            Birthday = birthday;
            Changes = changes;
            Deathday = deathday;
            ExternalIds = externalIds;
            Gender = gender;
            Homepage = homepage;
            Id = id;
            Images = images;
            ImdbId = imdbId ?? throw new ArgumentNullException(nameof(imdbId));
            MovieCredits = movieCredits;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            PlaceOfBirth = placeOfBirth;
            Popularity = popularity;
            ProfilePath = profilePath;
            TaggedImages = taggedImages;
            TvCredits = tvCredits;
        }

        /// <summary>
        /// Partial Constructor
        /// </summary>
        /// <param name="actorID"></param>
        /// <param name="adult"></param>
        /// <param name="alsoKnownAs"></param>
        /// <param name="deathday"></param>
        /// <param name="gender"></param>
        /// <param name="id"></param>
        /// <param name="images"></param>
        /// <param name="imdbId"></param>
        /// <param name="name"></param>
        /// <param name="popularity"></param>
        /// <param name="profilePath"></param>
        /// <param name="taggedImages"></param>
        public Actor(int actorID, bool adult, List<string> alsoKnownAs, DateTime? deathday, PersonGender gender, int id, ProfileImages images, string imdbId, string name, double popularity, string profilePath, SearchContainer<TaggedImage> taggedImages)
        {
            ActorID = actorID;
            Adult = adult;
            AlsoKnownAs = alsoKnownAs ?? throw new ArgumentNullException(nameof(alsoKnownAs));
            Deathday = deathday;
            Gender = gender;
            Id = id;
            Images = images ?? throw new ArgumentNullException(nameof(images));
            ImdbId = imdbId ?? throw new ArgumentNullException(nameof(imdbId));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Popularity = popularity;
            ProfilePath = profilePath ?? throw new ArgumentNullException(nameof(profilePath));
            TaggedImages = taggedImages ?? throw new ArgumentNullException(nameof(taggedImages));
        }
    }
}
