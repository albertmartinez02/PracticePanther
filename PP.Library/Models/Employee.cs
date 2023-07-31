using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Library.Models
{
    public class Employee
    {
        public string? Name { get; set; }
        public decimal Rate { get; set; }
        public int ID { get; set; } //Read only , set in constructor

        public override string ToString()
        {
            return $"{Name}";
        }
    }

}
