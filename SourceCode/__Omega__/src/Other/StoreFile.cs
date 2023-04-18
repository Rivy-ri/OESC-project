using System.IO;

namespace OmegaSportExplorerClub.src.Other
{
    /// <summary>
    /// Provides functionality for storing data from a DataGridView into a file.
    /// </summary>
    public class StoreFile
    {
        /// <summary>
        /// The file path to store the data in.
        /// </summary>
        private readonly string path;
        /// <summary>
        /// The DataGridView containing the data to be stored.
        /// </summary>
        private readonly DataGridView dataGrid;
        /// <summary>
        /// Initializes a new instance of the StoreFile class with a specified file path and DataGridView.
        /// </summary>
        /// <param name="path">The file path to store the data in.</param>
        /// <param name="dataGrid">The DataGridView containing the data to be stored.</param>
        public StoreFile(string path, DataGridView dataGrid)
        {
            this.path = path;
            this.dataGrid = dataGrid;
        }
        /// <summary>
        /// Stores the data from the DataGridView into a file.
        /// </summary>
        public void Store()
        {
            var listToStore = dataGrid.Rows
                .Cast<DataGridViewRow>()
                .Where(row => !row.IsNewRow)
                .Select(row => row.Cells[0].Value.ToString())
                .ToList();

            using (var streamWriter = new StreamWriter(path))
            {
                foreach (var row in listToStore)
                {
                    streamWriter.WriteLine(row);
                }
            }


        }


    }
}
