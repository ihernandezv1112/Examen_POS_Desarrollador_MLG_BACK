using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MLG.POS.Backend.Core.Dtos;
using MLG.POS.Backend.Core.Entities;
using MLG.POS.Backend.Repositories.Interfaces;
using MLG.POS.Backend.Repositories.Repositories.Common;

namespace MLG.POS.Backend.Repositories.Repositories
{
    public class RepositoryClients : RepositoryBase, IRepositoryClients
    {
        public RepositoryClients(IDbConnection connection) : base(connection)
        {   
        }

        public Client InsertClient(ClientDto client)
        {
            int id =  0;
            Client objClient = new Client();

            using (_connection)
            {
                var result = _connection.Query<Client>
                    (
                    sql: "Pos_Insert_Client_SP",
                    param: new {
                        Nam_Name = client.Nam_Name,
                        Nam_Surname = client.Nam_Surname,
                        Des_Address = client.Des_Address,
                        Des_Email = client.Des_Email,
                        Des_Password = client.Des_Password
                    },
                    commandType: CommandType.StoredProcedure
                    ).First();

                if (result is not null) 
                {
                    objClient = result;

                    var resultRole = _connection.Query<ClientRole>
                    (
                    sql: "Pos_Insert_ClientRole_SP",
                    param: new
                    {
                        Id_Client = result.Id_Client,
                        Id_Role = 2,
                    },
                    commandType: CommandType.StoredProcedure
                    );

                }
            }

            return objClient;
        }

        public IEnumerable<Client> GetClients()
        {
            IEnumerable<Client>? result = null;

            try
            {
                result = _connection.Query<Client>("Pos_Get_Clients_SP", commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _connection.Close();
            }
        }

        public void UpdateClient(ClientDto client)
        {
            using (_connection)
            {
                _connection.Execute
                    (
                    sql: "Pos_Update_Client_SP",
                    param: new
                    {
                        Id_Client = client.Id_Client,
                        Nam_Name = client.Nam_Name,
                        Nam_Surname = client.Nam_Surname,
                        Des_Address = client.Des_Address,
                        Des_Email = client.Des_Email,
                        Des_Password = client.Des_Password
                    },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void DeleteClient(int id)
        {
            using (_connection)
            {
                _connection.Execute
                    (
                    sql: "Pos_Delete_Client_ById_SP",
                    param: new
                    {
                        Id_Client = id
                    },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public bool Login(Login login)
        {
            bool response = false;
            int id = 0;
            try
            {
                id = _connection.QuerySingle<int>(
                       "Pos_Get_Client_Login_SP"
                     , new
                     {
                         @email = login.Des_Email,
                         @password = login.Des_Password
                     }
                     , commandType: CommandType.StoredProcedure);

                if (id != 0) { response = true; }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _connection.Close();
            }

            return response;
        }

    }
}
