using System.Data.SqlClient;
using LiveCharts;
using LiveCharts.Wpf;


namespace OmegaSportExplorerClub.src.Graphs
{
    /// <summary>
    /// Represents the statistics of a team's matches, including the team name, number of wins and losses.
    /// </summary>
    public class TeamsMatchStatistic
    {
        private string teamName;
        private int wins;
        private int losses;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamsMatchStatistic"/> class.
        /// </summary>
        /// <param name="teamName">The name of the team.</param>
        /// <param name="wins">The number of wins.</param>
        /// <param name="losses">The number of losses.</param>
        public TeamsMatchStatistic(string teamName, int wins, int losses)
        {
            TeamName = teamName;
            Wins = wins;
            Losses = losses;
        }

        public string TeamName { get => teamName; set => teamName = value; }
        public int Wins { get => wins; set => wins = value; }
        public int Losses { get => losses; set => losses = value; }

        /// <summary>
        /// Draws a chart based on the statistics of the teams' matches.
        /// </summary>
        /// <param name="chart">The Cartesian chart to draw the data on.</param>
        public static void DrawChart(LiveCharts.WinForms.CartesianChart chart)
        {
            var statistic = GetStaticFromDatabase();
            chart.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title="Wins",
                    Values=new ChartValues<int> (statistic.Select(data=>data.Wins).ToList())

                }
            };
            chart.Series.Add(new ColumnSeries
            {
                Title = "Losses",
                Values = new ChartValues<int>(statistic.Select(data => data.losses).ToList())
            });
            chart.AxisX.Add(new Axis
            {
                Title = "Teams",
                Labels = statistic.Select(data => data.teamName).ToArray()
            });
            chart.AxisY.Add(new Axis
            {
                Title = "Quantity",
                LabelFormatter = value => value.ToString("N")
            });

        }
        /// <summary>
        /// Retrieves statistics of teams' matches from a database.
        /// </summary>
        /// <returns>A list of <see cref="TeamsMatchStatistic"/> instances.</returns>
        private static List<TeamsMatchStatistic> GetStaticFromDatabase()
        {
            SqlConnection connection = Connection.ConnectionSingleton.Connection();
            List<TeamsMatchStatistic> teams = new List<TeamsMatchStatistic>();
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            using(SqlCommand command = new SqlCommand("Exec  TeamMatchStatistic",connection))
            {
                using(var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TeamsMatchStatistic instance = new TeamsMatchStatistic(reader[0].ToString(), Convert.ToInt32(reader[1]), Convert.ToInt32(reader[2]));
                        teams.Add(instance);
                    }
                    reader.Close();
                    return teams;
                }
            }


        }
    }

    
}
