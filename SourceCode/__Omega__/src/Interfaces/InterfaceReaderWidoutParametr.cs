namespace OmegaSportExplorerClub.Interfaces
{


/// <summary>
/// Interface for a reader that retrieves data from a database without any parameters.
/// </summary>
/// <typeparam name="T">A class that implements the InterfaceId interface</typeparam>
internal interface InterfaceReaderWidoutParametr<T> where T : InterfaceId
    {
        /// <summary>
        /// Retrieves a list of data of type T from the database.
        /// </summary>
        /// <returns>A list of data of type T</returns>
        List<T> GetDataFromDtabase();
        /// <summary>
        /// Writes the retrieved data of type T to a DataGridView.
        /// </summary>
        /// <param name="view">The DataGridView to write the data to</param>
        void WriteData(DataGridView view);
    }
}
