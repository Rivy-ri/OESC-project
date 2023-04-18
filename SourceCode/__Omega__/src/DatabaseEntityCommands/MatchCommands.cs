using OmegaSportExplorerClub.Interfaces;
using OmegaSportExplorerClub.src.Database_entity_class;
using System.Data.SqlClient;
using System.Data;


namespace OmegaSportExplorerClub.src.Database_entity_commands
{
    public class MatchCommands : InterfaceCommands<Match>
    {
        readonly SqlConnection connection = Connection.ConnectionSingleton.Connection();
        /// <summary>
        /// Method will add a new Match record in to database
        /// </summary>
        /// <param name="obj">type of Match that we want to insert</param>
        /// <returns>True if the Match object was successfully inserted into the database, false otherwise.</returns>
        public bool ADD(Match obj)
        {
            try
            {
                using(SqlCommand command=new SqlCommand("Insert into Match_stat ([Team_Team_ID],[Oponent],[Notes],[VictoryOfOurTeam]) values(@ourTeam,@opponent,@notes,@stateOfWinn)", connection))
                {

                    SqlParameter parametrOurTeamId = new SqlParameter("@ourTeam", SqlDbType.Int);
                    SqlParameter parametrOpponentName = new SqlParameter("@opponent", SqlDbType.VarChar, 50);
                    SqlParameter parametrNotes = new SqlParameter("@notes",SqlDbType.VarChar, 150);
                    SqlParameter parameterStateOfWinn = new SqlParameter("@stateOfWinn", SqlDbType.Bit, 1);
                    parameterStateOfWinn.Value = obj.VictoryOfOurTeam;
                    parametrNotes.Value= obj.Notes;
                    parametrOpponentName.Value = obj.Oponent;
                    parametrOurTeamId.Value = obj.Team.DB_ID;
                    command.Parameters.Add(parameterStateOfWinn);
                    command.Parameters.Add(parametrOurTeamId);
                    command.Parameters.Add(parametrOpponentName);
                    command.Parameters.Add(parametrNotes);
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

            }catch (Exception)
            {
                return false;
            }
        }

        public bool DELETE(Match obj)
        {
            throw new NotImplementedException();
        }

        public bool UPDATE(Match obj)
        {
            throw new NotImplementedException();
        }
    }
}
