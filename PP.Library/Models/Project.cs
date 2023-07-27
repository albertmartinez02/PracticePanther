using PP.Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PP.Library.Models
{
    public class Project
    {
        public int ID { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? ClosedDate { get; set; }
        public bool IsActive { get; set; }
        public string? ShortName { get; set; }
        public string? LongName { get; set; }
        public int ClientId { get; set; } //One client per project

        public Client? client { get; set; }

        public override string ToString()
        {
            return $"{ID} {ShortName}";
        }

        //public Project(int clientID) //Default Constructor
        //{
        //    Console.Write("Enter the projects's long name: ");
        //    var longname = Console.ReadLine() ?? string.Empty;

        //    Console.Write("Enter the projects's short name: ");
        //    var shortname = Console.ReadLine() ?? string.Empty;

        //    Console.Write("Enter a Project ID: ");
        //    var pid = int.Parse(Console.ReadLine() ?? "0");

        //    Console.Write("Enter an starting date for project startup in mm/dd/yyyy format: ");
        //    var openDate = DateTime.Parse(Console.ReadLine() ?? DateTime.Today.ToString());


        //    bool active = true;

        //    LongName = longname;
        //    ShortName = shortname;
        //    ID = pid;
        //    OpenDate = openDate;
        //    IsActive = active;
        //    ClientId = clientID;

        //}


    }
}
