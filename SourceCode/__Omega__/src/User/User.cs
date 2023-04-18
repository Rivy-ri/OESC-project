namespace OmegaSportExplorerClub.src.User
{
    /// <summary>
    /// Represents a user of the OmegaSportExplorerClub application
    /// </summary>
    public class User
    {
        private string userName;
        private string hash;
        private string email;
        private string verificationCode;
        private string salt;
        private string password;
        /// <summary>
        /// Gets or sets the username of the user
        /// </summary>
        public string UserName { get => userName; set => userName = value; }
        /// <summary>
        /// Gets the password hash of the user
        /// </summary>
        public string Hash { get => hash; }
        /// <summary>
        /// Gets or sets the email address of the user
        /// </summary>
        public string Email { get => email; set => email = value; }
        /// <summary>
        /// Gets or sets the verification code of the user
        /// </summary>
        public string VerificationCode { get => verificationCode; set => verificationCode = value; }
        /// <summary>
        /// Gets the salt used for password hashing of the user
        /// </summary>
        public string Salt { get => salt; }
        /// <summary>
        /// Gets or sets the password of the user
        /// </summary>
        public string Password { get => password; set => password = value; }
        /// <summary>
        /// Initializes a new instance of the User class with the specified name, password, email and verification code
        /// </summary>
        /// <param name="name">The username of the user</param>
        /// <param name="password">The password of the user</param>
        /// <param name="email">The email address of the user</param>
        /// <param name="verificationCode">The verification code of the user</param>
        public User(string name, string password, string email, string verificationCode)
        {
            UserName = name;
            Email = email;
            VerificationCode = verificationCode;
            salt = BCrypt.Net.BCrypt.GenerateSalt();
            hash = BCrypt.Net.BCrypt.HashPassword(password, salt);
            Password = password;


        }
        /// <summary>
        /// Initializes a new instance of the User class with the specified email
        /// </summary>
        /// <param name="email">The email address of the user</param>
        public User(string email)
        {
            Email = email;
        }
        /// <summary>
        /// Initializes a new instance of the User class with the specified name and password
        /// </summary>
        /// <param name="name">The username of the user</param>
        /// <param name="password">The password of the user</param>
        public User(string name, string password)
        {
            UserName = name;
            Password = password;

        }
    }

}
