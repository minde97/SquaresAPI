using SquaresAPI.Data_Transfer_Objects;
using SquaresAPI.Helpers;

namespace SquaresAPI.Managers;

public class SquareManager : ISquareManager
{
	private readonly PointsEqualityComparer pointsEqualityComparer;

	public SquareManager()
	{
		this.pointsEqualityComparer =  new PointsEqualityComparer();
	}

	/// <summary>
	/// Gets all possible squares from set of points.
	/// </summary>
	/// <param name="points">List of Points</param>
	/// <returns>List of squares.</returns>
	public IEnumerable<string> GetListOfPossibleSquares(List<PointDto> pointsList)
	{
		return this.CalculatePossibleSquares(pointsList);
	}

	private IEnumerable<string> CalculatePossibleSquares(List<PointDto> pointsList)
	{
		if (pointsList.Count == 0)
		{
			return new List<string>();
		}

		var listOfPoints = pointsList;
		var queue = new Queue<PointDto>(pointsList);
		var pointA = new PointDto();
		var pointB = new PointDto();
		var squares = new List<string>();
		var pivot = queue.Dequeue();

		while (queue.Count != 0)
		{

			listOfPoints.Remove(pivot);
			foreach (var point in queue)
			{
				var dx = point.YCoordinate - pivot.YCoordinate;
				var dy = pivot.XCoordinate - point.XCoordinate;

				pointA.XCoordinate = pivot.XCoordinate + dx;
				pointA.YCoordinate = pivot.YCoordinate + dy;

				pointB.XCoordinate = point.XCoordinate + dx;
				pointB.YCoordinate = point.YCoordinate + dy;

				if (this.CheckIfListContainsPoints(pointA, pointB, listOfPoints))
				{
					squares.Add(Helpers.Helpers.PointsToString(pivot, point, pointA, pointB));
				}
			}

			pivot = queue.Dequeue();
		}

		return squares;
	}

	private bool CheckIfListContainsPoints(PointDto pointA, PointDto pointB, List<PointDto> pointsList)
	{
		return pointsList.Contains(pointA, pointsEqualityComparer) && pointsList.Contains(pointB, pointsEqualityComparer);
	}
}
