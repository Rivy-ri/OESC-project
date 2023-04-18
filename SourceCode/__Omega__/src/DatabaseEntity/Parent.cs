using OmegaSportExplorerClub.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSportExplorerClub.Database_entity_class
{
    /// <summary>
    /// Class represent an Parent entity in database
    /// </summary>
    public class Parent : InterfaceId
    {
        private int db_id;
        private string name;
        private string surename;
        private string phone;
        private string email;


        /// <summary>
        /// Creates a new instance of the Parent class with the specified database ID, name, surname, phone, and email.
        /// </summary>
        /// <param name="db_id">The ID of the parent in the database.</param>
        /// <param name="name">The first name of the parent.</param>
        /// <param name="surename">The last name of the parent.</param>
        /// <param name="phone">The phone number of the parent.</param>
        /// <param name="email">The email address of the parent.</param>
        public Parent(int db_id, string name, string surename, string phone, string email)
        {
            DB_ID = db_id;
            Name = name;
            Surename = surename;
            Phone = phone;
            Email = email;
        }
        /// <summary>
        /// Creates a new instance of the Parent class.
        /// </summary>
        public Parent()
        {

        }

        public int DB_ID { get => db_id; set => db_id = value; }
        public string Name { get => name; set => name = value; }
        public string Surename { get => surename; set => surename = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
    }
}
