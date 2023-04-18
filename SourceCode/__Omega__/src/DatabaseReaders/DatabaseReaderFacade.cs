using OmegaSportExplorerClub.src.DatabaseReaders.ReadersCollection;

namespace OmegaSportExplorerClub.src.DatabaseReaders
{
    /// <summary>
    /// Facade for accessing various database readers.
    /// </summary>
    public class DatabaseReaderFacade
    {
        private readonly CoachReader coachReadAll;
        private readonly PlayerReader playerReaderAll;
        private readonly TrainingGroupReader trainingGroupRead;
        private readonly PlayerProfileReader playerProfileRead;
        private readonly TeamsReader teamsRead;
        private readonly GetNamesOfInstancesOfEntityReader namesOfInstancesOfEntityReader;
        private readonly TeamMatchReader teamMatchReader;

        /// <summary>
        /// Constructs a new instance of DatabaseReaderFacade.
        /// </summary>
        public DatabaseReaderFacade()
        {
            coachReadAll = new CoachReader();
            playerReaderAll = new PlayerReader();
            trainingGroupRead = new TrainingGroupReader();
            playerProfileRead = new PlayerProfileReader();
            teamsRead = new TeamsReader();
            namesOfInstancesOfEntityReader = new GetNamesOfInstancesOfEntityReader();
            teamMatchReader = new TeamMatchReader();
        }
        /// <summary>
        /// Gets the coach reader.
        /// </summary>
        public CoachReader CoachReadAll => coachReadAll;
        /// <summary>
        /// Gets the player profile reader.
        /// </summary>
        public PlayerProfileReader PlayerProfileRead => playerProfileRead;
        /// <summary>
        /// Gets the player reader.
        /// </summary>
        public PlayerReader PlayerReaderAll => playerReaderAll;
        /// <summary>
        /// Gets the training group reader.
        /// </summary>
        public TrainingGroupReader TrainingGroupRead => trainingGroupRead;
        /// <summary>
        /// Gets the teams reader.
        /// </summary>
        public TeamsReader TeamsRead => teamsRead;
        /// <summary>
        /// Gets the reader for getting names of instances of an entity.
        /// </summary>
        public GetNamesOfInstancesOfEntityReader NamesOfInstancesOfEntityReader => namesOfInstancesOfEntityReader;
        /// <summary>
        /// Gets the team match reader.
        /// </summary>
        public TeamMatchReader TeamMatchReader => teamMatchReader;
    }
}
