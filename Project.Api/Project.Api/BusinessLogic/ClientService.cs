using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.API.Data;
using Project.API.Mapping;
using Project.API.Model;

namespace Project.API.BusinessLogic
{
    public class ClientService
    {
        private readonly InMemoryDataStorage data;

        public ClientService()
        {
            this.data = InMemoryDataStorage.Instance;
        }

        public List<ClientModel> GetClients()
        {
            var clients = this.data.Clients.ToListOfClientModels();
            return clients;
        }
    }
}
