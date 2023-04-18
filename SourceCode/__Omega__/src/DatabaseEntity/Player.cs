using OmegaSportExplorerClub.Interfaces;
using OmegaSportExplorerClub.src.Database_entity_class;

namespace OmegaSportExplorerClub.Database_entity_class
{
    /// <summary>
    /// Class Represent player entity in database
    /// </summary>
    public class Player : InterfaceId
    {
        private string name;
        private string surename;
        private int age;
        private DateTime date_of_birth;
        private int db_id;
        private Card registrationCard;
        private string phoneNumber;
        private string majority;
        private string email;
        private TrainingGroup trainingGroup;
        private Parent parent;

        public string Name { get => name; set => name = value; }
        public string Surename { get => surename; set => surename = value; }
        public int Age { get => age; set => age = value; }
        public DateTime Date_of_birth { get => date_of_birth; set => date_of_birth = value; }
        public int DB_ID { get => db_id; set => db_id = value; }
        public Card RegistrationCard { get => registrationCard; set => registrationCard = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Majority { get => majority; set => majority = value; }
        public string Email { get => email; set => email = value; }
        public TrainingGroup TrainingGroup { get => trainingGroup; set => trainingGroup = value; }
        public Parent Parent { get => parent; set => parent = value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class with the specified parameters.
        /// </summary>
        /// <param name="name">The player's first name.</param>
        /// <param name="surename">The player's last name.</param>
        /// <param name="age">The player's age.</param>
        /// <param name="dB_ID">The player's ID in the database.</param>
        /// <param name="registrationCard">The player's registration card.</param>
        /// <param name="date_of_birth">The player's date of birth.</param>
        public Player(string name, string surename, int age, int dB_ID, Card registrationCard, DateTime date_of_birth)
        {
            Name = name;
            Surename = surename;
            Age = age;
            DB_ID = dB_ID;
            RegistrationCard = registrationCard;
            Date_of_birth = date_of_birth;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class with the specified parameters.
        /// </summary>
        /// <param name="name">The player's first name.</param>
        /// <param name="surename">The player's last name.</param>
        /// <param name="age">The player's age.</param>
        /// <param name="phoneNumber">The player's phone number.</param>
        /// <param name="email">The player's email.</param>
        public Player(string name, string surename, int age,string phoneNumber,string email)
        {
            Name = name;
            Surename = surename;
            Age = age;
            PhoneNumber = phoneNumber;
            Email = email;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> without parameters.
        /// </summary>
        public Player()
        {
        }

    }
}
