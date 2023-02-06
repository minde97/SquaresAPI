using SquaresAPI.Data_Transfer_Objects;

namespace SquaresAPI.Services;

public interface IDataLayerService
{
	/// <summary>
	/// Gets list of points.
	/// </summary>
	/// <returns>List of points.</returns>
	List<PointDto> GetListOfPoints();

	/// <summary>
	/// Add point.
	/// </summary>
	/// <param name="pointDto">Point to be added.</param>
	/// <returns>true if succeeded to add point.</returns>
	bool AddPoint(PointDto pointDto);

	/// <summary>
	/// Deletes a point.
	/// </summary>
	/// <param name="id">id of point to be deleted.</param>
	/// <returns>true if succeeded to delete a point.</returns>
	bool DeletePoint(int id);

	/// <summary>
	/// Sets list of points.
	/// </summary>
	/// <param name="points">List of Points</param>
	/// <returns>true if succeeded to set list of points.</returns>
	bool AddListOfPoints(IEnumerable<PointDto> points);
}
