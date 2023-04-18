using OmegaSportExplorerClub.Database_entity_class;
using OmegaSportExplorerClub.Interfaces;
using OmegaSportExplorerClub.src.Connection;
using OmegaSportExplorerClub.src.Database_entity_commands;

namespace OmegaSportExplorerClub.src.DatabaseEntityWorkers.WorkersCollection
{
    public class ParentWorker
    {
        private readonly ParentCommands parentCommands = new ParentCommands();
        public ParentWorker() { }
        /// <summary>
        /// Method will create from player class object and then update player instance in database and notify user how it ended
        /// </summary>
        /// <param name="parentName">parent name by witch will be search in database</param>
        /// <param name="parentSurname">parent surname by witch will be search in database</param>
        /// <param name="parentNewEmail">new parents email</param>
        /// <param name="parentNewPhone">new parents phone</param>
        public void UpdateParent(string parentName, string parentSurname, string parentNewEmail, string parentNewPhone)
        {
            Parent parent = new Parent()
            {
                Name = parentName,
                Surename = parentSurname,
                Email = parentNewEmail,
                Phone = parentNewPhone,
            };
            try
            {
                if (SqlInjectionCheck.Check_text(parentNewEmail) || SqlInjectionCheck.Check_text(parentSurname) || SqlInjectionCheck.Check_text(parentName))
                {
                    throw new Exception();
                }
                bool result = parentCommands.UPDATE(parent);
                if (result == true)
                {
                    MessageBox.Show("Update of parent was successful");
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Update of parent failed");
            }


        }
    }
}
