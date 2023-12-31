﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Library.Models
{
    public class Bill
    {
        public decimal TotalAmount { get; set; }

        public DateTime DueDate { get; set; }
        
        public int EmployeeID { get; set; }

        public int ProjectID { get; set; }

        public int ClientID { get; set; } //Used for display in other parts of the application

        public override string? ToString()
        {
            return $"Due Date: {DueDate.ToString()}\n Total Amount: {TotalAmount.ToString()}";
        }
    }
}
