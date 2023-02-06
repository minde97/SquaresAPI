using SquaresAPI.Data_Transfer_Objects;

namespace SquaresAPI.Helpers;

public class PointsEqualityComparer : EqualityComparer<PointDto>
{

	public override bool Equals(PointDto? x, PointDto? y)
	{
		return y != null && x != null && x.XCoordinate == y.XCoordinate && x.YCoordinate == y.YCoordinate;

	}

	public override int GetHashCode(PointDto obj)
	{
		return base.GetHashCode();
	}
}
