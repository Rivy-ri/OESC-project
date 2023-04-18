using OmegaSportExplorerClub.Database_entity_class;
using OmegaSportExplorerClub.Interfaces;
namespace OmegaSportExplorerClub.src.Database_entity_class
{
    /// <summary>
    /// Represents a sports team with a name, a unique ID, and a list of players.
    /// </summary>
    public class Team : InterfaceId
    {
        private string name;
        private int db_id;
        private List<Player> players_list;
        private string updateName=null;

        /// <summary>
        /// Initializes a new instance of the Team class with the specified name, ID, and list of players.
        /// </summary>
        /// <param name="name">The name of the team.</param>
        /// <param name="dB_ID">The unique ID of the team.</param>
        /// <param name="players_list">The list of players on the team.</param>
        public Team(string name, int dB_ID, List<Player> players_list)
        {
            Name = name;
            DB_ID = dB_ID;
            Players_list = players_list;
        }
        /// <summary>
        /// Initializes a new instance of the Team class with the specified new name and old name.
        /// </summary>
        /// <param name="new_name">The new name of the team.</param>
        /// <param name="old_name">The old name of the team to update.</param>
        public Team(string new_name, string old_name)
        {
            Name = new_name;
            updateName = old_name;
        }
        /// <summary>
        /// Initializes a new instance of the Team class with default values.
        /// </summary>
        public Team()
        {
            
        }

        public string Name { get => name; set => name = value; }
        public int DB_ID { get => db_id; set => db_id = value; }
        public List<Player> Players_list { get => players_list; set => players_list = value; }
        public string UpdateName { get => updateName; set => updateName = value; }
    }
}
