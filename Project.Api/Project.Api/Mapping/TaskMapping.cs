using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.API.Data.Model;
using Project.API.Model;

namespace Project.API.Mapping
{
    public static class TaskMapping
    {
        public static TaskModel ToTaskModel(this TaskEntity dataEntity)
        {
            return new TaskModel
            {
                Id = dataEntity.Id,
                ClientId = dataEntity.ClientId,
                TaskName = dataEntity.TaskName,
                Description = dataEntity.Description,
                ClientAddress = dataEntity.ClientAddress,
                StartTime = dataEntity.StartTime,
                EndTime = dataEntity.EndTime
            };
        }

        public static List<TaskModel> ToListOfTaskModels(this IEnumerable<TaskEntity> clientTasks)
        {
            return clientTasks.Select(ToTaskModel).ToList();
        }
    }
}
