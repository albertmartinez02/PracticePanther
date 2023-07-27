using PP.Library.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Library.Models
{
    public class Client //Client can be part of many projects
    {
        public int Id { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public bool IsActive { get; set; }
        public string? Name { get; set; }
        public string? Notes { get; set; }

        public override string? ToString()
        {
            return $"{Id} {Name}";
        }

        /* public Client() //Default Constructor
         {
             Console.WriteLine("Enter the client's name: ");
             var name = Console.ReadLine() ?? string.Empty;

             Console.WriteLine("Enter a Client ID: ");
             var id = int.Parse(Console.ReadLine() ?? "0");

             Console.WriteLine("Enter an opening date for client transactions in mm/dd/yyyy format: ");
             var openDate = DateTime.Parse(Console.ReadLine() ?? DateTime.Today.ToString());

             Console.WriteLine("Enter any notes you wish to add for the client.");
             var notes = Console.ReadLine() ?? string.Empty;

             bool active = true;

             Name = name;
             Id = id;
             OpenDate = openDate;
             Notes = notes;
             IsActive = active;
             ClientProjects = new List<Project>();

         }*/

    }
}
