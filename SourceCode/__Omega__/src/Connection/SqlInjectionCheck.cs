using System.Text;
using System.Text.RegularExpressions;
using System.Net;
namespace OmegaSportExplorerClub.src.Connection
{
    /// <summary>
    /// Class represent protection before sql injection
    /// </summary>
    public class SqlInjectionCheck
    {
        private string text;
        private int suspicious_characters;

        public SqlInjectionCheck(string text, int suspicious_characters)
        {
            Text = text;
            Suspicious_characters = suspicious_characters;
        }

        public string Text { get => text; set => text = value; }
        public int Suspicious_characters { get => suspicious_characters; set => suspicious_characters = value; }
        /// <summary>
        /// Method will check if the string is not suspicions
        /// </summary>
        /// <param name="text"> text we want to check</param>
        /// <returns> true if there are suspicious characters false if not</returns>
        public static bool Check_text(string text)
        {
            string pattern = @"(--)|(;)|(=)|(')";
            var result = Regex.Matches(text, pattern);
            SqlInjectionCheck tested_string = new SqlInjectionCheck(text, result.Count);
            if (tested_string.suspicious_characters > 0)
            {
                return true;

            }
            else
            {
                return false;
            }


        }
    }
}
