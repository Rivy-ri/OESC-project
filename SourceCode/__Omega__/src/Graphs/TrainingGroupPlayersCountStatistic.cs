using System.Data.SqlClient;
using LiveCharts;
using LiveCharts.Wpf;

namespace OmegaSportExplorerClub.src.Graphs
{
    /// <summary>
    /// Represents a statistic of the number of players in each training group.
    /// </summary>
    public class TrainingGroupPlayersCountStatistic
    {
        private string name;
        private int count;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrainingGroupPlayersCountStatistic"/> class.
        /// </summary>
        /// <param name="name">The name of the training group.</param>
        /// <param name="count">The number of players in the training group.</param>
        public TrainingGroupPlayersCountStatistic(string name, int count)
        {
            Name = name;
            Count = count;
        }

        public string Name { get => name; set => name = value; }
        public int Count { get => count; set => count = value; }

        /// <summary>
        /// Draws a pie chart using the data from the database.
        /// </summary>
        /// <param name="chart">The <see cref="LiveCharts.WinForms.PieChart"/> object used to draw the chart.</param>
        public static void DrawChart(LiveCharts.WinForms.PieChart chart)
        {
            var statistic = GetStaticFromDatabase();
            Func<ChartPoint, string> labelPoint = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            foreach (var team in statistic)
            {
                chart.Series.Add(new PieSeries
                {
                   Title=team.Name,
                   Values=new ChartValues<int> { team.count },
                   DataLabels = true,
                   LabelPoint = labelPoint,

                });
            }
            chart.LegendLocation = LegendLocation.Right;
        }
        /// <summary>
        /// Gets the statistic data from the database.
        /// </summary>
        /// <returns>A <see cref="List{T}"/> of <see cref="TrainingGroupPlayersCountStatistic"/> objects containing the statistic data.</returns>
        private static List<TrainingGroupPlayersCountStatistic> GetStaticFromDatabase()
        {
            SqlConnection connection = Connection.ConnectionSingleton.Connection();
            List<TrainingGroupPlayersCountStatistic> trainingGroups = new List<TrainingGroupPlayersCountStatistic>();
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            using (SqlCommand command = new SqlCommand("Exec TrainingGroupAmountOfPlayersStatistic", connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TrainingGroupPlayersCountStatistic instance = new TrainingGroupPlayersCountStatistic(reader[0].ToString(), Convert.ToInt32(reader[1]));
                        trainingGroups.Add(instance);
                    }
                    reader.Close();
                    return trainingGroups;
                }
            }
        }
    }
}  
