using OmegaSportExplorerClub.Database_entity_class;
using OmegaSportExplorerClub.src.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace OmegaSportExplorerClub.src.DatabaseReaders.ReadersCollection
{
    public class PlayerReader : InterfaceReaderWithParametr<Player>
    {
        public List<Player> GetDataFromDtabase(string groupName)
        {
            List<Player> list = new List<Player>();
            try
            {
                SqlConnection connection = Connection.ConnectionSingleton.Connection();
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                using (SqlCommand command = new SqlCommand("Exec GroupsPlayers @trainingGroupName", connection))
                {
                    SqlParameter parameter = new SqlParameter("@trainingGroupName", SqlDbType.VarChar, 40);
                    parameter.Value = groupName;
                    command.Parameters.Add(parameter);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                string name = reader[0].ToString().Split(' ')[0];
                                string surname = reader[0].ToString().Split(' ')[1];
                                string majority = reader[1].ToString();
                                int age = Convert.ToInt32(reader[2]);
                                string phone = reader[3].ToString();
                                string email = reader[4].ToString();
                                Player instance = new Player(name, surname, age, phone, email);
                                instance.Majority = majority;
                                list.Add(instance);
                            }
                            reader.Close();
                            return list;

                        }
                        else
                        {
                            throw new Exception("Empty list");
                        }

                    }


                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return list;
            }
        }

        public void WriteData(DataGridView view, string groupName)
        {

            if (view.Columns.Count < 1)
            {
                view.Columns.Add("Full name", "Full name");
                view.Columns.Add("Majority", "Majority");
                view.Columns.Add("Age", "Age");
                view.Columns.Add("Phone", "Phone");
                view.Columns.Add("Email", "Email");
                view.ColumnHeadersVisible = true;
                view.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                view.ColumnHeadersHeight = 50;
            }
            view.Rows.Clear();
            var playersList = GetDataFromDtabase(groupName);
            foreach (Player player in playersList)
            {
                view.Rows.Add(player.Name + " " + player.Surename, player.Majority, player.Age, player.PhoneNumber, player.Email);
            }

        }
    }
}
