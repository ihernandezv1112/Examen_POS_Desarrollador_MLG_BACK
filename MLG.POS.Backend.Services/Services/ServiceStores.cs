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
    public class ServiceStores : ServiceBase, IServiceStores
    {
        string connectionName = "SqlConnectionLocal";
        IDbConnection _connection;
        IRepositoryStores _repositoryStores;

        public ServiceStores(IConfiguration configuration, IMapper mapper) : base(configuration, mapper)
        {
            _connection = new SqlConnection(_configuration.GetConnectionString(connectionName));
            _repositoryStores = new RepositoryStores(_connection);
        }

        public Store InsertStore(StoreDto store)
        {
            Store response = new Store();

            try
            {
                response = _repositoryStores.InsertStore(store);

                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException("Couldn't insert records", ex);
            }
        }

        public IEnumerable<Store> GetStores()
        {
            IEnumerable<Store> response = null;

            try
            {
                response = _repositoryStores.GetStores();

                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException("Couldn't get records", ex);
            }
        }

        public void UpdateStore(StoreDto store)
        {
            try
            {
                _repositoryStores.UpdateStore(store);
            }
            catch (Exception ex)
            {
                throw new BusinessException("Couldn't insert records", ex);
            }
        }

        public void DeleteStore(int id)
        {
            try
            {
                _repositoryStores.DeleteStore(id);

            }
            catch (Exception ex)
            {
                throw new BusinessException("Couldn't insert records", ex);
            }
        }

    }
}
