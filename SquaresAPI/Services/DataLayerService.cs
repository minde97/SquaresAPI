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

	public List<PointDto> GetListOfPoints()
	{
		return this.storage.GetListOfPoints();
	}

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

	public bool DeletePoint(int id)
	{
		throw new NotImplementedException();
	}

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
