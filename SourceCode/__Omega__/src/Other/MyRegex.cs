using System.Text.RegularExpressions;


namespace OmegaSportExplorerClub.src.Other
{
    /// <summary>
    /// The MyRegex class provides methods for validating text using regular expressions.
    /// </summary>
    public class MyRegex
    {
        private string text;

        /// <summary>
        /// Gets or sets the text to be validated.
        /// </summary>
        public string Text { get => text; set => text = value; }
        /// <summary>
        /// Initializes a new instance of the MyRegex class with the specified input.
        /// </summary>
        /// <param name="input">The input text to be validated.</param>
        public MyRegex(string input)
        {
            Text = input;
        }
        /// <summary>
        /// Checks whether the Text property contains a valid email address.
        /// </summary>
        /// <returns>true if the Text property contains a valid email address; otherwise, false.</returns>
        public bool CheckEmail()
        {
            string pattern = @"([a-zA-Z-ĚŠČŘŽÝÁÍÉÚŮěščřžýáíéúů0-9]+)@([a-zA-Z-ĚŠČŘŽÝÁÍÉÚŮěščřžýáíéúů0-9]+)\.([a-zA-Z-ĚŠČŘŽÝÁÍÉÚŮěščřžýáíéúů0-9]{2,3})";
            var result = Regex.IsMatch(text, pattern);
            return result;
        }
        /// <summary>
        /// Checks whether the Text property contains a valid phone number.
        /// </summary>
        /// <returns>true if the Text property contains a valid phone number; otherwise, false.</returns>
        public bool CheckPhone()
        {
            string pattern = @"^[0-9]{9}$";
            var result = Regex.IsMatch(text, pattern);
            return result;

        }
        /// <summary>
        /// Checks whether the Text property contains a valid password.
        /// </summary>
        /// <returns>true if the Text property contains a valid password; otherwise, false.</returns>
        public bool CheckPassword()
        {
            string pattern = @"(?=.*\d).{6,}$";
            var result = Regex.IsMatch(text, pattern);
            return result;

        }
        /// <summary>
        /// Checks whether the Text property contains a valid username.
        /// </summary>
        /// <returns>true if the Text property contains a valid username; otherwise, false.</returns>
        public bool CheckUserName()
        {
            string pattern = @"[A-Za-z]{3,20}";
            var result = Regex.IsMatch(text, pattern);
            return result;
        }
        /// <summary>
        /// Checks whether the Text property contains a valid card number.
        /// </summary>
        /// <returns>true if the Text property contains a valid card number; otherwise, false.</returns>
        public bool CheckCardNumber()
        {
            string pattern = @"^[0-9]{10}$";
            var result = Regex.IsMatch(text, pattern);
            return result;
        }
    }
}
