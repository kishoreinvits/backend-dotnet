using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace WebApi.ComponentTests;

[TestClass]
public class ToDoTests
{
    private static WebApplicationFactory<Program> _testWebApplicationFactory = null!;
    private static HttpClient _client = null!;

    [ClassInitialize]
    public static void ClassInitialize(TestContext context)
    {
        _testWebApplicationFactory = new TestWebApplicationFactory<Program>();
        _client = _testWebApplicationFactory.CreateClient();
    }

    [ClassCleanup]
    public static void ClassCleanup()
    {
        _client.Dispose();
        _testWebApplicationFactory.Dispose();
    }
    
    [TestMethod]
    public async Task Get_Should_ReturnToDos()
    {
        // Arrange
        var request = new HttpRequestMessage(HttpMethod.Get, "api/ToDo");

        // Act
        var response = await _client.SendAsync(request);

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    }
}