using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MLG.POS.Backend.Core.Dtos;
using MLG.POS.Backend.Core.Entities;

namespace MLG.POS.Backend.Repositories.Interfaces
{
    public interface IRepositoryClients
    {
        Client InsertClient(ClientDto client);
        IEnumerable<Client> GetClients();
        void UpdateClient(ClientDto client);
        void DeleteClient(int id);
        bool Login(Login login);

    }
}
