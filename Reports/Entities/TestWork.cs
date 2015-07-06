using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports.Entities
{
    public class TestWork
    {
        public Test Test { get; set; }
        public User User { get; set; }
        public Int32 Result { get; set; }
        public TimeSpan Time { get; set; }
    }
}