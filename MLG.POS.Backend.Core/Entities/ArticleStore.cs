﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MLG.POS.Backend.Core.Entities.Common;

namespace MLG.POS.Backend.Core.Entities
{
    public class ArticleStore : BaseEntity
    {
        public int Id_Article_Store { get; set; }
        public int Id_Article { get; set; }
        public int Id_Store { get; set; }

    }
}
