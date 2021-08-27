using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaDataObjects
{
    public class User
    {
        /// <summary>
        /// Stores our roles
        /// </summary>
        private List<string> roles;

        /// <summary>
        /// The User's Account ID.
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// The User's Account Username.
        /// </summary>
        public string Usernamne { get; set; }
        /// <summary>
        /// The User's Account Name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The User's Account Email.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// The User's Account PasswordHash.
        /// </summary>
        public string PasswordHash { get; set; }
        /// <summary>
        /// The User's Account Status.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Full Constructor
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="usernamne"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="passwordHash"></param>
        /// <param name="active"></param>
        public User(int userID, string usernamne, string name, string email, bool active)
        {
            UserID = userID;
            Usernamne = usernamne ?? throw new ArgumentNullException(nameof(usernamne));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Active = active;
        }
    }
}
