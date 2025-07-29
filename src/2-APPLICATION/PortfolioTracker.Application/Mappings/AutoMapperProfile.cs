using AutoMapper;
using PortfolioTracker.Application.DTOs;
using PortfolioTracker.Domain.Entities;

namespace PortfolioTracker.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Ativo Mappings
            CreateMap<Ativo, AtivoDto>();
            CreateMap<CreateAtivoDto, Ativo>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.PrecoAtual, opt => opt.Ignore())
                .ForMember(dest => dest.DataUltimaAtualizacao, opt => opt.Ignore())
                .ForMember(dest => dest.DataCriacao, opt => opt.Ignore())
                .ForMember(dest => dest.IsAtivo, opt => opt.MapFrom(src => true));
            
            CreateMap<UpdateAtivoDto, Ativo>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Ticker, opt => opt.Ignore())
                .ForMember(dest => dest.PrecoAtual, opt => opt.Ignore())
                .ForMember(dest => dest.DataUltimaAtualizacao, opt => opt.Ignore())
                .ForMember(dest => dest.DataCriacao, opt => opt.Ignore());

            // Operacao Mappings
            CreateMap<Operacao, OperacaoDto>()
                .ForMember(dest => dest.AtivoTicker, opt => opt.MapFrom(src => src.Ativo.Ticker))
                .ForMember(dest => dest.AtivoNome, opt => opt.MapFrom(src => src.Ativo.Nome));
            
            CreateMap<CreateOperacaoDto, Operacao>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ValorTotal, opt => opt.MapFrom(src => src.Quantidade * src.Preco + src.Custos))
                .ForMember(dest => dest.DataCriacao, opt => opt.Ignore())
                .ForMember(dest => dest.Carteira, opt => opt.Ignore())
                .ForMember(dest => dest.Ativo, opt => opt.Ignore());
            
            CreateMap<UpdateOperacaoDto, Operacao>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ValorTotal, opt => opt.MapFrom(src => src.Quantidade * src.Preco + src.Custos))
                .ForMember(dest => dest.CarteiraId, opt => opt.Ignore())
                .ForMember(dest => dest.AtivoId, opt => opt.Ignore())
                .ForMember(dest => dest.DataCriacao, opt => opt.Ignore())
                .ForMember(dest => dest.Carteira, opt => opt.Ignore())
                .ForMember(dest => dest.Ativo, opt => opt.Ignore());
        }
    }
}

