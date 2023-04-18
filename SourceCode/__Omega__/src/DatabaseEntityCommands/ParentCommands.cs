using OmegaSportExplorerClub.Database_entity_class;
using OmegaSportExplorerClub.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace OmegaSportExplorerClub.src.Database_entity_commands
{
    public class ParentCommands : InterfaceCommands<Parent>
    {
        readonly SqlConnection connection = Connection.ConnectionSingleton.Connection();
        /// <summary>
        /// Method will add a new Parent instance into database
        /// </summary>
        /// <param name="obj"> Is data type of Parent</param>
        /// <returns>True if the Parent object was successfully inserted into the database, false otherwise.</returns>
        public bool ADD(Parent obj)
        {
            try
            {
                string sql = "Insert into [Parent] (Name,Surname,PhoneNumber,[E-mail]) values(@name,@surname,@phoneNumber,@email)";
                using(SqlCommand command=new SqlCommand(sql,connection))
                {
                    SqlParameter name = new SqlParameter("@name", SqlDbType.VarChar);
                    name.Value = obj.Name;
                    command.Parameters.Add(name);
                    SqlParameter surename = new SqlParameter("@surname", SqlDbType.VarChar);
                    surename.Value = obj.Surename;
                    command.Parameters.Add(surename);
                    SqlParameter phone = new SqlParameter("@phoneNumber", SqlDbType.VarChar);
                    phone.Value = obj.Phone;
                    command.Parameters.Add(phone);
                    SqlParameter email = new SqlParameter("@email", SqlDbType.VarChar);
                    email.Value = obj.Email;
                    command.Parameters.Add(email);

                    int result = Convert.ToInt32(command.ExecuteNonQuery());
                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }


                }

            }
            catch(Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Method will delete a  Parent instance from database
        /// </summary>
        /// <param name="obj">Is data type of Parent</param>
        /// <returns>True if the Parent object was successfully deleted from the database, false otherwise</returns>
        public bool DELETE(Parent obj)
        {
            try
            {
                string sql = "Delete from Parent where [Parent_ID]=@id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    SqlParameter id = new SqlParameter("@id", SqlDbType.VarChar);
                    id.Value = obj.DB_ID;
                    command.Parameters.Add(id);
                    int result = Convert.ToInt32(command.ExecuteNonQuery());
                    if (result > 0)
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
        /// Method will update Parent instance in database
        /// </summary>
        /// <param name="obj">Is data type of Parent</param>
        /// <returns>True if the Parent object was successfully updated in the database, false otherwise</returns>
        public bool UPDATE(Parent obj)
        {
            try
            {
                string sql = "Update Parent set PhoneNumber=@newPhone, [E-mail]=@nawEmail where name=@name and Surname=@surname";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    SqlParameter name = new SqlParameter("@name", SqlDbType.VarChar);
                    name.Value = obj.Name;
                    command.Parameters.Add(name);
                    SqlParameter surename = new SqlParameter("@surname", SqlDbType.VarChar);
                    surename.Value = obj.Surename;
                    command.Parameters.Add(surename);
                    SqlParameter newPhone = new SqlParameter("@newPhone", SqlDbType.VarChar);
                    newPhone.Value = obj.Phone;
                    command.Parameters.Add(newPhone);
                    SqlParameter newEmail = new SqlParameter("@nawEmail", SqlDbType.VarChar);
                    newEmail.Value = obj.Email;
                    command.Parameters.Add(newEmail);
                    int result = Convert.ToInt32(command.ExecuteNonQuery());
                    if (result > 0)
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
