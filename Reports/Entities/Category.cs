using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports.Entities
{
    public class Category
    {
        public Category(String name)
        {
            this.Name = name;
        }
        public String Name { get; set; }
    }
}