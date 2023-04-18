using OmegaSportExplorerClub.src.Graphs;

namespace OmegaSportExplorerClub
{
    public partial class MainMeny
    {

        private void Side_meny_button_Statistic_Click(object sender, EventArgs e)
        {
            menySwitch.SelectedTab = Statistic;
            if(TeamStatisticChart.Series.Any(series=>series.Values.Count>0) && TrainingGroupPlayerAmountStatistic.Series.Any(series => series.Values.Count> 0))
            {

            }
            else
            {
                TeamsMatchStatistic.DrawChart(TeamStatisticChart);
                TrainingGroupPlayersCountStatistic.DrawChart(TrainingGroupPlayerAmountStatistic);
            }

        }
        private void TrainingGroupPlayerAmountStatisticRefreshButton_Click(object sender, EventArgs e)
        {
            TrainingGroupPlayerAmountStatistic.Series.Clear();
            TrainingGroupPlayersCountStatistic.DrawChart(TrainingGroupPlayerAmountStatistic);
        }

        private void TeamStatisticChartRefreshButton_Click(object sender, EventArgs e)
        {
            TeamStatisticChart.Series.Clear();
            TeamStatisticChart.AxisX.Clear();
            TeamStatisticChart.AxisY.Clear();
            TeamsMatchStatistic.DrawChart(TeamStatisticChart);
        }
        private void TeamTeamGameTeamNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (teamDataGrid.InvokeRequired)
            {

                matchReportDataGrid.Invoke(new Action(() =>
                {
                    matchReportDataGrid.Rows.Clear();
                    matchReportDataGrid.Columns.Clear();
                    reader.TeamMatchReader.WriteData(matchReportDataGrid, TeamTeamGameTeamNameComboBox.SelectedItem.ToString());
                }));
            }
            else
            {
                matchReportDataGrid.Rows.Clear();
                matchReportDataGrid.Columns.Clear();
                reader.TeamMatchReader.WriteData(matchReportDataGrid, TeamTeamGameTeamNameComboBox.SelectedItem.ToString());
            }
        }
    }
}
