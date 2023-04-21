using WebApi.Controllers;

namespace WebApi.UnitTests;

[TestClass]
public class ToDoControllerTests
{
    [TestMethod]
    public void Get_Should_ReturnToDoList()
    {
        // Arrange
        var controller = new ToDoController();

        // Act
        var getToDosResponse = controller.GetToDos();

        // Assert
        Assert.IsNotNull(getToDosResponse);
        Assert.AreNotEqual(0, getToDosResponse.Count());
    }
}