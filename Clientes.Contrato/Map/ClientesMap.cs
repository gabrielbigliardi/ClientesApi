using AutoMapper;
using Clientes.Contrato.Entidades;
using Clientes.Contrato.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Contrato.Map
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapeia ClienteDto para Cliente
            CreateMap<ClienteDto, Cliente>()
                .ForMember(dest => dest.ClienteId, opt => opt.MapFrom(src => src.ClienteId))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco))
                .ForMember(dest => dest.Cep, opt => opt.MapFrom(src => src.Cep))
                .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.DataNascimento))
                .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.Telefone));

            CreateMap<Cliente, ClienteDto>()
               .ForMember(dest => dest.ClienteId, opt => opt.MapFrom(src => src.ClienteId))
               .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
               .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco))
               .ForMember(dest => dest.Cep, opt => opt.MapFrom(src => src.Cep))
               .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.DataNascimento))
               .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.Telefone));

        }
    }
}
