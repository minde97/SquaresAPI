namespace SquaresAPI.Services;

public interface ISquaresService
{
	/// <summary>
	/// Gets all possible squares.
	/// </summary>
	/// <returns>List of squares.</returns>
	public IEnumerable<string> GetSquares();
}
