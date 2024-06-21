using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MLG.POS.Backend.Core.Entities.Common;

namespace MLG.POS.Backend.Core.Entities
{
    public class Role : BaseEntity
    {
        public int Id_Role { get; set; }
        public string Nam_Role { get; set; }

    }
}
