using SquaresAPI.Data_Transfer_Objects;

namespace SquaresAPI.Data;

public class Storage
{
	public Storage()
	{
		this.ListOfPoints = new List<PointDto>();
	}

	private List<PointDto> ListOfPoints;

	public void AddPoint(PointDto pointDto)
	{
		pointDto.Id = Helpers.Helpers.GetId(this.ListOfPoints.Count);
		this.ListOfPoints.Add(pointDto);
	}

	public List<PointDto> GetListOfPoints()
	{
		return this.ListOfPoints;
	}

	public void SetListOfPoints(IEnumerable<PointDto> points)
	{
		this.ListOfPoints = new List<PointDto>();

		foreach (var point in this.ListOfPoints)
		{
			point.Id = Helpers.Helpers.GetId(this.ListOfPoints.Count);
			this.ListOfPoints.Add(point);
		}
	}
}
