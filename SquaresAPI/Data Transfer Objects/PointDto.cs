namespace SquaresAPI.Data_Transfer_Objects;

public class PointDto
{
	public PointDto()
	{
	}

	public PointDto(int XCoordinate, int YCoordinate)
	{
		this.XCoordinate = XCoordinate;
		this.YCoordinate = YCoordinate;
	}

	public int Id { get; set; }

	public int XCoordinate { get; set; }

	public int YCoordinate { get; set; }
}
