using OmegaSportExplorerClub.Database_entity_class;
using OmegaSportExplorerClub.Interfaces;
using OmegaSportExplorerClub.src.Connection;

namespace OmegaSportExplorerClub.src.DatabaseEntityWorkers.WorkersCollection
{
    public class CoachWorker
    {
        private readonly InterfaceCommands<Coach> coachCommands;

        public CoachWorker(InterfaceCommands<Coach> coachCommands)
        {
            this.coachCommands = coachCommands;

        }

        /// <summary>
        /// Creates an object of the Coach class and then inserts it into the database and inform user
        /// </summary>
        /// <param name="name">coach name</param>
        /// <param name="surname">coach surname</param>
        /// <param name="email">coach email</param>
        /// <param name="phone">coach phone</param>
        public void CreateCoach(string coachName, string coachSurname, string coachEmail, string coachPhone)
        {
            try
            {
                if (SqlInjectionCheck.Check_text(coachEmail) || SqlInjectionCheck.Check_text(coachName) || SqlInjectionCheck.Check_text(coachSurname))
                {
                    throw new Exception();
                }

                Coach coach = new Coach(coachName, coachSurname, coachEmail, coachPhone);
                if (coachCommands.ADD(coach))
                {
                    MessageBox.Show("Creation of new coach was successful");
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Creation of new coach failed");
            }
        }
        /// <summary>
        /// Creates an object from the coach class and then deletes it in the database and inform user.
        /// </summary>
        /// <param name="name">coach name for finding coach in database</param>
        /// <param name="surename">coach surename for finding coach in database</param>
        public void DeleteCoach(string name, string surname)
        {
            try
            {
                if (SqlInjectionCheck.Check_text(name) || SqlInjectionCheck.Check_text(surname))
                {
                    throw new Exception();
                }
                Coach instance = new Coach(name, surname);
                bool result = coachCommands.DELETE(instance);
                if (result == true)
                {
                    MessageBox.Show("Deleting of coach was successful");
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Deleting of coach failed");
            }


        }

        /// <summary>
        /// Creates an object from the coach class and then update it in the database and inform user.
        /// </summary>
        /// <param name="old_name">user name by withs will be original search</param>
        /// <param name="old_surname">surname by withs will be original search</param>
        /// <param name="email">new email for trainer</param>
        /// <param name="phone">new phone for trainer</param>
        public void UpdateCoach(string oldCoachName, string oldCoachSurname, string newCoachEmail, string newCoachPhone)
        {
            try
            {
                if (SqlInjectionCheck.Check_text(oldCoachName) || SqlInjectionCheck.Check_text(oldCoachSurname) || SqlInjectionCheck.Check_text(newCoachEmail))
                {
                    throw new Exception();
                }

                Coach coach = new Coach(oldCoachName, oldCoachSurname);

                coach.DB_Email = newCoachEmail;
                coach.DB_Phone = newCoachPhone;

                bool result = coachCommands.UPDATE(coach);
                if (result == true)
                {
                    MessageBox.Show("Update of coach was successful");
                }
                else
                {
                    throw new Exception();
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Update of coach failed");
            }
        }

    }
}
