using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports.Entities
{
    public class Test
    {
        public String Name { get; set; }
        public Category Category { get; set; }
        public IEnumerable<Question> Questions { get; set; }
        public TimeSpan MaxTime { get; set; }
        public Int32 PassingScore { get; set; }
    }
}