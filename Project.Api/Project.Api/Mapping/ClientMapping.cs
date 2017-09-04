using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.API.Data.Model;
using Project.API.Model;

namespace Project.API.Mapping
{
    public static class ClientMapping
    {
        public static ClientModel ToCleintModel(this ClientEntity dataEntity)
        {
            return new ClientModel
            {
                FirstName = dataEntity.FirstName,
                LastName = dataEntity.LastName,
                Address = dataEntity.Address,
                Id = dataEntity.Id,
                Phones = dataEntity.Phones,
                Tasks = dataEntity.Tasks.ToListOfTaskModels(),
            };
        }

        public static List<ClientModel> ToListOfClientModels(this IEnumerable<ClientEntity> clients)
        {
            return clients.Select(ToCleintModel).ToList();
        }
    }
}
