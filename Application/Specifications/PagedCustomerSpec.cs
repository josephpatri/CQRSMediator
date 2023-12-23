using Ardalis.Specification;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Specifications
{
    public class PagedCustomerSpec : Specification<Customer>
    {
        public PagedCustomerSpec(int pSize, int pNumber, string Name, string Mail)
        {
            Query.Skip((pNumber - 1) * pSize)
                .Take(pSize);

            if(!String.IsNullOrEmpty(Name))
            {
                Query.Where(c => c.Name.Contains(Name));
            }

            if(!String.IsNullOrEmpty(Mail))
            {
                Query.Where(c => c.Mail.Contains(Mail));
            }
        }
    }
}
