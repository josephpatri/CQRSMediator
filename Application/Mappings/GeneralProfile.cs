using Application.DTOs;
using Application.Features.Customers.Commands.Create;
using Application.Features.Customers.Commands.Update;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile() 
        {
            #region Commands

            CreateMap<CreateCustomer, Customer>();
            CreateMap<UpdateCustomer, Customer>();

            #endregion

            #region Queries

            CreateMap<Customer, CustomerDto>();

            #endregion
        }
    }
}
