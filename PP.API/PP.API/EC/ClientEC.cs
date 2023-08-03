using PP.Library.Models;

namespace PP.API.EC
{
    public class ClientEC
    {
        public Client AddOrUpdate(Client client)
        {
            if(client.Id > 0)
            {
                //update
            }
            else
            {
                //add
            }
        } 
    }
}
