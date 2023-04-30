using AutoMapper;
using Moq;
using WebApi.Controllers;
using WebApi.Data;
using WebApi.Mapper;

namespace WebApi.UnitTests;

[TestClass]
public class ToDoControllerTests
{
    private static IMapper _mapper;

    [ClassInitialize]
    public static void ClassInitialize(TestContext testContext)
    {
        var mapperConfiguration = new MapperConfiguration(options =>
            options.AddProfile(new ToDoMapperProfile()));
        _mapper = mapperConfiguration.CreateMapper();
    }

    [TestMethod]
    public async Task Get_Should_ReturnToDoList()
    {
        // Arrange
        var mockRepository = new Mock<ITodoRepository>();
        mockRepository.Setup(repo => repo.ListAsync(null,null))
            .Returns(Task.FromResult(new List<ToDo>
            {
                new ToDo(),
                new ToDo(),
                new ToDo()
            }));
        var controller = new ToDoController(mockRepository.Object,_mapper);

        // Act
        var getToDosResponse = await controller.GetToDos();

        // Assert
        Assert.IsNotNull(getToDosResponse);
        Assert.AreEqual(3, getToDosResponse.Count);
    }
}