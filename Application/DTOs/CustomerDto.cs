﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
    }
}
