using System.Data.SqlClient;
using System.Data;
using OmegaSportExplorerClub.Interfaces;
using OmegaSportExplorerClub.Database_entity_class;
using OmegaSportExplorerClub.src.Connection;

namespace OmegaSportExplorerClub.Database_entity_commands
{
    public class CoachCommands : InterfaceCommands<Coach>
    {
      
        private readonly SqlConnection connection;
        /// <summary>
        /// Initializes a new instance of the CoachCommands class.
        /// </summary>
        public CoachCommands()
        {
            connection = ConnectionSingleton.Connection();

        }

        /// <summary>
        /// Inserts a new Coach object into the database.
        /// </summary>
        /// <param name="obj">The Coach object to insert.</param>
        /// <returns>true if the insertion was successful; otherwise, false.</returns>
        public bool ADD(Coach obj)
        {
            try
            {
                if (obj.DB_Phone != null)
                {
                    using (SqlCommand cmd = new SqlCommand("Insert into Coach(Name,Surname,Phone,[E-mail]) values (@name,@surename,@phone,@email)", connection))
                    {
                        SqlParameter name_para = new SqlParameter("@name", SqlDbType.VarChar);
                        name_para.Value = obj.DB_Name;
                        SqlParameter surename_para = new SqlParameter("@surename", SqlDbType.VarChar);
                        surename_para.Value = obj.DB_Surename;
                        SqlParameter email_para = new SqlParameter("@email", SqlDbType.VarChar);
                        email_para.Value = obj.DB_Email;
                        SqlParameter phone_para = new SqlParameter("@phone", SqlDbType.VarChar);
                        phone_para.Value = obj.DB_Phone;
                        cmd.Parameters.Add(name_para);
                        cmd.Parameters.Add(surename_para);
                        cmd.Parameters.Add(email_para);
                        cmd.Parameters.Add(phone_para);
                        var result = Convert.ToInt32(cmd.ExecuteNonQuery());
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
                else
                {
                    using (SqlCommand cmd = new SqlCommand("Insert into Coach(Name,Surname,[E-mail]) values (@name,@surename,@email)", connection))
                    {
                        SqlParameter name_para = new SqlParameter("@name", SqlDbType.VarChar);
                        name_para.Value = obj.DB_Phone;
                        SqlParameter surename_para = new SqlParameter("@surename", SqlDbType.VarChar);
                        surename_para.Value = obj.DB_Surename;
                        SqlParameter email_para = new SqlParameter("@email", SqlDbType.VarChar);
                        email_para.Value = obj.DB_Email;
                        cmd.Parameters.Add(name_para);
                        cmd.Parameters.Add(surename_para);
                        cmd.Parameters.Add(email_para);
                        var result = Convert.ToInt32(cmd.ExecuteNonQuery());
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

            }
            catch (Exception)
            {
                return false;

            }
        }
        /// <summary>
        /// Deletes a Coach object from the database.
        /// </summary>
        /// <param name="obj">The Coach object to delete.</param>
        /// <returns>true if the deletion was successful; otherwise, false.</returns>
        public bool DELETE(Coach obj)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("Delete Coach where Name=@name and Surname=@surname", connection))
                {
                    SqlParameter name = new SqlParameter("@name", SqlDbType.VarChar);
                    SqlParameter surname = new SqlParameter("@surname", SqlDbType.VarChar);
                    name.Value = obj.DB_Name;
                    surname.Value = obj.DB_Surename;
                    cmd.Parameters.Add(name);
                    cmd.Parameters.Add(surname);
                    var result = Convert.ToInt32(cmd.ExecuteNonQuery());
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
        /// Updates a Coach object in the database.
        /// </summary>
        /// <param name="obj">The Coach object to update.</param>
        /// <returns>true if the update was successful; otherwise, false.</returns>
        public bool UPDATE(Coach obj)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE Coach set [E-mail]=@newEmail, Phone=@newPhone where Name=@name and Surname=@surname", connection))
                {
                    
                    SqlParameter new_email = new SqlParameter("@newEmail", SqlDbType.VarChar);
                    new_email.Value = obj.DB_Email;
                    SqlParameter new_phone = new SqlParameter("@newPhone", SqlDbType.VarChar);
                    new_phone.Value = obj.DB_Phone;
                    SqlParameter name = new SqlParameter("@name", SqlDbType.VarChar);
                    name.Value = obj.DB_Name;
                    SqlParameter surename = new SqlParameter("@surname", SqlDbType.VarChar);
                    surename.Value = obj.DB_Surename;
                    cmd.Parameters.Add(new_phone);
                    cmd.Parameters.Add(new_email);
                    cmd.Parameters.Add(name);
                    cmd.Parameters.Add(surename);
                    var result =Convert.ToInt32(cmd.ExecuteNonQuery());

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
        /// Retrieves the ID of a Coach object from the database.
        /// </summary>
        /// <param name="coach">The Coach object to retrieve the ID for.</param>
        /// <returns>The ID of the Coach object.</returns>
        public static int Coach_Get_ID(Coach coach)
        {
            int id;
            SqlConnection connection = ConnectionSingleton.Connection();
            using (SqlCommand cmd = new SqlCommand("Select Coach.Coach_ID From Coach WHERE Name=@name and Surname=@surename", connection))
            {
                SqlParameter name = new SqlParameter("@name", SqlDbType.VarChar);
                SqlParameter surename = new SqlParameter("@surename", SqlDbType.VarChar);
                name.Value = coach.DB_Name;
                surename.Value = coach.DB_Surename;
                cmd.Parameters.Add(name);
                cmd.Parameters.Add(surename);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            id = Convert.ToInt32(reader[0].ToString());
                            return id;
                        }

                        reader.Close();

                    }
                    else
                    {
                        return -1;

                    }

                }
                return -1;

            }




        }
    }
}
