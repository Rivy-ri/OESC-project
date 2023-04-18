using OmegaSportExplorerClub.Interfaces;

namespace OmegaSportExplorerClub.Database_entity_class
{
    /// <summary>
    /// A class representing a training group.
    /// </summary>
    public class TrainingGroup : InterfaceId
    {
        private int db_id;
        private string db_coach;
        private string db_type;
        private string db_group_name;
        private int number_of_players;

        /// <summary>
        /// Constructs a new TrainingGroup object with the specified parameters.
        /// </summary>
        /// <param name="db_id">The ID of the training group.</param>
        /// <param name="db_coach">The name of the coach of the training group.</param>
        /// <param name="db_type">The type of the training group.</param>
        /// <param name="db_group_name">The name of the training group.</param>
        public TrainingGroup(int db_id, string db_coach, string db_type, string db_group_name)
        {
            DB_ID = db_id;
            Db_coach = db_coach;
            Db_type = db_type;
            Db_group_name = db_group_name;

        }
        /// <summary>
        /// Constructs a new TrainingGroup object with the specified parameters.
        /// </summary>
        /// <param name="db_coach">The name of the coach of the training group.</param>
        /// <param name="db_type">The type of the training group.</param>
        /// <param name="db_group_name">The name of the training group.</param>
        /// <param name="number_of_players">The number of players in the training group.</param>
        public TrainingGroup(string db_coach,string db_type,string db_group_name, int number_of_players)
        {
            Db_coach = db_coach;
            Db_type = db_type;
            Db_group_name = db_group_name;
            Number_of_players = number_of_players;


        }
        /// <summary>
        /// Constructs a new TrainingGroup object with the specified parameters.
        /// </summary>
        /// <param name="db_coach">The name of the coach of the training group.</param>
        /// <param name="db_type">The type of the training group.</param>
        /// <param name="db_group_name">The name of the training group.</param>
        public TrainingGroup(string db_coach, string db_type, string db_group_name)
        {
            Db_coach = db_coach;
            Db_type = db_type;
            Db_group_name = db_group_name;
        }
        /// <summary>
        /// Constructs a new TrainingGroup object with the specified parameters.
        /// </summary>
        /// <param name="db_group_name">The name of the training group.</param>
        public TrainingGroup(string db_group_name)
        {
            Db_group_name = db_group_name;
        }

        /// <summary>
        /// Constructs a new empty TrainingGroup object.
        /// </summary>
        public TrainingGroup()
        {
            Db_group_name = db_group_name;
        }
        public int DB_ID { get => db_id; set => db_id = value; }
        public string Db_coach { get => db_coach; set => db_coach = value; }
        public string Db_type { get => db_type; set => db_type = value; }
        public string Db_group_name { get => db_group_name; set => db_group_name = value; }
        public int Number_of_players { get => number_of_players; set => number_of_players = value; }
    }
}
