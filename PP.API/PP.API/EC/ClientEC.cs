using PP.API.Database;
using PP.Library.Models;

namespace PP.API.EC
{
    public class ClientEC
    {
        public Client AddOrUpdate(Client client)
        {
            if(client.Id > 0)
            {
                var clientToUpdate = FakeDatabase.Clients.FirstOrDefault(c => c.Id == client.Id);
                if(clientToUpdate != null)
                {
                    FakeDatabase.Clients.Remove(clientToUpdate);
                }
                FakeDatabase.Clients.Add(client);
            }
            else
            {
                client.Id = FakeDatabase.LastClientID + 1;
                FakeDatabase.Clients.Add(client);
            }
            return client;
        } 
    }
}
