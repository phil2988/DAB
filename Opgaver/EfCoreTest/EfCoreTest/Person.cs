﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreTest
{
    public class Person
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public int Age { get; set; }

        public Car Car { get; set; }
    }
}
