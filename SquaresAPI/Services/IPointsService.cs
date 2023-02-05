using SquaresAPI.Data_Transfer_Objects;

namespace SquaresAPI.Services;

public interface IPointsService
{
	IEnumerable<PointDto> GetListOfPoints();

	bool AddPoint(PointDto point);

	bool AddListOfPoints(IEnumerable<PointDto> points);

	bool DeletePoint();
}