﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentApartment.Models
{
    public class User
    {
        public Guid Guid { get; set; }
        public string UserName { get; set; }
        public string Adress { get; set; }
    }
}
