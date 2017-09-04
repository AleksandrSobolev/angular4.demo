using System.Web.Http;
using Project.API.BusinessLogic;
using Project.API.Model;

namespace Project.API.Controllers
{
    public class TasksController : ApiController
    {
        private readonly TaskService taskDataService;

        public TasksController()
        {
            this.taskDataService = new TaskService();
        }

        // DELETE api/tasks/5 
        [HttpDelete]
        public IHttpActionResult DeleteTask(int id)
        {
            if (id > 0)
            {
                TaskModel clientTask = this.taskDataService.GetTaskById(id);

                if (clientTask != null)
                {
                    this.taskDataService.DeleteTaskById(id);
                    return this.Ok();
                }

                return this.NotFound();
            }

            return this.BadRequest("Task Id should be provided");
        }
    }
}
