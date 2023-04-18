using OmegaSportExplorerClub.src.Connection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSportExplorerClub.src.User.VerifyRegistrationCommands
{
    internal class VerifyCodeInDatabase : Interfaces.InterfaceVerificationCommand
    {
        public VerifyCodeInDatabase() { }
        public  bool verify(string code)
        {
            SqlConnection connection = ConnectionSingleton.Connection();
            string sql = "Select count(verification_code) from [AplicationUser] where verification_code=@test_code";
            try
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    SqlParameter test_code = new SqlParameter("@test_code", System.Data.SqlDbType.VarChar, 6);
                    test_code.Value = code;
                    command.Parameters.Add(test_code);
                    int result = Convert.ToInt32(command.ExecuteScalar());
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
            catch (Exception)
            {
                return true;
            }
        }
    }
}
