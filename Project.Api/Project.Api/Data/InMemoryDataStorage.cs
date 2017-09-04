using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.API.Data.Model;

namespace Project.API.Data
{
    public class InMemoryDataStorage
    {
        private static InMemoryDataStorage instance;

        public static InMemoryDataStorage Instance
        {
            get
            {
                if (InMemoryDataStorage.instance == null)
                {
                    InMemoryDataStorage.instance = InMemoryDataStorage.Init();
                }

                return InMemoryDataStorage.instance;
            }
        }

        private static InMemoryDataStorage Init()
        {
            InMemoryDataStorage newInstance = new InMemoryDataStorage();
            return newInstance;
        }

        public List<ClientEntity> Clients { get; set; }

        public List<TaskEntity> Tasks { get; set; }

        private InMemoryDataStorage()
        {
            this.Tasks = new List<TaskEntity>();

            this.InitializeData();
        }

        private void InitializeData()
        {
            this.InitializeClients();
            this.InitializeTasks();
        }

        private void InitializeClients()
        {
            this.Clients = new List<ClientEntity>
            {
                new ClientEntity
                {
                    Id = 1,
                    FirstName = "Alex",
                    LastName = "Sobolev",
                    Address = "Merefa",
                    Phones = "09912345;12343467;242353465436"
                },
                new ClientEntity
                {
                    Id = 2,
                    FirstName = "Bob",
                    LastName = "Barker",
                    Address = "NewYork",
                    Phones = "0991233423;342343467;42425353436"
                },
                new ClientEntity
                {
                    Id = 3,
                    FirstName = "Konor",
                    LastName = "Mackgregor",
                    Address = "London",
                    Phones = "09944444;3333333467;44444443436"
                },
                new ClientEntity
                {
                    Id = 4,
                    FirstName = "Alex",
                    LastName = "Second",
                    Address = "London",
                    Phones = "08888844;2222222467;55555553436"
                }
            };
        }

        private void InitializeTasks()
        {
            int idStep = 100;
            this.Clients.ForEach(client =>
            {
                
                this.Tasks.Add(GenerateTaskForClient(client, idStep + 1));
                this.Tasks.Add(GenerateTaskForClient(client, idStep + 2));
                this.Tasks.Add(GenerateTaskForClient(client, idStep + 3));
                this.Tasks.Add(GenerateTaskForClient(client, idStep + 4));

                idStep = idStep + 100;
            });
        }

        private TaskEntity GenerateTaskForClient(ClientEntity client, int taskIdKey)
        {
            var task = new TaskEntity
            {
                Id = taskIdKey,
                TaskName = $"Task{taskIdKey} for Client: '{client.FirstName} {client.LastName}'",
                ClientId = client.Id,
                Description = $"Description for task id:'{taskIdKey}'",
                ClientAddress = client.Address,
                StartTime = DateTime.Now.AddHours(taskIdKey),
                EndTime = DateTime.Now.AddHours(taskIdKey + 3)
            };

            client.Tasks.Add(task);
            return task;
        }
    }
}
