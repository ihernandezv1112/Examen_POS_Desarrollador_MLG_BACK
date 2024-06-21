using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLG.POS.Backend.Core.Dtos
{
    public class ClientRoleDto
    {
        public int Id_Client_Role { get; set; }
        public int Id_Client { get; set; }
        public int Id_Role { get; set; }

    }
}
