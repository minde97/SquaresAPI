using Microsoft.AspNetCore.Mvc;
using SquaresAPI.NSwag;
using SquaresAPI.Services;

namespace SquaresAPI.Controllers;

public class SquaresController : SquaresControllerBase
{
	private readonly ISquaresService squaresService;

	/// <summary>
	/// Initializes a new instance of the <see cref="SquaresController"/> class.
	/// </summary>
	/// <param name="squaresService">Points service.</param>
	/// <exception cref="ArgumentNullException">Throws if passed parameter(s) are null.</exception>
	public SquaresController(ISquaresService squaresService)
	{
		this.squaresService = squaresService ?? throw new ArgumentNullException();
	}

	/// <summary>
	/// Gets list of possible squares.
	/// </summary>
	/// <returns>List of squares</returns>
	public override async Task<ActionResult<ICollection<string>>> GetSquares(CancellationToken cancellationToken = default(CancellationToken))
	{
		return this.Ok(this.squaresService.GetSquares());
	}
}
