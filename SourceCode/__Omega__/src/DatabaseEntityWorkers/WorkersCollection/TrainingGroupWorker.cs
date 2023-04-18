using OmegaSportExplorerClub.Database_entity_class;
using OmegaSportExplorerClub.Database_entity_commands;
using OmegaSportExplorerClub.Interfaces;
using OmegaSportExplorerClub.src.Connection;
using OmegaSportExplorerClub.src.Enums;
using System.Data.SqlClient;
using System.Transactions;

namespace OmegaSportExplorerClub.src.DatabaseEntityWorkers.WorkersCollection
{
    /// <summary>
    /// Class for working with training groups in the database
    /// </summary>
    public class TrainingGroupWorker
    {
        
        private readonly InterfaceCommands<TrainingGroup> trainingGroupCommands;

        /// <summary>
        /// Constructor for creating a new instance of TrainingGroupWorker
        /// </summary>
        /// <param name="TrainingGroupCommands">The interface commands for working with TrainingGroup objects in the database</param>
        public TrainingGroupWorker(InterfaceCommands<TrainingGroup> TrainingGroupCommands)
        {
            trainingGroupCommands = TrainingGroupCommands;
        }
        /// <summary>
        /// Creates a new training group in the database
        /// </summary>
        /// <param name="coach">The coach who will lead the training group</param>
        /// <param name="group_name">The name of the training group</param>
        /// <param name="type">The type of the training group</param>
        public void Create(Coach coach, string group_name, TrainingGroupsTypes type)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try { 
                    if(SqlInjectionCheck.Check_text(group_name)||SqlInjectionCheck.Check_text(coach.DB_Name)|| SqlInjectionCheck.Check_text(coach.DB_Surename))
                    {
                        throw new Exception("");
                    }
                    int coach_id = CoachCommands.Coach_Get_ID(coach);
                    int type_id = Get_Training_group_type_id(type);
                    if (coach_id < 0 || type_id < 0)
                    {
                        new Exception("because trainer name doesn't exist");
                    }
                    else
                    {
                        TrainingGroup instance = new TrainingGroup(coach_id.ToString(), type_id.ToString(), group_name);
                        var result = trainingGroupCommands.ADD(instance);
                        if (result == true)
                        {
                            MessageBox.Show("Creation of new training group was successful");
                            scope.Complete();
                        }
                        else
                        {
                           
                            scope.Dispose();
                            throw new Exception();
                        }

                    }
                    }
                catch (Exception ex)
                {
                    MessageBox.Show("Creation of new training group failed "+ex.Message);
                }
            }

        }
        /// <summary>
        /// Deletes a training group from the database by name
        /// </summary>
        /// <param name="name">The name of the training group to delete</param>
        public void Delete(string name)
        {
            try {
                if (SqlInjectionCheck.Check_text(name))
                {
                    throw new Exception("");
                }
                TrainingGroup instance = new TrainingGroup(name);
                var result = trainingGroupCommands.DELETE(instance);
                if (result == true)
                {
                    MessageBox.Show("Delete of training group was successful");

                }
                else
                {
                    throw new Exception(" ,maybe wrong name?");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete of training group failed"+ex.Message);
            }
           

        }
        /// <summary>
        /// Updates a training group in the database by name
        /// </summary>
        /// <param name="name">The name of the training group to update</param>
        /// <param name="coach">The coach who will lead the updated training group</param>
        /// <param name="type">The updated type of the training group</param>
        public void Update(string name, Coach coach, TrainingGroupsTypes type)
        {
            try { 
                var id_coach = CoachCommands.Coach_Get_ID(coach);
                var id_type = Get_Training_group_type_id(type);
                if (id_coach > 0 && id_type > 0)
                {
                    TrainingGroup instance = new TrainingGroup(id_coach.ToString(), id_type.ToString(), name);
                    var result = trainingGroupCommands.UPDATE(instance);
                    if (result == true)
                    {
                        MessageBox.Show("Update of training group was successful");

                    }
                    else
                    {
                        throw new Exception(" ,maybe wrong name of group");
                    }
                }
                else
                {
                    throw new Exception(" ,maybe wrong name and surname of trainer?");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("update of training group failed" + ex.Message);
            }


        }
        /// <summary>
        /// Method will get training group type id from database 
        /// </summary>
        /// <param name="type">name of type</param>
        /// <returns>int id of the group type</returns>
        /// <exception cref="Exception"> when nothing was found in database</exception>
        private static int Get_Training_group_type_id(TrainingGroupsTypes type)
        {
            SqlConnection connection = ConnectionSingleton.Connection();
            string full_name;
            switch (type)
            {
                case TrainingGroupsTypes.yp:
                    full_name = "younger pupils";
                    break;
                case TrainingGroupsTypes.op:
                    full_name = "older pupils";
                    break;
                default:
                    full_name = Convert.ToString(type);
                    break;
            }
            using (SqlCommand cmd = new SqlCommand("Select [TypeOfGroup_ID] From [dbo].[TypeOfGroup] where [NameOfType]=@full_name", connection))
            {
                SqlParameter fullname = new SqlParameter("@full_name", System.Data.SqlDbType.VarChar);
                fullname.Value = full_name;
                cmd.Parameters.Add(fullname);
                using (var reader = cmd.ExecuteReader())
                {
                    int id;
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            id = Convert.ToInt32(reader[0].ToString());
                            return id;
                        }
                        reader.Close();

                    }
                    else
                    {
                        throw new Exception("nothing found");

                    }
                }
                return -1;
            }

        }



    }
}
