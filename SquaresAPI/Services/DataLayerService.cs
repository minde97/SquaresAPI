using SquaresAPI.Data;
using SquaresAPI.Data_Transfer_Objects;

namespace SquaresAPI.Services;

public class DataLayerService : IDataLayerService
{
	private readonly Storage storage;

	public DataLayerService(Storage storage)
	{
		this.storage = storage ?? throw new ArgumentNullException(nameof(storage));
	}

	/// <summary>
	/// Gets list of points.
	/// </summary>
	/// <returns>List of points.</returns>
	public List<PointDto> GetListOfPoints()
	{
		return this.storage.GetListOfPoints();
	}

	/// <summary>
	/// Add point.
	/// </summary>
	/// <param name="pointDto">Point to be added.</param>
	/// <returns>true if succeeded to add point.</returns>
	public bool AddPoint(PointDto pointDto)
	{
		try
		{
			this.storage.AddPoint(pointDto);
			return true;
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return false;
		}
	}

	/// <summary>
	/// Deletes a point.
	/// </summary>
	/// <param name="id">id of point to be deleted.</param>
	/// <returns>true if succeeded to delete a point.</returns>
	public bool DeletePoint(int id)
	{
		try
		{
			return this.storage.DeletePoint(id);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return false;
		}
	}

	/// <summary>
	/// Sets list of points.
	/// </summary>
	/// <param name="points">List of Points</param>
	/// <returns>true if succeeded to set list of points.</returns>
	public bool AddListOfPoints(IEnumerable<PointDto> points)
	{
		try
		{
			this.storage.SetListOfPoints(points);

			return true;
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return false;
		}
	}
}
