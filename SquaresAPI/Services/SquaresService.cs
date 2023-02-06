using SquaresAPI.Managers;

namespace SquaresAPI.Services;

public class SquaresService : ISquaresService
{
	private readonly IDataLayerService dataLayerService;
	private readonly ISquareManager squareManager;

	public SquaresService(IDataLayerService dataLayerService, ISquareManager squareManager)
	{
		this.dataLayerService = dataLayerService ?? throw new ArgumentNullException(nameof(dataLayerService));
		this.squareManager = squareManager ?? throw new ArgumentNullException(nameof(squareManager));
	}

	/// <summary>
	/// Gets all possible squares.
	/// </summary>
	/// <returns>List of squares.</returns>
	public IEnumerable<string> GetSquares()
	{
		return this.squareManager.GetListOfPossibleSquares(this.dataLayerService.GetListOfPoints());
	}
}
