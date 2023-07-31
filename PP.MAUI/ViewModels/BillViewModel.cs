using PP.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.MAUI.ViewModels
{
    public class BillViewModel
    {
        public Bill Model { get; set; }

        public TimeViewModel Time { get; set; }

        public BillViewModel(int tid) //From TimeView
        {
            Time = new TimeViewModel(tid);
            Model = new Bill();
            Model.TotalAmount = Time.Model.Hours * Time.Employee.Rate;
            Model.EmployeeID = Time.Model.EmployeeId;
            Model.ProjectID = Time.Model.ProjectId;
            totalhrs = Time.Model.Hours.ToString();
            employeerate = Time.Employee.Rate.ToString();
            total = Model.TotalAmount.ToString("N2");
        }

        public string totalhrs { get; set; }

        public string employeerate { get; set; }

        public string total { get; set; }
        
    }
}
