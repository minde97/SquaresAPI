using SquaresAPI.Data_Transfer_Objects;

namespace SquaresAPI.Services;

public interface IDataLayerService
{
	List<PointDto> GetListOfPoints();

	bool AddPoint(PointDto pointDto);

	bool DeletePoint(int id);

	bool AddListOfPoints(IEnumerable<PointDto> points);
}
