using System.Data.SqlClient;



namespace OmegaSportExplorerClub.src.User.VerifyRegistrationCommands
{
    internal class VerifyEmailInDatabase : Interfaces.InterfaceVerificationCommand
    {
        public VerifyEmailInDatabase() { }
        public  bool verify(string email)
        {
            SqlConnection connection = Connection.ConnectionSingleton.Connection();
            string sql = "Select Count(email) from [AplicationUser] where email=@email";
            try
            {
                using(SqlCommand cmd = new SqlCommand(sql,connection))
                {
                    SqlParameter email_parametr=new SqlParameter("@email",System.Data.SqlDbType.VarChar);
                    email_parametr.Value = email;
                    cmd.Parameters.Add(email_parametr);
                    var result=Convert.ToInt32 (cmd.ExecuteScalar());
                    if (result == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return true;
            }
        }
    }
}
