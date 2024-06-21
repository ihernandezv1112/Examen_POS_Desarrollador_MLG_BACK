using Dapper;
using MLG.POS.Backend.Core.Dtos;
using MLG.POS.Backend.Core.Entities;
using MLG.POS.Backend.Repositories.Interfaces;
using MLG.POS.Backend.Repositories.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLG.POS.Backend.Repositories.Repositories
{
    public class RepositoryStores : RepositoryBase, IRepositoryStores
    {
        public RepositoryStores(IDbConnection connection) : base(connection)
        {
        }

        public Store InsertStore(StoreDto store)
        {
            int id = 0;
            Store objStore = new Store();

            using (_connection)
            {
                var result = _connection.Query<Store>
                    (
                    sql: "Pos_Insert_Store_SP",
                    param: new
                    {
                        Des_Branch = store.Des_Branch,
                        Des_Address = store.Des_Address
                    },
                    commandType: CommandType.StoredProcedure
                    ).First();

                if (result is not null)
                {
                    objStore = result;
                }
            }

            return objStore;
        }

        public IEnumerable<Store> GetStores()
        {
            IEnumerable<Store>? result = null;

            try
            {
                result = _connection.Query<Store>("Pos_Get_Stores_SP", commandType: CommandType.StoredProcedure).ToList();

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

        public void UpdateStore(StoreDto store)
        {
            using (_connection)
            {
                _connection.Execute
                    (
                    sql: "Pos_Update_Store_SP",
                    param: new
                    {
                        Id_Store = store.Id_Store,
                        Des_Branch = store.Des_Branch,
                        Des_Address = store.Des_Address
                    },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void DeleteStore(int id)
        {
            using (_connection)
            {
                _connection.Execute
                    (
                    sql: "Pos_Delete_Store_ById_SP",
                    param: new
                    {
                        Id_Store = id
                    },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

    }
}
