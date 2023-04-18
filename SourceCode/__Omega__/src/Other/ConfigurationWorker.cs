using System.Configuration;
using System.IO;

namespace OmegaSportExplorerClub.src.Other
{
    /// <summary>
    /// ConfigurationWorker is a class for handling application configuration settings.
    /// </summary>
    public class ConfigurationWorker
    {
        /// <summary>
        /// Default constructor for ConfigurationWorker class
        /// </summary>
        ConfigurationWorker()
        {

        }
        /// <summary>
        /// Reads database connection string from configuration file by provided key
        /// </summary>
        /// <param name="confKey">The key of the database connection string to be read from configuration file</param>
        /// <returns>The database connection string</returns>
        public static string ReadDatabaseConnectionByKey(string confKey)
        {
            try
            {
                string databaseKeyCon = ConfigurationManager.AppSettings[confKey];
                return databaseKeyCon;
            }
            catch (Exception ex)
            {
                string val = Convert.ToString(ex.Message);
                if (CheckExistencOfConfigurationFile() == true)
                {
                    MessageBox.Show("--> Dev message: An error occurred when reading data to the database, configuration file wrongly filled \n" + val);
                    return null;
                }
                else
                {
                    MessageBox.Show("--> Dev message: An error occurred when reading data to the database, configuration file is missing \n" + val);
                    return null;
                }


            }
        }
        /// <summary>
        /// Checks the existence of the configuration file
        /// </summary>
        /// <returns>True if the configuration file exists, false otherwise</returns>
        private static bool CheckExistencOfConfigurationFile()
        {
            string configurationFilePath = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath;
            if (File.Exists(configurationFilePath))
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
