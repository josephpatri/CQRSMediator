using Application.Parameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Customers.Queries.GetAll
{
    public class GetAllCustomersParameters : RequestParameters
    {
        public string Name { get; set; }
        public string Mail { get; set; }
    }
}