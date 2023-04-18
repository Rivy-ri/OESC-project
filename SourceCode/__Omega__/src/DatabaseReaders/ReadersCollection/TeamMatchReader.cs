using OmegaSportExplorerClub.src.Database_entity_class;
using OmegaSportExplorerClub.src.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace OmegaSportExplorerClub.src.DatabaseReaders.ReadersCollection
{
    public class TeamMatchReader : InterfaceReaderWithParametr<Match>
    {
        public List<Match> GetDataFromDtabase(string teamName)
        {
            List<Match> list = new List<Match>();
            SqlConnection connection = Connection.ConnectionSingleton.Connection();
            try
            {
                using (SqlCommand command = new SqlCommand("Exec TeamsMatchHistory @teamName", connection))
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
                                Match match = new Match()
                                {
                                    Oponent = reader[0].ToString(),
                                    Notes = reader[1].ToString(),
                                    VictoryOfOurTeam = Convert.ToBoolean(reader[2]),
                                };
                                list.Add(match);
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
            catch (Exception)
            {
                MessageBox.Show("Error");
                return list;
            }
        }

        public void WriteData(DataGridView view, string input)
        {
            if (view.Rows.Count <= 0)
            {
                if (view.Columns.Count < 2)
                {
                    view.Columns.Add("Opponent", "Opponent");
                    view.Columns.Add("Notes", "Notes");
                    view.Columns.Add("Our wins", "Our wins");
                    view.ColumnHeadersHeight = 50;
                    view.ColumnHeadersVisible = true;
                }
                List<Match> listOfMatches = GetDataFromDtabase(input);
                foreach (Match match in listOfMatches)
                {
                    view.Rows.Add(match.Oponent, match.Notes, match.VictoryOfOurTeam ? "won" : "lost");
                }

                view.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
        }
    }

}
