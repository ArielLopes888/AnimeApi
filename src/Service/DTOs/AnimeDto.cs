﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class AnimeDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public string Summary { get; set; }
    }
}
