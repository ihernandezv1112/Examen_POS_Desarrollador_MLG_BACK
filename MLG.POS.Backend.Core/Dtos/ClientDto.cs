using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLG.POS.Backend.Core.Dtos
{
    public class ClientDto
    {
        public int Id_Client { get; set; }
        public string Nam_Name { get; set; }
        public string Nam_Surname { get; set; }
        public string Des_Address { get; set; }
        public string Des_Email { get; set; }
        public string Des_Password { get; set; }

    }
}
