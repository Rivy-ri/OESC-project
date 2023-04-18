using OmegaSportExplorerClub.Database_entity_commands;
using OmegaSportExplorerClub.src.Database_entity_commands;
using OmegaSportExplorerClub.src.DatabaseEntityCommands;
using OmegaSportExplorerClub.src.DatabaseEntityWorkers.WorkersCollection;
namespace OmegaSportExplorerClub.src.DatabaseEntityWorkers
{
    /// <summary>
    /// Facade class that provides access to all workers for interacting with the database entities
    /// </summary>
    public class DatabaseEntityWorkersFacade
    {
        private readonly CoachWorker coachWorker;
        private readonly ParentWorker parentWorker;
        private readonly TeamWorker teamWorker;
        private readonly TrainingGroupWorker trainingGroupWorker;
        private readonly PlayerWorker playerWorker;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseEntityWorkersFacade"/> class.
        /// </summary>
        public DatabaseEntityWorkersFacade()
        {
            coachWorker = new CoachWorker(new CoachCommands());
            parentWorker = new ParentWorker();
            playerWorker = new PlayerWorker(new PlayerCommands(),new CardCommands(),new ParentCommands());
            teamWorker = new TeamWorker(new TeamCommands(), new TeamAlterPlayerListCommands(),new MatchCommands());
            trainingGroupWorker = new TrainingGroupWorker(new TrainingGroupCommands());

        }
        /// <summary>
        /// Gets the <see cref="CoachWorker"/> instance for interacting with coaches in the database
        /// </summary>
        public CoachWorker CoachWorker => coachWorker;
        /// <summary>
        /// Gets the <see cref="ParentWorker"/> instance for interacting with parents in the database
        /// </summary>
        public ParentWorker ParentWorker => parentWorker;
        /// <summary>
        /// Gets the <see cref="TeamWorker"/> instance for interacting with teams in the database
        /// </summary>
        public TeamWorker TeamWorker => teamWorker;
        /// <summary>
        /// Gets the <see cref="PlayerWorker"/> instance for interacting with players in the database
        /// </summary>
        public PlayerWorker PlayerWorker => playerWorker;
        /// <summary>
        /// Gets the <see cref="TrainingGroupWorker"/> instance for interacting with training groups in the database
        /// </summary>
        internal TrainingGroupWorker TrainingGroupWorker => trainingGroupWorker;
    }
}
