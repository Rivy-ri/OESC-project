using OmegaSportExplorerClub.Interfaces;
using OmegaSportExplorerClub.src.Database_entity_class;
using System.Data;
using System.Data.SqlClient;

namespace OmegaSportExplorerClub.src.Database_entity_commands
{
    /// <summary>
    /// Initializes a new instance of the CardCommands class and establishes a connection to the database.
    /// </summary>
    public class CardCommands : InterfaceCommands<Card>
    {
        private readonly SqlConnection connection;
        public CardCommands()
        {
            connection = Connection.ConnectionSingleton.Connection();
        }
        /// <summary>
        /// Adds a new Card object to the database.
        /// </summary>
        /// <param name="obj">The Card object to be added.</param>
        /// <returns>True if the Card object was successfully added to the database, false otherwise.</returns>
        public bool ADD(Card obj)
        {
            string sql = "Insert into Card ([CardNumber],[ExpirationDate])values(@cardNumber,@expirationDate)";
            try
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    SqlParameter cardNumber = new SqlParameter("@cardNumber", SqlDbType.Int);
                    SqlParameter expirationDate = new SqlParameter("@expirationDate", SqlDbType.Date);
                    cardNumber.Value = obj.CardNumber;
                    expirationDate.Value=obj.ExpirationDate;
                    command.Parameters.Add(cardNumber);
                    command.Parameters.Add(expirationDate);
                    int result =Convert.ToInt32(command.ExecuteNonQuery());
                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }catch(Exception ex)
            {
                return false;
            }
            
        }
        /// <summary>
        /// Deletes an existing Card object from the database.
        /// </summary>
        /// <param name="obj">The Card object to be deleted.</param>
        /// <returns>True if the Card object was successfully deleted from the database, false otherwise.</returns>
        public bool DELETE(Card obj)
        {
            string sql = "Delete Card where [CardNumber]=@cardNumber";
            try
            {
                using(SqlCommand command=new SqlCommand(sql, connection))
                {
                    SqlParameter cardNumber = new SqlParameter("@cardNumber", SqlDbType.Int);
                    cardNumber.Value=obj.CardNumber;
                    command.Parameters.Add(cardNumber);
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
        /// Updates an existing Card object in the database.
        /// </summary>
        /// <param name="obj">The Card object to be updated.</param>
        /// <returns>True if the Card object was successfully updated in the database, false otherwise.</returns>
        public bool UPDATE(Card obj)
        {
            string sql = "Update Card set ExpirationDate=@newExpiretionDate where [Card_Id]=@cardId";
            try
            {
                using(SqlCommand command=new SqlCommand(sql, connection))
                {
                    SqlParameter cardNumber = new SqlParameter("@cardId", SqlDbType.Int);
                    SqlParameter newExpirationDate = new SqlParameter("@newExpiretionDate", SqlDbType.Date);
                    cardNumber.Value = obj.DB_ID;
                    newExpirationDate.Value = obj.ExpirationDate;
                    command.Parameters.Add(cardNumber);
                    command.Parameters.Add(newExpirationDate);
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
    }
}
