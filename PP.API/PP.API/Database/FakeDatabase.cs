using PP.Library.Models;
using PP.Library.Services;

namespace PP.API.Database
{
    public static class FakeDatabase
    {
        public static List<Client> Clients = new List<Client>()
            {
                new Client{Id = 1, OpenDate = DateTime.Now, IsActive = false, Name = "Client 1", Notes = "FirstClient"},
                new Client{Id = 2, OpenDate = DateTime.Now, IsActive = false, Name = "Client 2", Notes = "SecondClient"},
                new Client{Id = 3 , OpenDate = DateTime.Now, IsActive = false, Name = "Client 3", Notes = "ThirdClient"},
                new Client{Id = 4 , OpenDate = DateTime.Now, IsActive = false, Name = "Client 4", Notes = "FourthClient"},
                new Client{Id = 5 , OpenDate = DateTime.Now, IsActive = false, Name = "Client 5", Notes = "FifthClient"},
                new Client{Id = 6 , OpenDate = DateTime.Now, IsActive = false, Name = "Client 6", Notes = "SixthClient" },
                new Client{Id = 7 , OpenDate = DateTime.Now, IsActive = false, Name = "Client 7", Notes = "SeventhClient" },
            };

        public static int LastClientID
        {
            get
            {
                return Clients.Select(c => c.Id).Max();
            }
        }
    }

}
