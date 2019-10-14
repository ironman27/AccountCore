using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Entities = AccountCore.DAL;
using Contract = AccountCore.Contract;

namespace AccountCore.BussinessLayer.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Entities.Employee, Contract.Employee>();

            CreateMap<Contract.Employee, Entities.Employee>();
        }
    }
}
