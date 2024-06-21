using MLG.POS.Backend.Core.Dtos;
using MLG.POS.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLG.POS.Backend.Repositories.Interfaces
{
    public interface IRepositoryStores
    {
        Store InsertStore(StoreDto store);
        IEnumerable<Store> GetStores();
        void UpdateStore(StoreDto store);
        void DeleteStore(int id);
    }
}
