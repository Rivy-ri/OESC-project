using MaterialSkin;
using MaterialSkin.Controls;
using OmegaSportExplorerClub.Database_entity_class;
using OmegaSportExplorerClub.src.Database_entity_class;
using OmegaSportExplorerClub.src.DatabaseReaders;
using OmegaSportExplorerClub.src.Enums;
using System.ComponentModel.DataAnnotations;
using OmegaSportExplorerClub.src.Other;
using OmegaSportExplorerClub.src.DatabaseEntityWorkers;

namespace OmegaSportExplorerClub
{
    public partial class MainMeny : MaterialForm
    {
        private static MainMeny instance = null;
        DatabaseReaderFacade reader = new DatabaseReaderFacade();
        MyRegex regexCheck = new MyRegex("");
        DatabaseEntityWorkersFacade worker = new DatabaseEntityWorkersFacade();


        public MainMeny(string username)
        {
            InitializeComponent();
            MaterialManage();
            Username_holder.Text = username;
            menySwitch.ItemSize = new Size(0, 1);
            menySwitch.Alignment = TabAlignment.Left;
            ConnectionCheckTimer.Start();


        }
        private void MaterialManage()
        {

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Color.FromArgb(177, 195, 88), Color.FromArgb(64, 64, 64), Color.FromArgb(255, 255, 252), Color.FromArgb(177, 195, 88), TextShade.BLACK);

        }
        private void Side_meny_button_coach_Click(object sender, EventArgs e)
        {
            menySwitch.SelectedTab = Coach;
        }
        private void Side_meny_button_logout_Click(object sender, EventArgs e)
        {

            this.Hide();
            LogIn.GetInstance().Show();
        }
        private void coach_add_button_completion_Click(object sender, EventArgs e)
        {
            regexCheck.Text = coach_add_tf_email.Text;
            bool resultEmail = regexCheck.CheckEmail();
            regexCheck.Text = coach_add_tf_phone_p1.Text + coach_add_tf_phone_p2.Text + coach_add_tf_phone_p3.Text;
            bool resultPhone = regexCheck.CheckPhone();
            if (resultEmail == true && resultPhone == true)
            {
                string phone = coach_add_cb_prefix.Text + coach_add_tf_phone_p1.Text + coach_add_tf_phone_p2.Text + coach_add_tf_phone_p3.Text;
                worker.CoachWorker.CreateCoach(coach_add_tf_name.Text, coach_add_tf_surename.Text, coach_add_tf_email.Text, phone);
            }
            else
            {
                MessageBox.Show($"Email adress it is not an email adress{coach_add_tf_email.Text} or phone number is not valid {coach_add_cb_prefix.Text + coach_add_tf_phone_p1.Text + coach_add_tf_phone_p2.Text + coach_add_tf_phone_p3.Text}");
            }
        }
        private void coach_delete_button_confirm_Click(object sender, EventArgs e)
        {
            if (Coach_delete_check_confirm.Checked == true)
            { worker.CoachWorker.DeleteCoach(coach_delete_tb_name.Text, coach_delete_tb_surename.Text); }
            else { MessageBox.Show("Not confirmed"); }
        }

        private void coache_upd_button_complate_Click(object sender, EventArgs e)
        {
            regexCheck.Text = coach_upd_tf_email.Text;
            bool resultEmail = regexCheck.CheckEmail();
            regexCheck.Text = coach_upd_tf_phone_p1.Text + coach_upd_tf_phone_p2.Text + coach_upd_tf_phone_p3.Text;
            bool resultPhone = regexCheck.CheckPhone();
            if (resultEmail == true && resultPhone == true)
            {
                string phone = coach_upd_cb_prefix.Text + coach_upd_tf_phone_p1.Text + coach_upd_tf_phone_p2.Text + coach_upd_tf_phone_p3.Text;
                worker.CoachWorker.UpdateCoach(coach_upd_tf_name.Text, coach_upd_tf_surename.Text, coach_upd_tf_email.Text, phone);
            }
            else
            {
                MessageBox.Show($"Email adress it is not an email adress{coach_upd_tf_email.Text} or the phone nuber is not in right format {coach_upd_tf_phone_p1.Text + coach_upd_tf_phone_p2.Text + coach_upd_tf_phone_p3.Text}");
            }
        }

        private void Side_meny_button_TG_Click(object sender, EventArgs e)
        {
            menySwitch.SelectedTab = TG;
            TG_combobox_type.DataSource = Enum.GetValues(typeof(TrainingGroupsTypes));
            TG_update_cb_types.DataSource = Enum.GetValues(typeof(TrainingGroupsTypes));
        }
        private void coach_TG_show_data_Click(object sender, EventArgs e)
        {

            reader.TrainingGroupRead.WriteData(CoachDataGrid);
        }
        private void TG_add_button_complate_Click(object sender, EventArgs e)
        {

            Coach coach = new Coach(TG_text_coach_name.Text, TG_text_coach_surename.Text);
            TrainingGroupsTypes type = (TrainingGroupsTypes)Enum.Parse(typeof(TrainingGroupsTypes), TG_combobox_type.Text);
            worker.TrainingGroupWorker.Create(coach, TG_text_group_name.Text, type);
        }

