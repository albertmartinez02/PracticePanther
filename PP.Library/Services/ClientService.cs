//Singleton for Client

using PP.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PP.Library.Services
{
    public class ClientService
    {
        private static ClientService? instance;
        private static object _lock = new object();
        public static ClientService Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new ClientService();
                    }
                }

                return instance;
            }
        }

        public List<Client> Clients
        {
            get
            {
                return clients;
            }
        }

        private List<Client> clients; //Represents each client possible in the application lifecycle. This is it. The Singleton 
        private ClientService()       //Initialize a list of clients to start with
        {
            clients = new List<Client>()
            {
                new Client{Id = 1, OpenDate = DateTime.Now, IsActive = false, Name = "Client 1", Notes = "FirstClient"},
                new Client{Id = 2, OpenDate = DateTime.Now, IsActive = false, Name = "Client 2", Notes = "SecondClient"},
                new Client{Id = 3 , OpenDate = DateTime.Now, IsActive = false, Name = "Client 3", Notes = "ThirdClient"},
                new Client{Id = 4 , OpenDate = DateTime.Now, IsActive = false, Name = "Client 4", Notes = "FourthClient"},
                new Client{Id = 5 , OpenDate = DateTime.Now, IsActive = false, Name = "Client 5", Notes = "FifthClient"},
                new Client{Id = 6 , OpenDate = DateTime.Now, IsActive = false, Name = "Client 6", Notes = "SixthClient" },
                new Client{Id = 7 , OpenDate = DateTime.Now, IsActive = false, Name = "Client 7", Notes = "SeventhClient" },
            };
        }

        public Client? GetClient(int id)
        {
            return clients.FirstOrDefault(c => c.Id == id);
        }

        public void AddOrUpdate(Client? client)
        {
            if (client != null && client.Id == 0) //If this is the add version of this function
            {
                client.Id = LastId + 1;
                client.OpenDate = DateTime.Now;
                clients.Add(client);
            }

        }

        public void Read()
        {
            clients.ForEach(Console.WriteLine);
        }

        public void Delete(int cliID)
        {
            var clientToRemove = GetClient(cliID);
            if (clientToRemove != null)
            {
                clients.Remove(clientToRemove);
            }
        }

        /*public void Update(int cliID)
        {
            var updateClient = GetClient(cliID);
            if (updateClient == null)
            {
                Console.WriteLine("Client not found");
                return;
            }
            Console.WriteLine("Letter choice: ");
            var c = Console.ReadLine() ?? string.Empty;
            switch (c)
            {
                case "a":
                    Console.Write("Enter an closing date for client transactions in mm/dd/yyyy format: ");
                    var closeDate = DateTime.Parse(Console.ReadLine() ?? DateTime.Today.ToString());
                    updateClient.CloseDate = closeDate;
                    break;
                case "b":
                    Console.Write("\nEnter client name: ");
                    var cName = Console.ReadLine() ?? string.Empty;
                    updateClient.Name = cName;
                    Console.WriteLine($"Client name: {cName}");
                    break;
                case "c":
                    Console.WriteLine(updateClient.Notes);
                    Console.Write("Do you wish to append to the notes(1) , or replace them entirely(2)? Enter number: ");
                    var choice = int.Parse(Console.ReadLine() ?? "0");
                    if (choice == 1)
                    {
                        Console.Write("Write additions now: ");
                        string added = Console.ReadLine() ?? string.Empty;
                        updateClient.Notes = updateClient.Notes + " " + added;
                    }
                    else if (choice == 2)
                    {
                        string replaceNotes = Console.ReadLine() ?? string.Empty;
                        if (replaceNotes != string.Empty)
                            updateClient.Notes = replaceNotes;
                    }
                    Console.WriteLine($"Notes are : {updateClient.Notes}");
                    break;
                case "d":
                    if (updateClient.IsActive)
                    {
                        updateClient.IsActive = false; Console.WriteLine($"Client {updateClient.Name} is now inactive in system. You can still see client information, however, and {updateClient.Name} still exists");
                    }
                    break;
                case "e":
                    if (updateClient.IsActive != true)
                    {
                        updateClient.IsActive = true; Console.WriteLine($"Client {updateClient.Name} is now active in system");
                    }
                    break;
                case "f":
                    Project pr = new Project(cliID);
                    updateClient.ClientProjects?.Add(pr);
                    Console.WriteLine($"{pr.LongName} project added to client record.");
                    break;
                default:
                    break;
            }
        }*/


        private int LastId
        {
            get
            {
                return Clients.Any() ? Clients.Select(c => c.Id).Max() : 0;
            }
        }

        public IEnumerable<Client> Search(string query)
        {
            return Clients
                .Where(c => c.Name.ToUpper()
                    .Contains(query.ToUpper()));
        }

    }
}
