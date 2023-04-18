using OmegaSportExplorerClub.Interfaces;
namespace OmegaSportExplorerClub.src.Database_entity_class
{
    /// <summary>
    /// This class represents a match entity in the database
    /// </summary>
    public class Match: InterfaceId
    {
        private int db_id;
        private Team team;
        private string oponent;
        private string notes;
        private bool victoryOfOurTeam;

        /// <summary>
        /// Creates a new instance of the Match class with the given properties.
        /// </summary>
        /// <param name="team">The team that played the match.</param>
        /// <param name="oponent">The name of the opposing team.</param>
        /// <param name="notes">Additional notes or comments about the match.</param>
        /// <param name="victoryOfOurTeam">True if our team won, false if they lost or tied.</param>
        public Match(Team team, string oponent, string notes, bool victoryOfOurTeam)
        {
            Team = team;
            Oponent = oponent;
            Notes = notes;
            VictoryOfOurTeam = victoryOfOurTeam;
        }
        public Match()
        {
        }

        public Team Team { get => team; set => team = value; }
        public string Oponent { get => oponent; set => oponent = value; }
        public string Notes { get => notes; set => notes = value; }
        public bool VictoryOfOurTeam { get => victoryOfOurTeam; set => victoryOfOurTeam = value; }
        public int DB_ID { get => db_id; set => db_id = value; }
    }
}
