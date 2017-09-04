using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.API.Data;
using Project.API.Data.Model;
using Project.API.Mapping;
using Project.API.Model;

namespace Project.API.BusinessLogic
{
    public class TaskService
    {
        private readonly InMemoryDataStorage data;

        public TaskService()
        {
            this.data = InMemoryDataStorage.Instance;
        }

        public void DeleteTaskById(int id)
        {
            var clientTask = this.GetTaskById(id);

            if (clientTask != null)
            {
                InMemoryDataStorage.Instance.Tasks.Remove(InMemoryDataStorage.Instance.Tasks.Find(t => t.Id == id));
                ClientEntity client = InMemoryDataStorage.Instance.Clients.Find(c => c.Id == clientTask.ClientId);
                if (client != null)
                {
                    client.Tasks.Remove(client.Tasks.Find(t => t.Id == id));
                }
            }
        }

        public TaskModel GetTaskById(int id)
        {
            TaskModel clientTask = data.Tasks.Find(t => t.Id == id)?.ToTaskModel();

            return clientTask;
        }
    }
}
