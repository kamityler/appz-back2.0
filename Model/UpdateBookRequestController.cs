using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5LKPZ.Model
{
    public class UpdateBookRequest
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Picture { get; set; }
        public int Price { get; set; }
    }
}
