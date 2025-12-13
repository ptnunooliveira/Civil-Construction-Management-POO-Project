namespace Civil_Construction_Management.Models
{
    /// <summary>
    /// Represents a system user with a username and password.
    /// Used for authentication and access control.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the username associated with the user account.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the user's password.
        /// Note: In a real-world system this should be stored in a hashed format.
        /// </summary>
        public string Password { get; set; }
    }
}