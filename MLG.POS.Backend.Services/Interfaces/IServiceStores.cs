using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MLG.POS.Backend.Core.Dtos;
using MLG.POS.Backend.Core.Entities;

namespace MLG.POS.Backend.Services.Interfaces
{
    public interface IServiceStores
    {
        public Store InsertStore(StoreDto store);
        public IEnumerable<Store> GetStores();
        public void UpdateStore(StoreDto store);
        public void DeleteStore(int id);
    }
}
