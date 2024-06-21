using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MLG.POS.Backend.Core.Dtos;
using MLG.POS.Backend.Core.Entities;

namespace MLG.POS.Backend.Services.Interfaces
{
    public interface IServiceClients
    {
        public Client InsertClient(ClientDto client);
        public IEnumerable<Client> GetClients();
        public void UpdateClient(ClientDto client);
        public void DeleteClient(int id);
        public bool Login(Login login);

    }
}
