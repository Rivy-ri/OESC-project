using OmegaSportExplorerClub.Database_entity_class;
using OmegaSportExplorerClub.src.Connection;
using OmegaSportExplorerClub.src.Database_entity_class;
using OmegaSportExplorerClub.src.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace OmegaSportExplorerClub.src.DatabaseReaders.ReadersCollection
{
    public class TeamsReader : InterfaceReaderWithParametr<Player>
    {
        public List<Player> GetDataFromDtabase(string teamName)
        {
            List<Player> teamsPlayers = new List<Player>();
            SqlConnection connection = ConnectionSingleton.Connection();
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            try
            {
                using (SqlCommand command = new SqlCommand("Exec [dbo].[TeamsPlayers] @teamName", connection))
                {
                    SqlParameter parameter = new SqlParameter("@teamName", SqlDbType.VarChar);
                    parameter.Value = teamName;
                    command.Parameters.Add(parameter);
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                Player player = new Player()
                                {
                                    Name = reader[0].ToString().Split(" ")[0],
                                    Surename = reader[0].ToString().Split(" ")[1],
                                    Majority = reader[1].ToString(),
                                };
                                teamsPlayers.Add(player);
                            }
                            reader.Close();
                            return teamsPlayers;
                        }
                        else
                        {
                            throw new Exception("Empty list");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return teamsPlayers;
            }

        }

        public void WriteData(DataGridView view, string teamName)
        {
            if (view.Rows.Count <= 0)
            {
                if (view.Columns.Count < 2)
                {
                    view.Columns.Add("Player full name", "Player full name");
                    view.Columns.Add("Players position", "Players position");
                    view.ColumnHeadersHeight = 50;
                    view.ColumnHeadersVisible = true;
                }
                Team team = new Team()
                {
                    Name = teamName,
                    Players_list = GetDataFromDtabase(teamName),
                };
                foreach (Player player in team.Players_list)
                {
                    view.Rows.Add(player.Name, player.Majority);
                }

                view.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
        }

    }
}
