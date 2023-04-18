using OmegaSportExplorerClub.Database_entity_class;
using OmegaSportExplorerClub.Interfaces;
using OmegaSportExplorerClub.src.Connection;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace OmegaSportExplorerClub.Database_entity_commands
{
    public class TrainingGroupCommands : InterfaceCommands<TrainingGroup>
    {
        readonly SqlConnection connection = ConnectionSingleton.Connection();
        /// <summary>
        /// Method will add new training group in to database
        /// </summary>
        /// <param name="obj">object of class TrainingGroup will be inserted</param>
        /// <returns>true if instance was successfully inserted into  database false if not</returns>
        public bool ADD(TrainingGroup obj)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("Insert into [dbo].[TrainingGroup]([Coach_Coach_ID],[Type_of_group_Type_of_group_ID],Name) values(@coach_id,@type_ide,@name)", connection))
                {
                    SqlParameter coach = new SqlParameter("@coach_id", SqlDbType.Int);
                    SqlParameter type = new SqlParameter("@type_ide", SqlDbType.Int);
                    SqlParameter name = new SqlParameter("@name", SqlDbType.VarChar);
                    coach.Value = Convert.ToInt32(obj.Db_coach);
                    type.Value = Convert.ToInt32(obj.Db_type);
                    name.Value = obj.Db_group_name;
                    cmd.Parameters.Add(coach);
                    cmd.Parameters.Add(type);
                    cmd.Parameters.Add(name);
                    var result = cmd.ExecuteNonQuery();
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
        ///  Method will delete existing training group from database
        /// </summary>
        /// <param name="obj">object of class TrainingGroup that will be deleted</param>
        /// <returns>true if instance was successfully deleted from  database false if not</returns>
        public bool DELETE(TrainingGroup obj)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("Delete [dbo].[TrainingGroup] where Name=@name", connection))
                {
                    SqlParameter name = new SqlParameter("@name", System.Data.SqlDbType.VarChar);
                    name.Value = obj.Db_group_name;
                    cmd.Parameters.Add(name);
                    var result = cmd.ExecuteNonQuery();
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
        /// Method will update existing training group in database
        /// </summary>
        /// <param name="obj">object of class TrainingGroup that will be updated</param>
        /// <returns>rue if instance was successfully updated in database false if not</returns>
        public bool UPDATE(TrainingGroup obj)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE TrainingGroup set [Type_of_group_Type_of_group_ID] =@type, [Coach_Coach_ID]=@coach where Name=@name", connection))
                {
                    SqlParameter name = new SqlParameter("@name", System.Data.SqlDbType.VarChar);
                    SqlParameter type = new SqlParameter("@type", System.Data.SqlDbType.Int);
                    SqlParameter coach = new SqlParameter("@coach", System.Data.SqlDbType.Int);
                    name.Value = obj.Db_group_name;
                    coach.Value = obj.Db_coach;
                    type.Value = obj.Db_type;
                    cmd.Parameters.Add(name);
                    cmd.Parameters.Add(type);
                    cmd.Parameters.Add(coach);
                    var result = cmd.ExecuteNonQuery();
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
