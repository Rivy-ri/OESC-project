using MaterialSkin.Controls;
using OmegaSportExplorerClub.Interfaces;
using OmegaSportExplorerClub.src.Connection;
using OmegaSportExplorerClub.src.Database_entity_class;
using OmegaSportExplorerClub.src.DatabaseEntityCommands;
using System.Data.SqlClient;
using System.Transactions;

namespace OmegaSportExplorerClub.src.DatabaseEntityWorkers.WorkersCollection
{
    /// <summary>
    /// Class to handle operations related to a sports team.
    /// </summary>
    public class TeamWorker
    {
        private readonly InterfaceCommands<Team> teamCommands;
        private readonly TeamAlterPlayerListCommands teamPlayerAlter;
        private readonly InterfaceCommands<Match> matchCommands;
        /// <summary>
        /// Constructor for the TeamWorker class.
        /// </summary>
        /// <param name="TeamCommands">InterfaceCommands object to interact with the Team entity</param>
        /// <param name="teamAlterPlayers">TeamAlterPlayerListCommands object to interact with the TeamPlayerAlter entity</param>
        /// <param name="matchCommands">InterfaceCommands object to interact with the Match entity</param>
        public TeamWorker(InterfaceCommands<Team> TeamCommands, TeamAlterPlayerListCommands teamAlterPlayers, InterfaceCommands<Match> matchCommands)
        {
            teamCommands = TeamCommands;
            teamPlayerAlter = teamAlterPlayers;
            this.matchCommands = matchCommands;
        }
        /// <summary>
        /// Method to create a new team.
        /// </summary>
        /// <param name="teamName">The name of the team to create.</param>
        public void CreateTeam(string teamName)
        {
            try 
            {
                if (SqlInjectionCheck.Check_text(teamName))
                {
                    throw new Exception();
                }
                Team team = new Team()
                {
                    Name = teamName,
                };
                bool result = teamCommands.ADD(team);
                if (result == true)
                {
                    MessageBox.Show("Creation of new team was successful");
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Creation of new team failed");
            }
        }
        /// <summary>
        /// Method to update the name of an existing team.
        /// </summary>
        /// <param name="teamOldName">The current name of the team.</param>
        /// <param name="teamNewName">The new name to set for the team.</param>
        public void UpdateTeam(string teamOldName, string teamNewName)
        {
            try { 
            if (SqlInjectionCheck.Check_text(teamOldName) || SqlInjectionCheck.Check_text(teamNewName))
            {
                throw new Exception();
            }
            Team team = new Team(teamNewName, teamOldName);
            bool result = teamCommands.UPDATE(team);
            if (result)
            {
                MessageBox.Show("Update of team was successful");
            }
            else
            {
                    throw new Exception();
            }
            }
            catch (Exception)
            {
                MessageBox.Show("Update of team failed");
            }

        }
        /// <summary>
        /// Method to delete a team.
        /// </summary>
        /// <param name="teamName">The name of the team to delete.</param>
        public void DeleteTeam(string teamName)
        {
            try { 
            if (SqlInjectionCheck.Check_text(teamName))
            {
                throw new Exception();
            }
            Team team = new Team()
            {
                Name = teamName,
            };
            bool result = teamCommands.DELETE(team);
            if (result)
            {
                MessageBox.Show("Delete of team was successful");
            }
            else
            {
                throw new Exception();
            }
            }
            catch (Exception)
            {
                MessageBox.Show("Delete of team failed");
            }

        }
        /// <summary>
        /// Method will alter players that belongs to that team base on difference of original and new list in transaction and then inform user  
        /// </summary>
        /// <param name="listBox">new list of players in team</param>
        /// <param name="originaList">original list of players that belong to team</param>
        /// <param name="teamName">team name</param>
        public void AlterTeamPlayers(MaterialListBox listBox, List<string> originaList, string teamName)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    List<string> newList = new List<string>();
                    foreach (var item in listBox.Items)
                    {
                        newList.Add(item.Text);
                    }
                    List<string> addPlayersToTeam = newList.Except(originaList).ToList();
                    List<string> removePlayersFromTeam = originaList.Except(newList).ToList();
                    int teamId = GetTeamIdByName(teamName);

                    foreach (string item in addPlayersToTeam)
                    {
                        if (teamPlayerAlter.AddPlayertoTeam(teamId, GetPlayerIdByName(item)) == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new Exception("players failed");
                        }

                    }
                    foreach (string item in removePlayersFromTeam)
                    {
                        if (teamPlayerAlter.RemovePlayerFromTeam(teamId, GetPlayerIdByName(item)) == true)
                        {
                            continue;
                        }
                        else
                        {
                            throw new Exception("players failed");
                        }
                    }
                    MessageBox.Show("Altering of team players was successful");



                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    MessageBox.Show("Altering of team"+" "+ex.Message);
                }
            }


        }
        /// <summary>
        /// Adds a new match record to the database
        /// </summary>
        /// <param name="team">The team that played the match</param>
        /// <param name="opponent">The name of the opposing team</param>
        /// <param name="notes">Any notes about the match</param>
        /// <param name="winner">A flag indicating whether the team won or lost the match</param>
        public void addMatch(Team team, string opponent, string notes, bool winner)
        {
            try { 
                if (SqlInjectionCheck.Check_text(opponent) || SqlInjectionCheck.Check_text(notes))
                {
                    throw new Exception();
                }
                team.DB_ID = GetTeamIdByName(team.Name);
                Match match = new Match(team, opponent, notes, winner);
                if (matchCommands.ADD(match) == true)
                {
                    MessageBox.Show("Adding a new match record was successful");
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Adding a new match record failed");
            }


        }
        /// <summary>
        /// Gets the ID of a team by name
        /// </summary>
        /// <param name="teamName">The name of the team to search for</param>
        /// <returns>The ID of the team</returns>
        private int GetTeamIdByName(string teamName)
        {
            SqlConnection connection = Connection.ConnectionSingleton.Connection();
            using (SqlCommand command = new SqlCommand("Select [dbo].[Team].Team_ID from Team where Team.Name=@teamName", connection))
            {
                SqlParameter parameter = new SqlParameter("@teamName", System.Data.SqlDbType.VarChar, 20);
                parameter.Value = teamName;
                command.Parameters.Add(parameter);
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
        /// <summary>
        /// Gets the ID of a player by name
        /// </summary>
        /// <param name="playerFullName">The full name of the player to search for</param>
        /// <returns>The ID of the player</returns>
        private int GetPlayerIdByName(string playerFullName)
        {
            SqlConnection connection = Connection.ConnectionSingleton.Connection();
            using (SqlCommand command = new SqlCommand("Select Player.Player_ID from Player where Player.Name+' '+Player.Surname=@fullName", connection))
            {
                SqlParameter parameter = new SqlParameter("@fullName", System.Data.SqlDbType.VarChar);
                parameter.Value = playerFullName;
                command.Parameters.Add(parameter);
                var result = Convert.ToInt32(command.ExecuteScalar());
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return -1;
                }
            }

        }

    }
}
