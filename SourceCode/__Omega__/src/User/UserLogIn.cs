using MaterialSkin.Controls;
using OmegaSportExplorerClub.src.Connection;
using System.Data;
using System.Data.SqlClient;

namespace OmegaSportExplorerClub.src.User
{
    /// <summary>
    /// Represents the functionality for logging in a user.
    /// </summary>
    public class UserLogIn
    {
        private User User;
        /// <summary>
        /// Initializes a new instance of the <see cref="UserLogIn"/> class with the given user.
        /// </summary>
        /// <param name="user">The user to log in.</param>
        public UserLogIn(User user)
        {
            User1 = user;

        }
        /// <summary>
        /// Gets or sets the user for this instance.
        /// </summary>
        internal User User1 { get => User; set => User = value; }

        /// <summary>
        /// Verifies the user's login credentials by checking them against the database.
        /// </summary>
        /// <returns>True if the user is authenticated, false otherwise.</returns>
        public bool Verification()
        {
            try
            {

                if (ConnectionSingleton.Connection() == null)
                {
                    MessageBox.Show("Not connected to database");
                    return false;
                }
                var userNamecheck = SqlInjectionCheck.Check_text(User1.UserName);
                var passwordCheck = SqlInjectionCheck.Check_text(User1.Password);
                if (userNamecheck == false && passwordCheck == false)
                {

                    string hashed = BCrypt.Net.BCrypt.HashPassword(User.Password, RetriveSalt());
                    var result = hashed == RetriveHash();
                    return result;

                }
                else
                {
                    MessageBox.Show("wrong name or password");
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Retrieves the salt for the user's password hash from the database.
        /// </summary>s
        /// <returns>The salt for the user's password hash, or null if not found.</returns>
        private string RetriveSalt()
        {
            var connection = ConnectionSingleton.Connection();
            using (SqlCommand sqlCommand = new SqlCommand("Select salt From [AplicationUser] where name=@name", connection))
            {
                SqlParameter param_name = new SqlParameter("@name", SqlDbType.VarChar);
                param_name.Value = User.UserName;
                sqlCommand.Parameters.Add(param_name);
                if (connection.State == ConnectionState.Connecting){
                    MessageBox.Show("Application is still connecting, please wait and try again");
                    return null;
                }
                var db_answer = sqlCommand.ExecuteScalar();

                if (db_answer != null)
                {
                    var salt = db_answer.ToString();
                    return salt;

                }
                return null;
            }
        }
        /// <summary>
        /// Retrieves the password hash for the user from the database.
        /// </summary>
        /// <returns>The password hash for the user, or null if not found.</returns>
        private string RetriveHash()
        {
            var connection = ConnectionSingleton.Connection();
            using (SqlCommand sqlCommand = new SqlCommand("Select hash From [AplicationUser] where name=@name", connection))
            {
                SqlParameter param_name = new SqlParameter("@name", SqlDbType.VarChar);
                param_name.Value = User.UserName;
                sqlCommand.Parameters.Add(param_name);
                var db_answer = sqlCommand.ExecuteScalar();

                if (db_answer != null)
                {
                    var hash = db_answer.ToString();
                    return hash;

                }
                return null;
            }


        }
        /// <summary>
        /// Saves the user's login information to user settings if the "Remember Me" checkbox is checked.
        /// </summary>
        /// <param name="checkbox">The checkbox control for "Remember Me".</param>
        /// <param name="username">The username to save.</param>
        /// <param name="password">the password to save</param>
        public static void RememberMe(MaterialCheckbox checkbox, string username, string password)
        {
            if (checkbox.Checked == true)
            {
                Properties.User.Default.UserName = username.Trim();
                Properties.User.Default.Password = password.Trim();
                Properties.User.Default.RememberMe = true;
                Properties.User.Default.Save();
            }
            else
            {
                Properties.User.Default.UserName = "";
                Properties.User.Default.Password = "";
                Properties.User.Default.RememberMe = false;
                Properties.User.Default.Save();

            }

        }
        /// <summary>
        /// Method will load remembered user name and password
        /// </summary>
        /// <param name="rememberMe">Check box it user wan to be remembered</param>
        /// <param name="username">username box where we wan to load data of username</param>
        /// <param name="password">password box where we want to load data of password</param>
        public static void RememberMeLoad(MaterialCheckbox rememberMe, MaterialTextBox2 username, MaterialTextBox2 password)
        {
            username.Text = Properties.User.Default.UserName;
            password.Text = Properties.User.Default.Password;
            rememberMe.Checked = Properties.User.Default.RememberMe;
        }
    }
}
