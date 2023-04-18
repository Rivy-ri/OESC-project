using OmegaSportExplorerClub.Interfaces;

namespace OmegaSportExplorerClub.src.Interfaces
{
    /// <summary>
    /// Interface for classes that read data from a database with a parameter of type T that implements InterfaceId.
    /// </summary>
    /// <typeparam name="T">The type of the parameter that implements InterfaceId</typeparam>
    internal interface InterfaceReaderWithParametr<T> where T : InterfaceId
    {
        /// <summary>
        /// Gets data from the database with a parameter of type T that implements InterfaceId.
        /// </summary>
        /// <param name="input">The input parameter to search for in the database</param>
        /// <returns>A list of objects of type T that match the input parameter</returns>
        List<T> GetDataFromDtabase(string input);
        /// <summary>
        /// Writes data from a DataGridView control using the input parameter to search for data in the database.
        /// </summary>
        /// <param name="view">The DataGridView control to write data to</param>
        /// <param name="input">The input parameter to search for in the database</param>
        void WriteData(DataGridView view,string input);
    }
}
