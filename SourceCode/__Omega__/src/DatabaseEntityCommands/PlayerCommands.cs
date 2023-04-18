using OmegaSportExplorerClub.Database_entity_class;
using OmegaSportExplorerClub.Interfaces;
using OmegaSportExplorerClub.src.Connection;
using System.Data.SqlClient;
using System.Data;



namespace OmegaSportExplorerClub.src.Database_entity_commands
{
    internal class PlayerCommands : InterfaceCommands<Player>
    {
        readonly SqlConnection connection = ConnectionSingleton.Connection();
        /// <summary>
        /// Method represent insert into command for inserting instance of player to db so that db remained consistent
        /// </summary>
        /// <param name="obj">Object of Player type<</param>
        /// <returns>true if command was successful false if not</returns>
        public bool ADD(Player obj)
        {

            string sql = "Insert into Player (Name,Surname,Phone,[Majority_ID],[Tg_TrainingGroup_ID],[E-mail],[FK_parent],[Card_Card_Id],[BirthDate])values (@name,@lastname,@phonenumber,@majority,@training_group,@email,@parentId,@cardId,@birthDate)";
            try
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    SqlParameter name = new SqlParameter("@name", SqlDbType.VarChar);
                    name.Value = obj.Name;
                    command.Parameters.Add(name);
                    SqlParameter lastname = new SqlParameter("@lastname", SqlDbType.VarChar);
                    lastname.Value = obj.Surename;
                    command.Parameters.Add(lastname);
                    SqlParameter phone_number = new SqlParameter("@phonenumber", SqlDbType.VarChar);
                    phone_number.Value = obj.PhoneNumber;
                    command.Parameters.Add(phone_number);
                    SqlParameter majority = new SqlParameter("@majority", SqlDbType.VarChar);
                    majority.Value = obj.Majority;
                    command.Parameters.Add(majority);
                    SqlParameter email = new SqlParameter("@email", SqlDbType.VarChar);
                    email.Value = obj.Email;
                    command.Parameters.Add(email);
                    SqlParameter trainingGroup = new SqlParameter("@training_group", SqlDbType.VarChar);
                    trainingGroup.Value = obj.TrainingGroup.DB_ID;
                    command.Parameters.Add(trainingGroup);
                    SqlParameter parent = new SqlParameter("@parentId", SqlDbType.Int);
                    try
                    {
                        parent.Value = obj.Parent.DB_ID;
                    }
                    catch (NullReferenceException)
                    {
                        parent.Value = DBNull.Value;
                    }
                    command.Parameters.Add(parent);

                    SqlParameter card = new SqlParameter("@cardId", SqlDbType.Int);
                    try
                    {
                        card.Value = obj.RegistrationCard.DB_ID;
                    }
                    catch (NullReferenceException)
                    {
                        card.Value = DBNull.Value;
                    }
                    command.Parameters.Add(card);
                    SqlParameter birthDate = new SqlParameter("@birthDate", SqlDbType.Date);
                    birthDate.Value = obj.Date_of_birth;
                    command.Parameters.Add(birthDate);
                    var result = Convert.ToInt32(command.ExecuteNonQuery());
                    if (result != 0)
                    {
                        return true;
                    }
                    else
                    {

                        return false;

                    }
                }

            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Method represent delete command for deleting instance of player from db so that db remained consistent
        /// </summary>
        /// <param name="obj">Object of Player type</param>
        /// <returns>true if command was successful false if not</returns>
        public bool DELETE(Player obj)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("Delete from Player where Name=@name and Surname=@surname", connection))
                {
                    SqlParameter name = new SqlParameter("@name", SqlDbType.VarChar);
                    SqlParameter surename = new SqlParameter("@surname", SqlDbType.VarChar);
                    name.Value = obj.Name;
                    surename.Value = obj.Surename;
                    command.Parameters.Add(name);
                    command.Parameters.Add(surename);
                    var result = Convert.ToInt32(command.ExecuteNonQuery());
                    if (result != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }

            }
            catch (Exception)
            {
                return false;
            }

        }
        /// <summary>
        /// Method represent update command for updating instance of player from db so that db remained consistent
        /// </summary>
        /// <param name="obj"> Object of Player type </param>
        /// <returns>true if command was successful false if not </returns>
        public bool UPDATE(Player obj)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("Update player set [E-mail]=@new_email, Phone=@new_phone where Name=@name and surname=@surname", connection))
                {
                    SqlParameter new_email = new SqlParameter("@new_email", SqlDbType.VarChar);
                    SqlParameter new_phone = new SqlParameter("@new_phone", SqlDbType.VarChar);
                    SqlParameter name = new SqlParameter("@name", SqlDbType.VarChar);
                    SqlParameter surname = new SqlParameter("@surname", SqlDbType.VarChar);
                    new_email.Value = obj.Email;
                    new_phone.Value = obj.PhoneNumber;
                    name.Value = obj.Name;
                    surname.Value = obj.Surename;
                    command.Parameters.Add(new_email);
                    command.Parameters.Add(new_phone);
                    command.Parameters.Add(name);
                    command.Parameters.Add(surname);
                    var result = Convert.ToInt32(command.ExecuteNonQuery());
                    if (result != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
