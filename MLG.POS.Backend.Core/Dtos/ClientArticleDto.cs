using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLG.POS.Backend.Core.Dtos
{
    public class ClientArticleDto
    {
        public int Id_Client_Article { get; set; }
        public int Id_Client { get; set; }
        public int Id_Article { get; set; }

    }
}
