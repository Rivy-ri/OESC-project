using OmegaSportExplorerClub.Database_entity_class;
using OmegaSportExplorerClub.src.Database_entity_class;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using Zen.Barcode;

namespace OmegaSportExplorerClub.src.DatabaseReaders.ReadersCollection
{
    public class PlayerProfileReader
    {

        private Player GetPlayerFromDatabase(string name, string surname)
        {
            SqlConnection connection = Connection.ConnectionSingleton.Connection();
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            using (SqlCommand command = new SqlCommand("Exec PlayerProfileSelection @name,@surname", connection))
            {
                SqlParameter parametrName = new SqlParameter("@name", SqlDbType.VarChar, 40);
                SqlParameter parametrSurname = new SqlParameter("@surname", SqlDbType.VarChar, 40);
                parametrName.Value = name;
                parametrSurname.Value = surname;
                command.Parameters.Add(parametrName);
                command.Parameters.Add(parametrSurname);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Player player = new Player();
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            player.Name = reader[0].ToString();
                            player.Surename = reader[1].ToString();
                            player.Age = Convert.ToInt32(reader[2]);
                            MessageBox.Show(reader[3].ToString());
                            player.Date_of_birth = DateTime.ParseExact(reader[3].ToString(), "dd.MM.yyyy H:mm:ss", CultureInfo.InvariantCulture).Date;
                            player.Email = reader[4].ToString();
                            player.PhoneNumber = reader[5].ToString();
                            player.TrainingGroup = new TrainingGroup(reader[6].ToString());
                            player.Majority = reader[7].ToString();
                            if (reader[8] != DBNull.Value)
                            {
                                player.RegistrationCard = new Card(Convert.ToInt32(reader[8]), DateTime.ParseExact(reader[9].ToString(), "dd.MM.yyyy H:mm:ss", CultureInfo.InvariantCulture).Date);
                            }
                            if (reader[10] != DBNull.Value)
                            {
                                player.Parent = new Parent(0, reader[10].ToString(), reader[11].ToString(), reader[13].ToString(), reader[12].ToString());
                            }


                        }
                        reader.Close();
                        return player;
                    }
                    else
                    {
                        return player;
                    }
                }

            }

        }
        private void GenerateBarcode(int number, PictureBox pictureBox)
        {
            Code128BarcodeDraw barCode = BarcodeDrawFactory.Code128WithChecksum;
            pictureBox.Image = barCode.Draw(number.ToString(), 60);

        }

        public void WriteProfileData(string nameSherchedPlayer, string surnameSherchedPlayer, Label playerFullName, Label playerAge, Label playerBirthDate, Label playerEmail, Label playerPhoneNumber, Label playerTgName, Label playerMajority, Label playerRegistrationCardId, Label playerRegistrationCardExpirationDate, Label parentFullName, Label parentEmail, Label parentPhoneNumber, PictureBox cardBarCode)
        {
            Player player = GetPlayerFromDatabase(nameSherchedPlayer, surnameSherchedPlayer);
            playerFullName.Text = player.Name + " " + player.Surename;
            playerAge.Text = player.Age.ToString();
            playerEmail.Text = player.Email;
            try { 
            playerBirthDate.Text = player.Date_of_birth.ToString();
            playerPhoneNumber.Text = player.PhoneNumber.ToString();
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Player with this name doesnt exist");
                return;
            }
            if (player.RegistrationCard != null)
            {
                playerRegistrationCardExpirationDate.Text = player.RegistrationCard.ExpirationDate.ToString();
                playerRegistrationCardId.Text = player.RegistrationCard.CardNumber.ToString();
                GenerateBarcode(player.RegistrationCard.CardNumber, cardBarCode);
            }
            else
            {
                playerRegistrationCardExpirationDate.Text = "-----------";
                playerRegistrationCardId.Text = "-----------";
                if (cardBarCode.Image != null)
                {
                    cardBarCode.Image.Dispose();
                }


            }
            playerMajority.Text = player.Majority;
            playerTgName.Text = player.TrainingGroup.Db_group_name;
            if (player.Parent != null)
            {
                parentFullName.Text = player.Parent.Name + " " + player.Parent.Surename;
                parentPhoneNumber.Text = player.Parent.Phone;
                parentEmail.Text = player.Parent.Email;
            }
            else
            {
                parentFullName.Text = "-----------";
                parentPhoneNumber.Text = "-----------";
                parentEmail.Text = "-----------";
            }


        }
    }
}
