using AutoMapper;
using SquaresAPI.Data_Transfer_Objects;

namespace SquaresAPI.Services;

public class PointsService : IPointsService
{
	private readonly IDataLayerService dataLayerService;

	public PointsService(IDataLayerService dataLayerService)
	{
		this.dataLayerService = dataLayerService ?? throw new ArgumentNullException(nameof(dataLayerService));
	}

	public IEnumerable<PointDto> GetListOfPoints()
	{
		return this.dataLayerService.GetListOfPoints();
	}

	public bool AddPoint(PointDto point)
	{
		return this.dataLayerService.AddPoint(point);
	}

	public bool AddListOfPoints(IEnumerable<PointDto> body)
	{
		return this.dataLayerService.AddListOfPoints(body);
	}

	public bool DeletePoint()
	{
		throw new NotImplementedException();
	}
}
