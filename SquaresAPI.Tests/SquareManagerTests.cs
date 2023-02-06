using SquaresAPI.Data_Transfer_Objects;
using SquaresAPI.Managers;

namespace SquaresAPI.Tests;

[TestClass]
public class SquareManagerTests
{
	private SquareManager squareManager;

	[TestInitialize]
	public void Initialize()
	{
		this.squareManager = new SquareManager();
	}

	[TestMethod]
	public void GivenEmptyListOfPointsShouldReturnEmptyList()
	{
		//Arrange
		var emptyList = new List<PointDto>();

		//Act
		var result = this.squareManager.GetListOfPossibleSquares(emptyList);

		//Assert
		Assert.AreEqual(0, result.Count());
	}

	[TestMethod]
	public void GivenListOfPointsShouldReturnStringOfPossibleSquares()
	{
		//Arrange
		var listOfPoints = new List<PointDto>()
		{
			new (0,0),
			new (0,1),
			new (1,0),
			new (1,1),
			new (1,2),
			new (2,1),
			new (2,2),
		};

		//Act
		var result = this.squareManager.GetListOfPossibleSquares(listOfPoints).ToList();

		//Assert
		Assert.AreEqual(3, result.Count);
		Assert.IsTrue(result.Contains("(0;0), (0;1), (1;0), (1;1)"));
		Assert.IsTrue(result.Contains("(0;1), (1;2), (1;0), (2;1)"));
		Assert.IsTrue(result.Contains("(1;1), (1;2), (2;1), (2;2)"));
	}
}
