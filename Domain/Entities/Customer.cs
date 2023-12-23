using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
    }
}
