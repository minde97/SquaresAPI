using AutoMapper;
using SquaresAPI.Data_Transfer_Objects;
using SquaresAPI.NSwag;

namespace SquaresAPI;

public class AutoMapperProfile : Profile
{
	public AutoMapperProfile()
	{
		CreateMap<Point, PointDto>();
	}
}
