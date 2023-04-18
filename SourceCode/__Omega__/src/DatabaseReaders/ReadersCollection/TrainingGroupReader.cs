using OmegaSportExplorerClub.Database_entity_class;
using OmegaSportExplorerClub.Interfaces;
using OmegaSportExplorerClub.src.Connection;
using System.Data;
using System.Data.SqlClient;

namespace OmegaSportExplorerClub.src.DatabaseReaders.ReadersCollection
{
    public class TrainingGroupReader : InterfaceReaderWidoutParametr<TrainingGroup>
    {
        public List<TrainingGroup> GetDataFromDtabase()
        {
            List<TrainingGroup> list = new List<TrainingGroup>();
            
            try
            {
                SqlConnection connection = ConnectionSingleton.Connection();
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                using (SqlCommand command = new SqlCommand("Select * from GroupView", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                string group_name = reader[0].ToString();
                                string name_of_type = reader[1].ToString();
                                string coach = reader[2].ToString();
                                string number_of_players = reader[3].ToString();

                                TrainingGroup instance = new TrainingGroup()
                                {
                                    Db_coach = coach,
                                    Db_group_name = group_name,
                                    Number_of_players = Convert.ToInt32(number_of_players),
                                    Db_type = name_of_type,
                                };
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return list;
            }
        }

        public void WriteData(DataGridView view)
        {

            if (view.RowCount == 0)
            {


                view.Columns.Add("NumberOfPlayers", "Number of players");
                view.Columns.Add("TypeOfGroup", "Type of group");
                view.Columns.Add("Coach", "Coach name and surname");
                view.Columns.Add("NameOfGroup", "Name of group");
                var training_group_list = GetDataFromDtabase();
                foreach (TrainingGroup group in training_group_list)
                {
                    view.Rows.Add(group.Number_of_players, group.Db_type, group.Db_coach, group.Db_group_name);
                }
                view.ColumnHeadersVisible = true;
                view.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                view.ColumnHeadersHeight = 50;


            }
            else
            {
                return;
            }



        }

    }
}
