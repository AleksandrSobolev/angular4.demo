using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.API.Data.Model
{
    public class ClientEntity : BaseEntity
    {
        public ClientEntity()
        {
            this.Tasks = new List<TaskEntity>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Phones { get; set; }

        public List<TaskEntity> Tasks { get; set; }
    }
}
