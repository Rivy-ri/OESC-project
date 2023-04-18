using OmegaSportExplorerClub.src.Connection;
using System.Data;
using System.Data.SqlClient;


namespace OmegaSportExplorerClub.src.DatabaseReaders.ReadersCollection
{
    public class GetNamesOfInstancesOfEntityReader
    {
        public List<string> GetInstances(string type)
        {
            List<string> returnList = new List<string>();
            SqlConnection connection = ConnectionSingleton.Connection();
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string sql = "";
            switch (type)
            {
                case "TrainingGroup":
                    sql = "Select TrainingGroup.Name from TrainingGroup";
                    break;
                case "Team":
                    sql = "Select Team.Name from team";
                    break;
                case "Players":
                    sql = "Select Player.Name+' '+Player.Surname as [Full name] from Player";
                    break;
            }
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            returnList.Add(reader[0].ToString());
                        }
                        reader.Close();
                        connection.Close();
                        return returnList;

                    }
                    else
                    {
                        throw new Exception("Empty list");

                    }
                }
            }
        }
    }
}
