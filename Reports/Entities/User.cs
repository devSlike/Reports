using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports.Entities
{
    public class User
    {
        public String Name { get; set; }
        public String Email { get; set; }
        public Int32 Age { get; set; }
        public String City { get; set; }
        public String University { get; set; }
        public Category Category { get; set; }

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}", Name, Age.ToString(), City);
        }
    }
}