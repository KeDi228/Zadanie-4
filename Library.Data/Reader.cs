using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public class Reader
    {
        private string Name;
        public string rName
        {
            get { return Name; }
            set { Name = value; }
        }

        public Reader(string name)
        {
            Name = name;
        }
    }
}
