using SquaresAPI.Data_Transfer_Objects;

namespace SquaresAPI.Services;

public class PointsService : IPointsService
{
	private readonly IDataLayerService dataLayerService;

	public PointsService(IDataLayerService dataLayerService)
	{
		this.dataLayerService = dataLayerService ?? throw new ArgumentNullException(nameof(dataLayerService));
	}

	/// <summary>
	/// Gets all possible squares.
	/// </summary>
	/// <returns>List of squares.</returns>
	public IEnumerable<PointDto> GetListOfPoints()
	{
		return this.dataLayerService.GetListOfPoints();
	}

	/// <summary>
	/// Gets all possible squares.
	/// </summary>
	/// <returns>List of squares.</returns>
	public bool AddPoint(PointDto point)
	{
		return this.dataLayerService.AddPoint(point);
	}

	/// <summary>
	/// Sets list of points.
	/// </summary>
	/// <param name="points">List of Points</param>
	/// <returns>true if succeeded to set list of points.</returns>
	public bool AddListOfPoints(IEnumerable<PointDto> body)
	{
		return this.dataLayerService.AddListOfPoints(body);
	}

	/// <summary>
	/// Deletes a point.
	/// </summary>
	/// <param name="id">id of point to be deleted.</param>
	/// <returns>true if succeeded to delete a point.</returns>
	public bool DeletePoint(int id)
	{
		return this.dataLayerService.DeletePoint(id);
	}
}
