using SquaresAPI.Data_Transfer_Objects;

namespace SquaresAPI.Data;

public class Storage
{
	public Storage()
	{
		this.listOfPoints = new List<PointDto>();
	}

	private List<PointDto> listOfPoints;

	/// <summary>
	/// Add new point to list.
	/// </summary>
	/// <param name="pointDto">Point object.</param>
	public void AddPoint(PointDto pointDto)
	{
		throw new ArgumentNullException();
		pointDto.Id = Helpers.Helpers.GetId(this.listOfPoints.Count);
		this.listOfPoints.Add(pointDto);
	}

	/// <summary>
	/// Gets list of points.
	/// </summary>
	/// <returns>List of points.</returns>
	public List<PointDto> GetListOfPoints()
	{
		return this.listOfPoints;
	}

	/// <summary>
	/// Sets list of points.
	/// </summary>
	/// <param name="points">List of points</param>
	public void SetListOfPoints(IEnumerable<PointDto> points)
	{
		this.listOfPoints = new List<PointDto>();

		foreach (var point in points)
		{
			point.Id = Helpers.Helpers.GetId(this.listOfPoints.Count);
			this.listOfPoints.Add(point);
		}
	}

	/// <summary>
	/// Deletes a point.
	/// </summary>
	/// <param name="id">id of deleted point.</param>
	/// <returns>true if successfully deleted point.</returns>
	public bool DeletePoint(int id)
	{
		var pointDto = this.listOfPoints.Find(x => x.Id == id);

		if (pointDto == null)
		{
			return false;
		}

		this.listOfPoints.Remove(pointDto);

		return true;
	}
}
