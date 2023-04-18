using OmegaSportExplorerClub.Interfaces;

namespace OmegaSportExplorerClub.Database_entity_class
{
    /// <summary>
    /// Represents a coach entity in database.
    /// </summary>
    public class Coach : InterfaceId
    {
        private int db_Id;
        private string db_Name;
        private string db_Surename;
        private string db_Email;
        private string db_Phone;
        /// <summary>
        /// Initializes a new instance of the Coach class with the specified database ID, name, surname, email, and phone number.
        /// </summary>
        /// <param name="dB_ID">The database ID of the coach.</param>
        /// <param name="dB_Name">The name of the coach.</param>
        /// <param name="dB_Surename">The surname of the coach.</param>
        /// <param name="dB_Email">The email address of the coach.</param>
        /// <param name="dB_Phone">The phone number of the coach.</param>
        public Coach(int dB_ID, string dB_Name, string dB_Surename, string dB_Email, string dB_Phone)
        {
            DB_ID = dB_ID;
            DB_Name = dB_Name;
            DB_Surename = dB_Surename;
            DB_Email = dB_Email;
            DB_Phone = dB_Phone;
        }
        /// <summary>
        /// Initializes a new instance of the Coach class with the specified name, surname, email, and phone number.
        /// </summary>
        /// <param name="dB_Name">The name of the coach.</param>
        /// <param name="dB_Surename">The surname of the coach.</param>
        /// <param name="dB_Email">The email address of the coach.</param>
        /// <param name="dB_Phone">The phone number of the coach.</param>
        public Coach(string dB_Name, string dB_Surename, string dB_Email, string dB_Phone)
        {
            DB_Name = dB_Name;
            DB_Surename = dB_Surename;
            DB_Email = dB_Email;
            DB_Phone = dB_Phone;
        }
        /// <summary>
        /// Initializes a new instance of the Coach class with the specified surname, email, and phone number.
        /// </summary>
        /// <param name="dB_Surename">The surname of the coach.</param>
        /// <param name="dB_Email">The email address of the coach.</param>
        /// <param name="dB_Phone">The phone number of the coach.</param>
        public Coach(string dB_Surename, string dB_Email, string dB_Phone)
        {
            DB_Surename = dB_Surename;
            DB_Email = dB_Email;
            DB_Phone = dB_Phone;
        }
        /// <summary>
        /// Initializes a new instance of the Coach class with the specified name and surname.
        /// </summary>
        /// <param name="dB_Name">The name of the coach.</param>
        /// <param name="dB_Surename">The surname of the coach.</param>
        public Coach(string dB_Name, string dB_Surename)
        {
            DB_Name = dB_Name;
            DB_Surename = dB_Surename;
        }
        /// <summary>
        /// Initializes a new instance of the Coach class with default values.
        /// </summary>
        public Coach()
        {
        }
        public int DB_ID { get => db_Id; set => db_Id = value; }
        public string DB_Name { get => db_Name; set => db_Name = value; }
        public string DB_Surename { get => db_Surename; set => db_Surename = value; }
        public string DB_Email { get => db_Email; set => db_Email = value; }
        public string DB_Phone { get => db_Phone; set => db_Phone = value; }

    }
}
