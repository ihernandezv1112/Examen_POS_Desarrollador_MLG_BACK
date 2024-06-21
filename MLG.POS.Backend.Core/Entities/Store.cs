using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MLG.POS.Backend.Core.Entities.Common;

namespace MLG.POS.Backend.Core.Entities
{
    public class Store : BaseEntity
    {
        public int Id_Store { get; set; }
        public string Des_Branch { get; set; }
        public string Des_Address { get; set; }

    }
}
