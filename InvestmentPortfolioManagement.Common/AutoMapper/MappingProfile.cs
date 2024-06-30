using InvestmentPortfolioManagement.Data.Entities;
using InvestmentPortfolioManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace InvestmentPortfolioManagement.Common.AutoMapper
{
    public class MappingProfile: Profile
    {

        public MappingProfile()
        {
            CreateMap<FundoImobiliarioDTO, FundoImobiliario>()
            .ForMember(dest => dest.Quantidade, opt => opt.MapFrom(src => src.Quantidade))
            .ForMember(dest => dest.NomeFundo, opt => opt.MapFrom(src => src.NomeFundo))
            .ForMember(dest => dest.CorretoraExcutora, opt => opt.MapFrom(src => src.CorretoraExcutora))
            .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
            .ForMember(dest => dest.CodigoNegociacao, opt => opt.MapFrom(src => src.CodigoNegociacao));
        }
    }
}
