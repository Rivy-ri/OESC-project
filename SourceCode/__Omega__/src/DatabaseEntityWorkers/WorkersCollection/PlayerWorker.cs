using System.Transactions;
using OmegaSportExplorerClub.Database_entity_class;
using OmegaSportExplorerClub.Interfaces;
using OmegaSportExplorerClub.src.Database_entity_class;
using System.Data.SqlClient;
using OmegaSportExplorerClub.src.Connection;

namespace OmegaSportExplorerClub
{
    public class PlayerWorker
    {
        private readonly InterfaceCommands<Player> palayerCommands;
        private readonly InterfaceCommands<Card> cardCommands;
        private readonly InterfaceCommands<Parent> parentCommands;
        private SqlConnection connection = ConnectionSingleton.Connection();

        public PlayerWorker(InterfaceCommands<Player> PalayerCommands, InterfaceCommands<Card> CardCommands, InterfaceCommands<Parent> ParentCommands)
        {
            palayerCommands = PalayerCommands;
            cardCommands = CardCommands;
            parentCommands = ParentCommands;
        }
        /// <summary>
        /// Method will insert all parts of player instance in to database in transaction, then notify user how it ended
        /// </summary>
        /// <param name="newPlayer">object of Player class for insert</param>
        /// <param name="newParent">object of Parent class that is parent of player</param>
        /// <param name="newCard">object of Card class that belong to player</param>
        /// <param name="playerMajority">string that represent players position </param>
        /// <param name="trainingGroup">>string that represent players training group</param>
        public void CreatePlayer(Player newPlayer, Parent newParent, Card newCard, string playerMajority, string trainingGroup)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    newPlayer.Majority = GetIdMajority(playerMajority).ToString();
                    newPlayer.TrainingGroup = new TrainingGroup() { DB_ID = GetTrainingGroup(trainingGroup) };
                    if (newParent != null)
                    {
                        if (SqlInjectionCheck.Check_text(newParent.Name) || SqlInjectionCheck.Check_text(newParent.Surename) || SqlInjectionCheck.Check_text(newParent.Email))
                        {
                            throw new Exception();
                        }
                        var resultParent = parentCommands.ADD(newParent);
                        var parentID = GetLastInsertedParentId();
                        if (resultParent == false)
                        {
                            throw new Exception();
                        }
                        newPlayer.Parent = new Parent()
                        {
                            DB_ID = parentID,
                        };

                    }
                    if (newCard != null)
                    {
                        var resultCard = cardCommands.ADD(newCard);
                        var CardID = GetLastInsertedCardId();
                        if (resultCard == false)
                        {
                            throw new Exception();
                        }
                        newPlayer.RegistrationCard = new Card() { DB_ID = CardID };
                    }
                    if (SqlInjectionCheck.Check_text(newPlayer.Name) || SqlInjectionCheck.Check_text(newPlayer.Surename) || SqlInjectionCheck.Check_text(newPlayer.Email))
                    {
                        throw new Exception();
                    }
                    var resultPlayer = palayerCommands.ADD(newPlayer);
                    if (resultPlayer == true)
                    {
                        MessageBox.Show("Creation of new player was successful");
                        scope.Complete();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Creation of new player failed");
                    scope.Dispose();
                }
            }
        }
        /// <summary>
        /// Method will delete all parts of player instance in  database in transaction, then notify user how it ended
        /// </summary>
        /// <param name="palyerName">string name of player that we want to delete</param>
        /// <param name="playerSurname">string surname of player that we want to delete</param>
        /// <param name="DeleteParent">bool type if we want to delete a Parent</param>
        public void DeletePlayer(string palyerName, string playerSurname, bool DeleteParent)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    if (SqlInjectionCheck.Check_text(palyerName) || SqlInjectionCheck.Check_text(playerSurname))
                    {
                        throw new Exception("Delete player failed");
                    }

                    Player deleteInstance = new Player()
                    {
                        Name = palyerName,
                        Surename = playerSurname,
                    };

                    Parent parent = new Parent()
                    {
                        DB_ID = GetParentIdFromPlayer(palyerName, playerSurname),
                    };
                    var resultPlayer = palayerCommands.DELETE(deleteInstance);
                    bool resultParent = false;
                    if (DeleteParent == true && parent.DB_ID > 0)
                    {
                        resultParent = parentCommands.DELETE(parent);
                    }
                    else
                    {
                        DeleteParent = false;
                    }

                    if (resultPlayer == true && resultParent == true || resultPlayer == true && DeleteParent == false && parent.DB_ID<0)
                    {
                        MessageBox.Show("Deleting of player was successful");
                        scope.Complete();
                    }
                    else
                    {
                        throw new Exception("Delete player failed");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    scope.Dispose();
                }
            }
        }
        /// <summary>
        /// Method will updated selected parts of player instance in  database in transaction, then notify user how it ended
        /// </summary>
        /// <param name="palyerName">name of player that we want to update</param>
        /// <param name="playerSurname">surname of player that we want to update</param>
        /// <param name="playerNewEmail">new email of player</param>
        /// <param name="playerNewPhone">new phone number of player</param>
        /// <param name="dateTime">new expiration date for players card</param>
        /// <param name="cardExpirationChange">bool if we want to update expiration date of players card</param>
        public void UpdatePlayer(string palyerName, string playerSurname, string playerNewEmail, string playerNewPhone, DateTime dateTime, bool cardExpirationChange)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    if (cardExpirationChange == false)
                    {
                        if (SqlInjectionCheck.Check_text(palyerName) || SqlInjectionCheck.Check_text(playerSurname) || SqlInjectionCheck.Check_text(playerNewEmail))
                        {
                            throw new Exception();
                        }
                        Player player = new Player()
                        {
                            Name = palyerName,
                            Surename = playerSurname,
                            Email = playerNewEmail,
                            PhoneNumber = playerNewPhone,
                        };
                        var result = palayerCommands.UPDATE(player);
                        if (result == true)
                        {
                            MessageBox.Show("Update of player was successful");
                            scope.Complete();
                        }
                        else
                        {
                            throw new Exception();

                        }
                    }
                    else
                    {
                        int id = GetCardId(palyerName, playerSurname);
                        Card card = new Card()
                        {
                            DB_ID = id,
                            ExpirationDate = dateTime
                        };
                        bool result = cardCommands.UPDATE(card);
                        if (result == true)
                        {
                            MessageBox.Show("Update of player was successful");
                            scope.Complete();
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }


                }
                catch (Exception)
                {
                    MessageBox.Show("Update of player failed");
                    scope.Dispose();
                }

            }

        }
        /// <summary>
        /// Method will get an majority id from database
        /// </summary>
        /// <param name="majority">string name of majority</param>
        /// <returns></returns>
        private int GetIdMajority(string majority)
        {

            using (SqlCommand command = new SqlCommand("select Majority_ID from Majority where Name=@majority", connection))
            {

                SqlParameter parameter = new SqlParameter("@majority", System.Data.SqlDbType.VarChar);
                parameter.Value = majority;
                command.Parameters.Add(parameter);
                int id = Convert.ToInt32(command.ExecuteScalar());
                return id;

            }
        }
        /// <summary>
        /// Method will get an training group id from database
        /// </summary>
        /// <param name="trainingGroupName">string name of training group</param>
        /// <returns></returns>
        private int GetTrainingGroup(string trainingGroupName)
        {
            using (SqlCommand command = new SqlCommand("Select [TrainingGroup_ID] from [dbo].[TrainingGroup] where Name=@trainingGroupName", connection))
            {
                SqlParameter parameter = new SqlParameter("@trainingGroupName", System.Data.SqlDbType.VarChar);
                parameter.Value = trainingGroupName;
                command.Parameters.Add(parameter);
                int id = Convert.ToInt32(command.ExecuteScalar());
                return id;

            }

        }
        /// <summary>
        /// Method will return last inserted Parent Id
        /// </summary>
        /// <returns>int Last Parent inserted id</returns>
        private int GetLastInsertedParentId()
        {
            string sql = "Select Max([Parent_ID]) from [dbo].[Parent]";
            SqlCommand command = new SqlCommand(sql, connection);
            return Convert.ToInt32(command.ExecuteScalar());
        }
        /// <summary>
        ///  Method will return last inserted Card Id
        /// </summary>
        /// <returns> int Last Card inserted id</returns>
        private int GetLastInsertedCardId()
        {
            SqlCommand command = new SqlCommand("Select Max(Card_ID) from Card", connection);
            return Convert.ToInt32(command.ExecuteScalar());

        }
        /// <summary>
        ///  Method will return Parents id by name and surname
        /// </summary>
        /// <param name="playerName">searched Parent name</param>
        /// <param name="playerSurname">searched Parent surname</param>
        /// <returns>int id of searched Parent</returns>
        private int GetParentIdFromPlayer(string playerName, string playerSurname)
        {
            using (SqlCommand command = new SqlCommand("Select Fk_parent from Player where name=@name and surname=@surname", connection))
            {
                SqlParameter parametrName = new SqlParameter("@name", System.Data.SqlDbType.VarChar);
                SqlParameter parametrLastname = new SqlParameter("@surname", System.Data.SqlDbType.VarChar);
                parametrName.Value = playerName;
                parametrLastname.Value = playerSurname;
                command.Parameters.Add(parametrName);
                command.Parameters.Add(parametrLastname);
                var execution = command.ExecuteScalar();
                if (execution is DBNull || execution is null)
                {
                    return -1;
                }
                int id = Convert.ToInt32(execution);
                return id;

            }
        }
        /// <summary>
        /// Method will return Card id by name and surname of player
        /// </summary>
        /// <param name="playerName">searched Player name</param>
        /// <param name="playerSurname">searched Player surname</param>
        /// <returns>int id of searched Players card</returns>
        private int GetCardId(string playerName, string playerSurname)
        {
            using (SqlCommand command = new SqlCommand("Select [Card_Card_Id] from Player where name=@name and surname=@surname", connection))
            {
                SqlParameter parametrName = new SqlParameter("@name", System.Data.SqlDbType.VarChar);
                SqlParameter parametrLastname = new SqlParameter("@surname", System.Data.SqlDbType.VarChar);
                parametrName.Value = playerName;
                parametrLastname.Value = playerSurname;
                command.Parameters.Add(parametrName);
                command.Parameters.Add(parametrLastname);
                var execution = command.ExecuteScalar();
                if (execution == DBNull.Value)
                {
                    return -1;
                }
                int id = Convert.ToInt32(execution);
                return id;
            }
        }
    }
}
