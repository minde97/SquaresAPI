using SquaresAPI.Data_Transfer_Objects;

namespace SquaresAPI.Helpers;

public static class Helpers
{
	public static int GetId(int lengthOfList)
	{
		return lengthOfList + 1;
	}

	public static string PointsToString(PointDto pointA, PointDto pointB, PointDto pointC, PointDto pointD)
	{
		return $"({pointA.XCoordinate};{pointA.YCoordinate}), "
		       + $"({pointB.XCoordinate};{pointB.YCoordinate}), "
		       + $"({pointC.XCoordinate};{pointC.YCoordinate}), "
		       + $"({pointD.XCoordinate};{pointD.YCoordinate})";
	}
}
