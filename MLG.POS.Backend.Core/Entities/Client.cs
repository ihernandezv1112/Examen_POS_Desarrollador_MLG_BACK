using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MLG.POS.Backend.Core.Entities.Common;

namespace MLG.POS.Backend.Core.Entities
{
    public class Client : BaseEntity
    {
        public int Id_Client { get; set; }
        public string Nam_Name { get; set; }
        public string Nam_Surname { get; set; }
        public string Des_Address { get; set; }
        public string Des_Email { get; set; }
        public string Des_Password { get; set; }

    }
}
