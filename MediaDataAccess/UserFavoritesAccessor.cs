using MediaDataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaDataAccess
{
    public class UserFavoritesAccessor : IUserFavoritesAccessor
    {
        public int AddMovieToUsersFavoriteMoviesList(string email, Movie movie)
        {
            int result = 0;
            var conn = DBConnection.GetDBConnection();
            var cmd = new SqlCommand("sp_add_movie_to_users_favorite_movies_list", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@OldMovies", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100);

            return result;
        }
    }
}
