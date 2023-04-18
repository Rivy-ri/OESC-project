using OmegaSportExplorerClub.Database_entity_class;
using OmegaSportExplorerClub.src.Database_entity_class;
using OmegaSportExplorerClub.src.Connection;
using OmegaSportExplorerClub.src.Other;
namespace OmegaSportExplorerClub
{
    public partial class MainMeny
    {
        private void Tab_control_TG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tab_control_TG.SelectedTab.Name == "TgShowPage")
            {
                Task.Run(() =>
                {
                    // Access the control from the background task using Invoke
                    if (TgDataGrid.InvokeRequired)
                    {
                        TgDataGrid.Invoke(new Action(() =>
                        {
                            reader.TrainingGroupRead.WriteData(TgDataGrid);
                        }));
                    }
                    else
                    {
                        reader.TrainingGroupRead.WriteData(TgDataGrid);
                    }
                });
            }
            else
            {
                return;
            }
        }

        private async void PlayerListSelectedGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                // Access the control from the background task using Invoke
                if (PlayerListSelectedGroup.InvokeRequired)
                {
                    PlayerListSelectedGroup.Invoke(new Action(() =>
                    {
                        reader.PlayerReaderAll.WriteData(PlayerDataGrid, PlayerListSelectedGroup.SelectedItem.ToString());
                    }));
                }
                else
                {
                    reader.PlayerReaderAll.WriteData(PlayerDataGrid, PlayerListSelectedGroup.SelectedItem.ToString());
                }
            });
        }


        private void PlayerProfileSherchButton_Click(object sender, EventArgs e)
        {
            reader.PlayerProfileRead.WriteProfileData(PlayerProfileTextName.Text, PlayerProfileTextSurname.Text, PlayerProfileProfilePlayerFullName, PlayerProfileProfilePlayerAge, PlayerProfileProfilePlayerBirthDate, PlayerProfileProfilePlayerEmail, PlayerProfileProfilePlayerPhoneNumber, PlayerProfileProfilePlayerTg, PlayerProfileProfilePlayerMajority, PlayerProfileProfileCardId, PlayerProfileProfileCardExpiration, PlayerProfileProfileParentFullName, PlayerProfileProfileParentEmail, PlayerProfileProfileParentPhone, PlayerProfileProfileCardBarCode);
        }

        private void PlayerUpdateRadiButtonParent_CheckedChanged(object sender, EventArgs e)
        {
            if (PlayerUpdateRadiButtonPlayer.Checked == true)
            {
                PlayerUpdateRadiButtonParent.Checked = false;
                PlayerUpdateCardPlayerCard.Visible = true;


            }
            else
            {
                PlayerUpdateRadiButtonPlayer.Checked = false;
                PlayerUpdateCardPlayerCard.Visible = false;

            }
        }

        private void PlayerUpdateGeneralInformationButton_Click(object sender, EventArgs e)
        {
            regexCheck.Text = PlayerUpdateEmailTextbox.Text;
            bool resultEmail = regexCheck.CheckEmail();
            regexCheck.Text = PlayerUpdatePhoneTextbox.Text;
            bool resultPhone = regexCheck.CheckPhone();
            if (PlayerUpdateRadiButtonPlayer.Checked == true && resultEmail == true && resultPhone == true)
            {
                worker.PlayerWorker.UpdatePlayer(PlayerUpdateNameTextbox.Text, PlayerUpdateSurnameTextbox.Text, PlayerUpdateEmailTextbox.Text, PlayerUpdatePhoneCodeCombobox.SelectedItem + PlayerUpdatePhoneTextbox.Text, PlayerUpdateExpirationDate.Value.Date, false);
            }
            if (PlayerUpdateRadiButtonPlayer.Checked == false && resultEmail == true && resultPhone == true)
            {
                worker.ParentWorker.UpdateParent(PlayerUpdateNameTextbox.Text, PlayerUpdateSurnameTextbox.Text, PlayerUpdateEmailTextbox.Text, PlayerUpdatePhoneCodeCombobox.SelectedItem.ToString() +PlayerUpdatePhoneTextbox.Text);
            }
            else
            {
                MessageBox.Show("Wrong format of phone number or Email");
            }
        }

        private void PlayerUpdateCardInformationButton_Click(object sender, EventArgs e)
        {
            worker.PlayerWorker.UpdatePlayer(PlayerUpdateNameTextbox.Text, PlayerUpdateSurnameTextbox.Text, PlayerUpdateEmailTextbox.Text, PlayerUpdatePhoneTextbox.Text, PlayerUpdateExpirationDate.Value.Date, true);
        }

        private void TeamManageTeamsCommitButton_Click(object sender, EventArgs e)
        {
            if (TeamManageTeamsAddRadiobutton.Checked == true) { worker.TeamWorker.CreateTeam(TeamManageTeamsTeamName.Text); }
            if (TeamManageTeamsDeleteRadiobutton.Checked == true) { worker.TeamWorker.DeleteTeam(TeamManageTeamsTeamName.Text); }
            if (TeamManageTeamsUpdateRadiobutton.Checked == true) { worker.TeamWorker.UpdateTeam(TeamManageTeamsTeamName.Text, TeamManageTeamsTeamNewName.Text); }
            Task loadComboBoxOpinion1 = Task.Run(() =>
            {
                TeamListTeamsComboBox.DataSource = reader.NamesOfInstancesOfEntityReader.GetInstances("Team");
            });
            Task loadComboBoxOpinion2 = Task.Run(() =>
            {
                loadComboBoxOpinion1.Wait();
                TeamManagePlayersComboBox.DataSource = reader.NamesOfInstancesOfEntityReader.GetInstances("Team");
            });
            Task.Run(() =>
            {
                loadComboBoxOpinion2.Wait();
                TeamTeamGameTeamNameComboBox.DataSource = reader.NamesOfInstancesOfEntityReader.GetInstances("Team");

            });
        }

        private void TeamManageTeamsUpdateRadiobutton_CheckedChanged(object sender, EventArgs e)
        {
            if (TeamManageTeamsUpdateRadiobutton.Checked == true) { TeamManageTeamsTeamNewName.Show(); label48.Show(); }
            else { TeamManageTeamsTeamNewName.Hide(); label48.Hide(); }
        }

        private void TeamListTeamsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            teamDataGrid.Rows.Clear();
            reader.TeamsRead.WriteData(teamDataGrid, TeamListTeamsComboBox.SelectedItem.ToString());


        }

        private void TeamManagePlayersNewPlayerDeleteButton_Click(object sender, EventArgs e)
        {
            TeamManagePlayersPlayersList.RemoveItem(TeamManagePlayersPlayersList.SelectedItem);
        }

        private void TeamManagePlayersNewPlayerAddButton_Click(object sender, EventArgs e)
        {
            TeamManagePlayersPlayersList.AddItem(TeamManagePlayersNewPlayerName.Text);
        }

        private void TeamManagePlayersFinishButton_Click(object sender, EventArgs e)
        {
            List<string> originalList = reader
                 .TeamsRead.GetDataFromDtabase(TeamManagePlayersComboBox.SelectedItem.ToString())
                 .Select(p => $"{p.Name} {p.Surename}")
                 .ToList();
            worker.TeamWorker.AlterTeamPlayers(TeamManagePlayersPlayersList, originalList, TeamManagePlayersComboBox.SelectedItem.ToString());
        }

        private void TeamManagePlayersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TeamManagePlayersPlayersList.Items.Clear();
            foreach (Player player in reader.TeamsRead.GetDataFromDtabase(TeamManagePlayersComboBox.SelectedItem.ToString()))
            {
                TeamManagePlayersPlayersList.AddItem(player.Name + " " + player.Surename);
            };
        }

        private void TeamTeamGameSubmit_Click(object sender, EventArgs e)
        {
            Team team = new Team()
            {
                Name = TeamTeamGameTeamNameComboBox.SelectedItem.ToString()
            };
            worker.TeamWorker.addMatch(team, TeamTeamGameOpponentName.Text, TeamTeamGameNotes.Text, TeamTeamGameWinCheckBox.Checked);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ConnectionSingleton.ConnectionNotification(materialFloatingActionButton6);
        }

        private void playerStoreListInToCsv_Click(object sender, EventArgs e)
        {
            if (SavePlayersSheet.ShowDialog() == DialogResult.OK)
            {
                StoreFile storeCsv = new StoreFile(SavePlayersSheet.FileName, PlayerDataGrid);
                storeCsv.Store();
            }

        }

        private async void TgDataGridRefreshButton_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {

                if (TgDataGrid.InvokeRequired)
                {

                    TgDataGrid.Invoke(new Action(() =>
                    {
                        TgDataGrid.Rows.Clear();
                        TgDataGrid.Columns.Clear();
                        reader.TrainingGroupRead.WriteData(TgDataGrid);
                    }));
                }
                else
                {
                    TgDataGrid.Rows.Clear();
                    TgDataGrid.Columns.Clear();
                    reader.TrainingGroupRead.WriteData(TgDataGrid);
                }
            });

        }

        private async void CoachDataGridRefreshButton_Click(object sender, EventArgs e)
        {
            if (CoachDataGrid.InvokeRequired)
            {

                CoachDataGrid.Invoke(new Action(() =>
                {
                    CoachDataGrid.Rows.Clear();
                    CoachDataGrid.Columns.Clear();
                    reader.CoachReadAll.WriteData(CoachDataGrid);
                }));
            }
            else
            {
                CoachDataGrid.Rows.Clear();
                CoachDataGrid.Columns.Clear();
                reader.CoachReadAll.WriteData(CoachDataGrid);
            }

        }

        private void PlayerDataGridRefreshButton_Click(object sender, EventArgs e)
        {
            if (PlayerDataGrid.InvokeRequired)
            {

                PlayerDataGrid.Invoke(new Action(() =>
                {
                    PlayerDataGrid.Rows.Clear();
                    PlayerDataGrid.Columns.Clear();
                    reader.PlayerReaderAll.WriteData(PlayerDataGrid, PlayerListSelectedGroup.SelectedValue.ToString());
                }));
            }
            else
            {
                PlayerDataGrid.Rows.Clear();
                PlayerDataGrid.Columns.Clear();
                reader.PlayerReaderAll.WriteData(PlayerDataGrid, PlayerListSelectedGroup.SelectedValue.ToString());
            }

        }

        private void teamDataGridRefreshButton_Click(object sender, EventArgs e)
        {
            if (teamDataGrid.InvokeRequired)
            {

                teamDataGrid.Invoke(new Action(() =>
                {
                    teamDataGrid.Rows.Clear();
                    teamDataGrid.Columns.Clear();
                    reader.TeamsRead.WriteData(teamDataGrid, TeamListTeamsComboBox.SelectedValue.ToString());
                }));
            }
            else
            {
                teamDataGrid.Rows.Clear();
                teamDataGrid.Columns.Clear();
                reader.TeamsRead.WriteData(teamDataGrid, TeamListTeamsComboBox.SelectedValue.ToString());
            }
        }
    }
}
