using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSportExplorerClub.Interfaces
{
    /// <summary>
    /// Interface for database commands on an object that implements the InterfaceId interface
    /// </summary>
    /// <typeparam name="T">Type of object that implements the InterfaceId interface</typeparam>
    public interface InterfaceCommands<T> where T : InterfaceId
    {
        /// <summary>
        /// Adds an object to the database
        /// </summary>
        /// <param name="obj">The object to be added</param>
        /// <returns>True if the operation was successful, false otherwise</returns>
        bool ADD(T obj);
        /// <summary>
        /// Deletes an object from the database
        /// </summary>
        /// <param name="obj">The object to be deleted</param>
        /// <returns>True if the operation was successful, false otherwise</returns>
        bool DELETE(T obj);
        /// <summary>
        /// Updates an object in the database
        /// </summary>
        /// <param name="obj">The object to be updated</param>
        /// <returns>True if the operation was successful, false otherwise</returns>
        bool UPDATE(T obj);

    }
}
