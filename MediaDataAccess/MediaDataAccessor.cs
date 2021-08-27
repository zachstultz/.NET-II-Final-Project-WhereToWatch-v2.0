using MediaDataObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace MediaDataAccess
{
    /// <summary>
    /// Handles access to the Object Lists that we store Movie and TV Show Objects in
    /// </summary>
    public class MediaDataAccessor
    {
        /// <summary>
        /// the media list, it includes movies, tv shows, and people.
        /// </summary>
        private static List<Object> _media = new List<Object>();

        /// <summary>
        /// The list of movies and tv shows favorited by the user.
        /// </summary>
        private static List<Object> _usersFavorites = new List<Object>();

        /// <summary>
        /// Retrieves a media list depending on the value passed, then returns it.
        /// </summary>
        /// <returns></returns>
        public static List<Object> RetrieveMediaList(int i)
        {
            if (i == 0) // 0=default list, anything else is the favorite list.
            {
                return _media;
            }
            else
            {
                return _usersFavorites;
            }
        }

        /// <summary>
        /// Clears the media list of the list of the corresponding value passed.
        /// </summary>
        public static void ClearMediaList(int i)
        {
            if (i == 0) // clears the list, does _media if it's 0, otherwise the favorites list.
            {
                _media.Clear();
            }
            else
            {
                _usersFavorites.Clear();
            }
        }

        /// <summary>
        /// Adds whatever object is passed-in to the corresponding List, based on the value that was passed in.
        /// </summary>
        /// <param name="movie"></param>
        public static void AddMedia(Object mediaObj, int i)
        {
            if (i == 0) // if the value is 0, it's for the regular List, otherwise it's for the favorites list.
            {
                _media.Add(mediaObj);
            }
            else
            {
                _usersFavorites.Add(mediaObj);
            }
        }

        /// <summary>
        /// Writes the user's favorite to an xml file.
        /// </summary>
        public static void WriteFavoriteToXML(Object mediaObj)
        {
            try
            {
                if (mediaObj.GetType().ToString().Contains("Movie"))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Movie)); // Serializes the object passed in.
                    Movie movie = (Movie)mediaObj; // Movie Object
                    var path = AppDomain.CurrentDomain.BaseDirectory + "//Favorites.xml"; // root file path
                    Stream stream = new FileStream(path, FileMode.Append);
                    XmlWriterSettings settings = new XmlWriterSettings(); // Settings to format the file so it's not all on one line.
                    settings.Indent = true;
                    settings.IndentChars = ("\t");
                    settings.Encoding = Encoding.Unicode;
                    using (XmlWriter writer = XmlWriter.Create(stream, settings)) // writes it to the file
                    {
                        serializer.Serialize(writer, movie);
                    }
                }
                else
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(TVShow)); // samse as above, but for the TVShow Object.
                    TVShow tvShow = (TVShow)mediaObj;
                    var path = AppDomain.CurrentDomain.BaseDirectory + "//Favorites.xml";
                    Stream stream = new FileStream(path, FileMode.Append);
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;
                    settings.IndentChars = ("\t");
                    settings.Encoding = Encoding.Unicode;
                    using (XmlWriter writer = XmlWriter.Create(stream, settings))
                    {
                        serializer.Serialize(writer, tvShow);
                    }
                }
            }
            catch (IOException)
            {
            }
        }

        // Had to cut this unfortanetly due to running out of time, hadn't quite got it all of it figured out.

        /// <summary>
        /// Reads all Movie & TV Objects from Favorites.xml file into the
        /// favorites List.
        /// Although the
        /// </summary>
        //public static void ReadFavoritesFromXML() {
        //    XDocument document = XDocument.Load(AppDomain.CurrentDomain.BaseDirectory + "//Favorites.xml");
        //    var result = from c in document.Descendants("Movie")
        //                 select new Movie()
        //                 {
        //                     ReleaseDate = (string)c.Element("ReleaseDate").Value,
        //                     Runtime = int.Parse(c.Element("Runtime").Value),
        //                     Tagline = (string)c.Element("ReleaseDate").Value,
        //                     Title = (string)c.Element("ReleaseDate").Value,
        //                     VoteAverage = double.Parse(c.Element("ReleaseDate").Value),
        //                     PosterPath = (string)c.Element("ReleaseDate").Value,
        //                     Overview = (string)c.Element("ReleaseDate").Value,
        //                     BackdropPath = (string)c.Element("ReleaseDate").Value,
        //                     Id = int.Parse(c.Element("ReleaseDate").Value),
        //                     ImdbId = (string)c.Element("ReleaseDate").Value,
        //                     OriginalTitle = (string)c.Element("ReleaseDate").Value,
        //                     VoteCount = int.Parse(c.Element("ReleaseDate").Value),
        //                     Type = (string)c.Element("ReleaseDate").Value,
        //                     StreamOnLogo = (string)c.Element("ReleaseDate").Value,
        //                     StreamOn = (string)c.Element("ReleaseDate").Value,
        //                     TrailerURL = (string)c.Element("ReleaseDate").Value
        //                 };
        //}
    }
}
