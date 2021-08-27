using MediaDataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaDataAccess
{
    public interface IUserFavoritesAccessor
    {
        int AddMovieToUsersFavoriteMoviesList(string email, Movie movie);
    }
}
