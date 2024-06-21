using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLG.POS.Backend.Core.Dtos
{
    public class ArticleDto
    {
        public int Id_Article { get; set; }
        public string Cve_Code { get; set; }
        public string Des_Description { get; set; }
        public decimal Val_Price { get; set; }
        public byte[] Img_Image { get; set; }
        public int Val_Stock { get; set; }

    }
}
