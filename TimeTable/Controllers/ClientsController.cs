using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeTable.Models;
using TimeTable.Services;

namespace TimeTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientsController(IClientService service)
        {
            _clientService = service;
        }

        [Route("GetClient")]
        [HttpGet]
        public async Task<ClientDTO> GetClient(Guid id)
        {
            if (id != Guid.Empty)
            {
                await _clientService.GetClientByID(id);
            }

            return null;
        }

        [Route("GetAllClients")]
        [HttpGet]
        public async Task<List<ClientDTO>> GetAllClients()
        {
            return await _clientService.GetAllClientsAsync();
        }

        [Route("GetSomeClients")]
        [HttpGet]
        public async Task<List<ClientDTO>> GetSomeClients(ClientDTO filter)
        {
            if (ModelState.IsValid)
            {
                return await _clientService.GetSomeClients(filter);
            }

            return new List<ClientDTO>();
        }

        [Route("CreateClient")]
        [HttpPost]
        public async Task<int> CreateClient(ClientDTO newClient)
        {
            if (ModelState.IsValid)
            {
               return await _clientService.CreateClientAsync(newClient);
            }

            return 0;
        }

    }
}
