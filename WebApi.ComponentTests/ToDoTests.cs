using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using WebApi.Models;

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
        var body = await response.Content.ReadAsStringAsync();
        var recievedToDos = JsonSerializer.Deserialize<List<ToDoDto>>(body);
        Assert.IsNotNull(recievedToDos);
        Assert.AreEqual(0,recievedToDos.Count);
        
    }
}