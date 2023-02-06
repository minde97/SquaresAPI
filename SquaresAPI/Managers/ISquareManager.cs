using SquaresAPI.Data_Transfer_Objects;

namespace SquaresAPI.Managers;

public interface ISquareManager
{
	/// <summary>
	/// Gets all possible squares from set of points.
	/// </summary>
	/// <param name="points">List of Points</param>
	/// <returns>List of squares.</returns>
	public IEnumerable<string> GetListOfPossibleSquares(List<PointDto> points);
}
