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

	public PointsController(IPointsService pointsService, IMapper mapper)
	{
		this.pointsService = pointsService ?? throw new ArgumentNullException(nameof(pointsService));
		this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
	}

	public override async Task<ActionResult<ICollection<Point>>> Points(CancellationToken cancellationToken = default(CancellationToken))
	{
		return this.Ok(this.pointsService.GetListOfPoints());
	}

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

	public override async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (this.pointsService.DeletePoint())
		{
			return this.NoContent();
		}

		return this.StatusCode(500, "Could not save point.");
	}
}
