using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using Project.API.BusinessLogic;
using Project.API.Model;

namespace Project.API.Controllers
{
    public class ClientsController : ApiController
    {
        private readonly ClientService clientsService;

        public ClientsController()
        {
            this.clientsService = new ClientService();
        }

        //GET api/clients
        [HttpGet]
        [ResponseType(typeof(List<ClientModel>))]
        public IHttpActionResult GetClients()
        {
            var result = this.clientsService.GetClients();

            return this.Ok(result);
        }
    }
}
