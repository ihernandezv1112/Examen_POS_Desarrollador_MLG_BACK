using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLG.POS.Backend.Repositories.Repositories.Common
{
    public class RepositoryBase
    {
        protected IDbConnection _connection { get; private set; }

        protected RepositoryBase(IDbConnection connection)
        {
            _connection = connection;
        }
    }
}
