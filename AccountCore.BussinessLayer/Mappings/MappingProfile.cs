using AutoMapper;
using System;
using Entities = AccountCore.DAL.Models;
using Contracts = AccountCore.Contract.Models;

namespace AccountCore.BussinessLayer.Mappings
{
    public class EnumValueConverter<TSourceMember, TDestinationMember> : IValueConverter<TSourceMember, TDestinationMember>
            where TSourceMember : struct
            where TDestinationMember : struct
    {
        public TDestinationMember Convert(TSourceMember sourceMember, ResolutionContext context)
        {
            var name = Enum.GetName(typeof(TSourceMember), sourceMember);

            return Enum.Parse<TDestinationMember>(name);
        }
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Entities.Employee, Contracts.Employee>()
                .ForMember(d => d.ManagerName, opt => opt.MapFrom(v => v.Manager != null ? v.Manager.Name : ""))
                //.ForMember(d => d.Position, opt => opt.ConvertUsing<Entities.Position>(new EnumValueConverter<Entities.Position, Contracts.Position>(), u => u.Position))
                ;

            CreateMap<Contracts.Employee, Entities.Employee>()
            //.ForMember(i => i., opt => opt.Ignore())
            ;

            CreateMap<Entities.Manager, Contracts.Manager>();
        }
    }
}
