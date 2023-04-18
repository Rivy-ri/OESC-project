using System.Data.SqlClient;
using System.Data;
using OmegaSportExplorerClub.src.Connection;

namespace OmegaSportExplorerClub.src.DatabaseEntityCommands
{
    public class TeamAlterPlayerListCommands
    {
        private readonly SqlConnection connection;
        public TeamAlterPlayerListCommands()
        {
            connection = ConnectionSingleton.Connection();
        }
        /// <summary>
        /// Method will remove instance from connection table in database with same team id and player id
        /// </summary>
        /// <param name="teamId">Database Id of team </param>
        /// <param name="playerId">DAtabase Id of player</param>
        /// <returns>true if player was successfully removed from team false if not</returns>
        public bool RemovePlayerFromTeam(int teamId, int playerId)
        {
            string sql = "Delete from [dbo].[Player/Team] where [Player_Player_ID]=@playerId and [Team_Team_ID]=@teamId";
            try
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    SqlParameter paramentrTeamId = new SqlParameter("@teamId", SqlDbType.Int);
                    SqlParameter parametrPlayerId = new SqlParameter("@playerId", SqlDbType.Int);
                    paramentrTeamId.Value = teamId;
                    parametrPlayerId.Value = playerId;
                    command.Parameters.Add(paramentrTeamId);
                    command.Parameters.Add(parametrPlayerId);
                    if (Convert.ToInt32(command.ExecuteNonQuery()) > 0)
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
        /// Method will insert instance into connection table in database with same team id and player id
        /// </summary>
        /// <param name="teamId">Database Id of team </param>
        /// <param name="playerId">Database Id of player</param>
        /// <returns>true if player was successfully inserted into team false if not</returns>
        public bool AddPlayertoTeam(int teamId, int playerId)
        {
            string sql = "insert into [dbo].[Player/Team]([Player_Player_ID],[Team_Team_ID]) values(@playerId,@teamId)";
            try
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    SqlParameter paramentrTeamId = new SqlParameter("@teamId", SqlDbType.Int);
                    SqlParameter parametrPlayerId = new SqlParameter("@playerId", SqlDbType.Int);
                    paramentrTeamId.Value = teamId;
                    parametrPlayerId.Value = playerId;
                    command.Parameters.Add(paramentrTeamId);
                    command.Parameters.Add(parametrPlayerId);
                    if (Convert.ToInt32(command.ExecuteNonQuery()) > 0)
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
