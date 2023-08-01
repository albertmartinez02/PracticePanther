using PP.Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PP.Library.Models
{
    public class Time
    {
        public DateTime? Date { get; set; }

        public string? Narrative { get; set; }

        public decimal Hours { get; set; }

        public int Id { get; set; } //Id for time entry

        public int EmployeeId { get; set; }

        public int ProjectId { get; set; }

        private bool billGenerated = true;

        public bool BillGenerated //UI experience consideration: if true, bill button visible
        {                         //If not, client cannot generate bill again
            get 
            {
                return billGenerated;
            } 
            set 
            { 
                billGenerated = value;
            } 
        } 

        public override string ToString()
        {
            return $"{Narrative}\nHours spent: {Hours}\nProject ID: {ProjectId}\nEmployee ID: {EmployeeId}";
        }
    }
}
