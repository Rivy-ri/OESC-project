
using System.Data.SqlClient;

namespace OmegaSportExplorerClub.src.User.VerifyRegistrationCommands
{
    internal class VerifyUserNameInDatabase : Interfaces.InterfaceVerificationCommand
    {
        public VerifyUserNameInDatabase() { }
        public bool verify(string username)
        {
            SqlConnection connection = Connection.ConnectionSingleton.Connection();
            string sql = "Select count(name) from [AplicationUser] where name=@username";
            try
            {
                using(SqlCommand command = new SqlCommand(sql,connection)) 
                { 
                    SqlParameter username_parametr= new SqlParameter("@username",System.Data.SqlDbType.VarChar);
                    username_parametr.Value = username;
                    command.Parameters.Add(username_parametr);
                    var result=Convert.ToInt32( command.ExecuteScalar());
                    if(result == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
