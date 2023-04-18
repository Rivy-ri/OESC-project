using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmegaSportExplorerClub.src.Interfaces
{
    /// <summary>
    /// Interface is used for verification commands classes
    /// </summary>
    public interface InterfaceVerificationCommand
    {
        /// <summary>
        /// method for verifying of something
        /// </summary>
        /// <param name="item"> item that will be verified</param>
        /// <returns></returns>
        public bool verify(string item);
    }
}
