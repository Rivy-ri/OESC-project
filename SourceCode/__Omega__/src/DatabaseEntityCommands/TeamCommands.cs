using OmegaSportExplorerClub.Interfaces;
using OmegaSportExplorerClub.src.Database_entity_class;
using System.Data;
using System.Data.SqlClient;

namespace OmegaSportExplorerClub.src.Database_entity_commands
{
    public class TeamCommands : InterfaceCommands<Team>
    {
        private readonly SqlConnection connection;
        public TeamCommands()
        {
            connection = Connection.ConnectionSingleton.Connection();
        }
        /// <summary>
        /// Method will insert into database new instance of Team
        /// </summary>
        /// <param name="obj">object of class Team that will be inserted</param>
        /// <returns>true if new instance of Team was added in to database false if not </returns>
        public bool ADD(Team obj)
        {
            string sql = "Insert into team (name) values (@name)";
            try
            {
                using (SqlCommand command= new SqlCommand(sql,connection))
                {
                    SqlParameter name = new SqlParameter("@name", SqlDbType.VarChar,20);
                    name.Value = obj.Name;
                    command.Parameters.Add(name);
                    var result=Convert.ToInt32(command.ExecuteNonQuery());
                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }catch (Exception)
            {
                return false;
            }
           
        }
        /// <summary>
        /// Method will delete from database instance of Team
        /// </summary>
        /// <param name="obj">object of class Team that will be deleted</param>
        /// <returns>true if instance was deleted from database false if not</returns>
        public bool DELETE(Team obj)
        {
            string sql = "Delete from team where name=@name";
            try
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    SqlParameter name = new SqlParameter("@name",SqlDbType.VarChar);
                    name.Value = obj.Name;
                    command.Parameters.Add(name);
                    var result = Convert.ToInt32(command.ExecuteNonQuery());
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
        /// Method will update in database instance of Team by name
        /// </summary>
        /// <param name="obj">object of class Team that will be updated</param>
        /// <returns>true if instance was updated in database false if not</returns>
        public bool UPDATE(Team obj)
        {
            string sql = "Update team set name=@newName where name=@oldName";
            try
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    SqlParameter newName = new SqlParameter("@newName", SqlDbType.VarChar);
                    newName.Value = obj.Name;
                    command.Parameters.Add(newName);
                    SqlParameter oldName = new SqlParameter("@oldName",SqlDbType.VarChar);
                    oldName.Value = obj.UpdateName;
                    command.Parameters.Add(oldName);
                    var result = Convert.ToInt32(command.ExecuteNonQuery());
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
