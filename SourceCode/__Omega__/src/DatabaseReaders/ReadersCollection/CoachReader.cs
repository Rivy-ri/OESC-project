using OmegaSportExplorerClub.Database_entity_class;
using OmegaSportExplorerClub.Interfaces;
using OmegaSportExplorerClub.src.Connection;
using System.Data;
using System.Data.SqlClient;
namespace OmegaSportExplorerClub.src.DatabaseReaders.ReadersCollection
{
    public class CoachReader : InterfaceReaderWidoutParametr<Coach>
    {

        /// <summary>
        /// The method is used to obtain data from the database and then return it in the form of a list
        /// </summary>
        /// <returns> List of Coachs</returns>
        public List<Coach> GetDataFromDtabase()
        {
            List<Coach> list = new List<Coach>();
            try
            {
                SqlConnection connection = ConnectionSingleton.Connection();
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                using (SqlCommand cmd = new SqlCommand("SELECT * From CoachView", connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                string name = reader[0].ToString();
                                string surename = reader[1].ToString();
                                string email = reader[2].ToString();
                                string phone = reader[3].ToString();

                                Coach instance = new Coach(name, surename, email, phone);
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


        /// <summary>
        /// Write data into datagrid view
        /// </summary>
        public void WriteData(DataGridView view)
        {
            if (view.RowCount == 0)
            {
                view.Columns.Add("Name", "Name");
                view.Columns.Add("Surname", "Surname");
                view.Columns.Add("E-mail", "E-mail");
                view.Columns.Add("Phone", "Phone");
                var coach_list = GetDataFromDtabase();
                foreach (Coach coach in coach_list)
                {
                    view.Rows.Add(coach.DB_Name, coach.DB_Surename, coach.DB_Email, coach.DB_Phone);
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
