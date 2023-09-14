using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Interfaces
{
    public interface IBook
    {
        #region Interface Members

        string Title { get; set; }

        string Author { get; set; }

        string ISBN { get; set; }

        bool IsAvailable { get; set; }

        string Name { get; set; }

        #endregion // Interface Members
    }
}
