//Singleton for Client

using Newtonsoft.Json;
using PP.Library.Models;
using PP.Library.Utilities;
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

        public List<Client> Clients //Before it used to be just return clients;
        {
            get
            {
                // return clients ?? new List<Client>();
                return clients;
            }
        }

        private List<Client> clients;
        private ClientService()       //Initialize a list of clients to start with
        {
            var response = new WebRequestHandler().Get("/Client").Result;
            clients = JsonConvert.DeserializeObject<List<Client>>(response) ?? new List<Client>();
            //clients = new List<Client>()
            //{
            //    new Client{Id = 1, OpenDate = DateTime.Now, IsActive = false, Name = "Client 1", Notes = "FirstClient"},
            //    new Client{Id = 2, OpenDate = DateTime.Now, IsActive = false, Name = "Client 2", Notes = "SecondClient"},
            //    new Client{Id = 3 , OpenDate = DateTime.Now, IsActive = false, Name = "Client 3", Notes = "ThirdClient"},
            //    new Client{Id = 4 , OpenDate = DateTime.Now, IsActive = false, Name = "Client 4", Notes = "FourthClient"},
            //    new Client{Id = 5 , OpenDate = DateTime.Now, IsActive = false, Name = "Client 5", Notes = "FifthClient"},
            //    new Client{Id = 6 , OpenDate = DateTime.Now, IsActive = false, Name = "Client 6", Notes = "SixthClient" },
            //    new Client{Id = 7 , OpenDate = DateTime.Now, IsActive = false, Name = "Client 7", Notes = "SeventhClient" },
            //};
        }

        public Client? GetClient(int id)
        {
            //var response = new WebRequestHandler().Get($"/Client/GetClients/{id}").Result;
            //var client = JsonConvert.DeserializeObject<Client>(response);
            //return client;
            return Clients.FirstOrDefault(c => c.Id == id);
        }

        public void AddOrUpdate(Client? client)
        {
            //if (client != null && client.Id == 0) //If this is the add version of this function
            //{
            //    client.Id = LastId + 1;
            //    client.OpenDate = DateTime.Now;
            //    Clients.Add(client);
            //}
           var response = new WebRequestHandler().Post("/Client", client).Result;
        }

        public void Read()
        {
            Clients.ForEach(Console.WriteLine);
        }

        public void Delete(int cliID)
        {
            var clientToRemove = GetClient(cliID);
            if (clientToRemove != null)
            {
                Clients.Remove(clientToRemove);
            }
        }

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
