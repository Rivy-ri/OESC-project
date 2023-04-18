using MaterialSkin.Controls;
using OmegaSportExplorerClub.src.Other;
using System.Configuration;
using System.Data.SqlClient;

namespace OmegaSportExplorerClub.src.Connection
{
    /// <summary>
    /// Class represent sql connection to database as singleton 
    /// </summary>
    public class ConnectionSingleton
    {

        private static SqlConnection connection = null;

        
        /// <summary>
        /// Method serve for connecting to database by connection string
        /// </summary>
        /// <returns> Sqlconnection or if it's no capable to read from configuration than Null</returns>
        public static SqlConnection Connection()
        {

            if (connection == null)
            {
                try { 


                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                    builder.DataSource = ConfigurationWorker.ReadDatabaseConnectionByKey("DatabaseDataSource");
                    builder.UserID = ConfigurationWorker.ReadDatabaseConnectionByKey("DatabaseLogInName");
                    builder.Password = ConfigurationWorker.ReadDatabaseConnectionByKey("DatabaseLogInPassword");

                    connection = new SqlConnection(builder.ConnectionString);
                    
                    connection.Open();
                    return connection;
                }
                catch (Exception )
                {
                    connection = null;
                    return null;

                }
            }
            return connection;
        }

        /// <summary>
        /// Empty constructor for single ton pattern
        /// </summary>
        private ConnectionSingleton()
        {

        }
        /// <summary>
        /// Method show on button icon base on if is program capebel to still connect to database
        /// </summary>
        /// <param name="button">MaterialFloatingActionButton where the icon will be changed </param>
        public static void ConnectionNotification(MaterialFloatingActionButton button)
        {
            if (Connection() != null)
            {
                if (button.IsHandleCreated)
                {
                    button.Invoke(new Action(() => { button.Icon = Properties.Resources.internet; }));
                }
            }
            else
            {
                if (button.IsHandleCreated)
                {
                    button.Invoke(new Action(() => { button.Icon = Properties.Resources.no_wifi; }));
                }
            }
        }

        /// <summary>
        /// Close connection with database
        /// </summary>
        public static void Close()
        {
            try
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("--> Dev message: The connection failed to terminate\nerror message: " + ex.Message);

            }


        }

    }
}
