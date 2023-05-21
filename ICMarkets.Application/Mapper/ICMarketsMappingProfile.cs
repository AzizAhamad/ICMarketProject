using System;
using AutoMapper;
using ICMarkets.Application.Commands;
using ICMarkets.Application.Response;
using ICMarkets.Core.Entities;

namespace ICMarkets.Application.Mapper
{
	public class ICMarketsMappingProfile : Profile
    {
		public ICMarketsMappingProfile()
		{
            CreateMap<Btc, BtcResponse>().ReverseMap();
            CreateMap<Btc, CreateBtcCommand>().ReverseMap();
            CreateMap<Btc, EditBtcCommand>().ReverseMap();


            CreateMap<Dash, DashResponse>().ReverseMap();
            CreateMap<Dash, CreateDashCommand>().ReverseMap();
            CreateMap<Dash, EditDashCommand>().ReverseMap();


            CreateMap<Eth, EthResponse>().ReverseMap();
            CreateMap<Eth, CreateEthCommand>().ReverseMap();
            CreateMap<Eth, EditEthCommand>().ReverseMap();
        }
	}
}

