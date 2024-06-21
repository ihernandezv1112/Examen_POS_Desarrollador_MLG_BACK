using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MLG.POS.Backend.Services.Interfaces;
using MLG.POS.Backend.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using Microsoft.Data.SqlClient;
using MLG.POS.Backend.Repositories.Repositories;
using MLG.POS.Backend.Core.Entities;
using MLG.POS.Backend.Core.Dtos;
using MLG.POS.Backend.Core.Exceptions;
using System.Globalization;
using Azure;

namespace MLG.POS.Backend.Services.Services
{
    public class ServiceClients : ServiceBase, IServiceClients
    {
        string connectionName = "SqlConnectionLocal";
        IDbConnection _connection;
        IRepositoryClients _repositoryClients;

        public ServiceClients(IConfiguration configuration, IMapper mapper) : base(configuration, mapper)
        {
            _connection = new SqlConnection(_configuration.GetConnectionString(connectionName));
            _repositoryClients = new RepositoryClients(_connection);
        }

        public Client InsertClient(ClientDto client) 
        {
            Client response =  new Client();

            try
            {
                response = _repositoryClients.InsertClient(client);

                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException("Couldn't insert records", ex);
            }
        }

        public IEnumerable<Client> GetClients()
        {
            IEnumerable<Client> response = null;

            try
            {
                response = _repositoryClients.GetClients();

                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException("Couldn't get records", ex);
            }
        }

        public void UpdateClient(ClientDto client)
        {
            try
            {
                _repositoryClients.UpdateClient(client);
            }
            catch (Exception ex)
            {
                throw new BusinessException("Couldn't insert records", ex);
            }
        }

        public void DeleteClient(int id)
        {
            try
            {
                _repositoryClients.DeleteClient(id);

            }
            catch (Exception ex)
            {
                throw new BusinessException("Couldn't insert records", ex);
            }
        }
        public bool Login(Login login)
        {
            bool response = false;
            try
            {
                response = _repositoryClients.Login(login);

                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException("Couldn't get records", ex);
            }
        }

    }
}
