using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SquaresAPI.Data_Transfer_Objects;
using SquaresAPI.NSwag;
using SquaresAPI.Services;

namespace SquaresAPI.Controllers;

public class PointsController : PointsControllerBase
{
	private readonly IPointsService pointsService;
	private readonly IMapper mapper;

	/// <summary>
	/// Initializes a new instance of the <see cref="PointsController"/> class.
	/// </summary>
	/// <param name="pointsService">Points service.</param>
	/// <param name="mapper">Mapper.</param>
	/// <exception cref="ArgumentNullException">Throws if passed parameter(s) are null.</exception>
	public PointsController(IPointsService pointsService, IMapper mapper)
	{
		this.pointsService = pointsService ?? throw new ArgumentNullException(nameof(pointsService));
		this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
	}

	/// <summary>
	/// Gets list of points.
	/// </summary>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>List of points</returns>
	public override async Task<ActionResult<ICollection<Point>>> Points(CancellationToken cancellationToken = default(CancellationToken))
	{
		return this.Ok(this.pointsService.GetListOfPoints());
	}

	/// <summary>
	/// Add list of points.
	/// </summary>
	/// <param name="body">Point object.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>List of points successfully added.</returns>
	public override async Task<IActionResult> AddList(IEnumerable<Point>? body, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (body == null)
		{
			return this.BadRequest("Please provide correct JSON containing a list of points.");
		}

		var listOfPoints = body.Select(p => this.mapper.Map<PointDto>(p));

		if (this.pointsService.AddListOfPoints(listOfPoints))
		{
			return this.StatusCode(StatusCodes.Status201Created, "List successfully saved.");
		}

		return this.StatusCode(500, "Could not save list of points");
	}

	/// <summary>
	/// Add new point.
	/// </summary>
	/// <param name="body">Point object.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>ID of point that has been successfully added.</returns>
	public override async Task<ActionResult<int>> AddPoint(Point? body, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (body == null)
		{
			return this.BadRequest("Please provide correct JSON containing point object.");
		}

		var pointDto = this.mapper.Map<PointDto>(body);

		if (this.pointsService.AddPoint(pointDto))
		{
			return this.StatusCode(StatusCodes.Status201Created, pointDto.Id);
		}

		return this.StatusCode(500, "Could not save point.");
	}

	/// <summary>
	/// Delete a point.
	/// </summary>
	/// <param name="id">ID of point to be deleted</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>Point has been successfully deleted.</returns>
	public override async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (id <= 0)
		{
			return this.BadRequest($"Id value should be higher than 0.");
		}

		if (this.pointsService.DeletePoint(id))
		{
			return this.NoContent();
		}

		return this.NotFound($"Point with Id '{id}' does not exist.");
	}
}
