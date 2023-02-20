﻿using GoodRead.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodRead.Domain.Entities.Books
{
    public class Category : Auditable
    {
        public string CategoryName { get; set; } = String.Empty;
    }
}