        private void TG_delete_bt_confirm_Click(object sender, EventArgs e)
        {
            if (TG_delete_cb_confirm.Checked == true)
            {
                worker.TrainingGroupWorker.Delete(TG_delete_cb_name.Text);
            }
            else
            {
                MessageBox.Show("nope");
            }
        }

        private void TG_update_bt_confirm_Click(object sender, EventArgs e)
        {
            TrainingGroupsTypes type = (TrainingGroupsTypes)Enum.Parse(typeof(TrainingGroupsTypes), TG_update_cb_types.Text);
            Coach coach = new Coach(TG_update_tb_trainer_name.Text, TG_update_tb_trainer_surename.Text);
            worker.TrainingGroupWorker.Update(TG_update_tb_old_name.Text, coach, type);
        }

        private void Main_meny_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }


        private void Main_tab_coach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Main_tab_coach.SelectedTab.Name == "Coach_tb_print")
            {

                reader.CoachReadAll.WriteData(CoachDataGrid);
            }
            else
            {
                return;
            }
        }
        private void Side_meny_button_Player_Click(object sender, EventArgs e)
        {

            PlayerAddCbTg.DataSource = reader.NamesOfInstancesOfEntityReader.GetInstances("TrainingGroup");
            PlayerListSelectedGroup.DataSource = reader.NamesOfInstancesOfEntityReader.GetInstances("TrainingGroup");
            PlayerAddMajority.DataSource = Enum.GetValues(typeof(Majority)).Cast<Majority>().Select(e => new { Value = e, Display = (e.GetType().GetMember(e.ToString())[0].GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault() as DisplayAttribute)?.Name }).ToList();
            PlayerAddMajority.DisplayMember = "Display";
            PlayerAddMajority.ValueMember = "Value";
            menySwitch.SelectedTab = Player;
        }

        private async void Side_meny_button_Team_Click(object sender, EventArgs e)
        {
            menySwitch.SelectedTab = Team;
            var teamInstances = reader.NamesOfInstancesOfEntityReader.GetInstances("Team");
            TeamListTeamsComboBox.DataSource = teamInstances;
            var playerInstances = reader.NamesOfInstancesOfEntityReader.GetInstances("Players");
            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(playerInstances.ToArray());

            TeamManagePlayersNewPlayerName.AutoCompleteCustomSource = autoComplete;
            TeamManagePlayersComboBox.DataSource = teamInstances;

            TeamTeamGameTeamNameComboBox.DataSource = teamInstances;


        }


        private void PlayerDeleteBComplate_Click(object sender, EventArgs e)
        {
            worker.PlayerWorker.DeletePlayer(PlayerDeleteTextName.Text, PlayerDeleteTextLastname.Text, PlayerDeleteChBDeleteParent.Checked);
        }

        private void PlayerAddComplate_Click(object sender, EventArgs e)
        {
            regexCheck.Text = PlayerAddTextPhoneNumber.Text;
            bool resultPhone = regexCheck.CheckPhone();
            regexCheck.Text = PlayerAddTextEmail.Text;
            bool resultEmail = regexCheck.CheckEmail();
            try
            {
                Player player = new Player();
                if (resultPhone && resultEmail)
                {

                    player.Name = PlayerAddTextName.Text;
                    player.Surename = PlayerAddTextLastname.Text;
                    player.Email = PlayerAddTextEmail.Text;
                    player.PhoneNumber = PlayerAddCbPhoneCode.Text + PlayerAddTextPhoneNumber.Text;
                    player.Date_of_birth = PlayerAddDatePlayerBirthDate.Value.Date;
                }
                else
                {
                    throw new Exception("players phone or email is not in right format");
                }
                Parent parent = new Parent()
                {
                    Name = PlayerAddTextParentName.Text,
                    Surename = PlayerAddTextParentLastname.Text,
                    Phone = PlayerAddCbParentPhoneCode.Text + PlayerAddTextParentPhone.Text,
                    Email = PlayerAddTextParentEmail.Text,
                };
                if (parent.Name.Length == 0 && parent.Surename.Length == 0 && parent.Email.Length == 0)
                {
                    parent = null;
                }
                else
                {
                    regexCheck.Text = PlayerAddTextParentPhone.Text;
                    resultPhone = regexCheck.CheckPhone();
                    regexCheck.Text = parent.Email;
                    resultEmail = regexCheck.CheckEmail();
                    if (resultEmail && resultPhone) { } else { throw new Exception("parent phone or email is not in right format"); }

                }

                int covertedNumber;
                bool result = int.TryParse(PlayerAddTextCardNumber.Text, out covertedNumber);
                Card card = new Card();
                if (result == true)
                {
                    regexCheck.Text = covertedNumber.ToString();
                    if (regexCheck.CheckCardNumber())
                    {
                        card.CardNumber = covertedNumber;
                        card.ExpirationDate = PlayerAddDateCardExpirationDate.Value.Date;
                    }
                    else
                    {
                        throw new Exception("Card id must have 10 digits");
                    }
                }
                else
                {
                    card = null;
                }

                worker.PlayerWorker.CreatePlayer(player, parent, card, PlayerAddMajority.GetItemText(PlayerAddMajority.SelectedItem), PlayerAddCbTg.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"action faild beacuse{ex.Message}");
            }

        }
        public static MainMeny GetInstance(string userName)
        {
            if (instance == null)
            {
                instance = new MainMeny(userName);
            }
            instance.Name = userName;
            return instance;

        }


    }
}