using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeTable.Models;
using AutoMapper;
using TimeTable.Data.Repositories;
using TimeTable.Data.Entities;
using System;

namespace TimeTable.Services
{
    public class ClientService : IClientService
    {
        private readonly ILogger logger;
        private readonly IRepository<Client> clientContext;
        private readonly IMapper mapper;
        public ClientService(ILogger logger, IRepository<Client> clientConext)
        {
            this.logger = logger; 
            this.clientContext = clientConext;  
            this.mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<ClientDTO, Client>())); ;
        }

        public async Task<int> CreateClientAsync(ClientDTO client)
        {
            try
            {
                Client newClient = mapper.Map<Client>(client);
                return await clientContext.AddAsync(newClient);
            }
            catch (Exception e)
            {
                logger.LogError(e, e.Message);
            }

            return 0;      
        }

        public async Task<List<ClientDTO>> GetAllClientsAsync()
        {
            var clients = await clientContext.GetAllAsync();

            return mapper.Map<List<ClientDTO>>(clients);
        }

        public async Task<ClientDTO> GetClientByID(Guid id)
        {
            var exists = await clientContext.IsExistsAsync<Guid>(id);

            if (exists)
            { 
                await clientContext.GetOneByIdAsync<Guid>(id);
            }

            return null;
        }

        public async Task<List<ClientDTO>> GetSomeClients(ClientDTO filter)
        {
           var clients = await clientContext.GetManyByFilterAsync(c => (String.IsNullOrWhiteSpace(filter.FirstName) || c.FirstName == filter.FirstName) 
                                                        && String.IsNullOrWhiteSpace(filter.LastName) || c.LastName == filter.LastName 
                                                        && String.IsNullOrWhiteSpace(filter.MiddleName) || c.MiddleName == filter.MiddleName);

            return mapper.Map<List<ClientDTO>>(clients);
        }
    }
}
