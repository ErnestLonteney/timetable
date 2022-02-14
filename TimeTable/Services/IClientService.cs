using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeTable.Models;

namespace TimeTable.Services
{
    public interface IClientService
    {
        Task<int> CreateClientAsync(ClientDTO client);

        Task<List<ClientDTO>> GetAllClientsAsync();

        Task<ClientDTO> GetClientByID(Guid id);

        Task<List<ClientDTO>> GetSomeClients(ClientDTO filter);

    }
}
