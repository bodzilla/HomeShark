using HomeShark.Api.Controllers;
using HomeShark.Core.Contracts.Services;
using HomeShark.Core.Dtos.Requests;
using HomeShark.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace HomeShark.UnitTests.Controllers
{
    public class AgentControllerTests
    {
        private readonly Mock<ILogger<AgentController>> _loggerMock;
        private readonly Mock<IAgentService> _serviceMock;
        private readonly AgentController _controller;

        public AgentControllerTests()
        {
            _loggerMock = new Mock<ILogger<AgentController>>();
            _serviceMock = new Mock<IAgentService>();
            _controller = new AgentController(_loggerMock.Object, _serviceMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsOkResult_WithListOfAgents()
        {
            var expectedAgents = new List<Agent> { new() };
            _serviceMock.Setup(service => service.GetAllAsync()).ReturnsAsync(expectedAgents);

            var result = await _controller.GetAllAsync();

            var actualObjectResult = Assert.IsType<OkObjectResult>(result);
            var actualAgents = Assert.IsType<List<Agent>>(actualObjectResult.Value);
            Assert.Equal(expectedAgents, actualAgents);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsBadRequest_OnException()
        {
            var expectedException = new Exception();
            _serviceMock.Setup(service => service.GetAllAsync()).ThrowsAsync(expectedException);

            var result = await _controller.GetAllAsync();

            Assert.IsType<BadRequestResult>(result);
            _loggerMock.Verify(
                x => x.Log(
                    It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.Is<Exception>(exception => exception == expectedException),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
                Times.Once);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsOkResult_WithAgent()
        {
            const int testId = 1;
            var expectedAgent = new Agent();
            _serviceMock.Setup(service => service.GetByIdAsync(testId)).ReturnsAsync(expectedAgent);


            var result = await _controller.GetByIdAsync(testId);

            var actualObjectResult = Assert.IsType<OkObjectResult>(result);
            var actualAgent = Assert.IsType<Agent>(actualObjectResult.Value);
            Assert.Equal(expectedAgent, actualAgent);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsNotFound_WhenNoAgentFound()
        {
            const int testId = 1;
            _serviceMock.Setup(service => service.GetByIdAsync(testId)).ReturnsAsync((Agent)null);

            var result = await _controller.GetByIdAsync(testId);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsBadRequest_OnException()
        {
            const int testId = 1;
            var expectedException = new Exception();
            _serviceMock.Setup(service => service.GetByIdAsync(testId)).ThrowsAsync(expectedException);

            var result = await _controller.GetByIdAsync(testId);

            Assert.IsType<BadRequestResult>(result);
            _loggerMock.Verify(
                x => x.Log(
                    It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.Is<Exception>(exception => exception == expectedException),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
                Times.Once);
        }

        [Fact]
        public async Task GetAllByContainsNameAsync_ReturnsOkResult_WithAgentList()
        {
            const string testName = "test";
            var agents = new List<Agent> { new(), new() };
            _serviceMock.Setup(service => service.GetAllByContainsNameAsync(testName)).ReturnsAsync(agents);

            var result = await _controller.GetAllByContainsNameAsync(testName);

            var actualObjectResult = Assert.IsType<OkObjectResult>(result);
            var actualAgents = Assert.IsType<List<Agent>>(actualObjectResult.Value);
            Assert.Equal(agents, actualAgents);
        }

        [Fact]
        public async Task GetAllByContainsNameAsync_ReturnsNotFound_WhenNoAgentsFound()
        {
            const string testName = "test";
            _serviceMock.Setup(service => service.GetAllByContainsNameAsync(testName)).ReturnsAsync(new List<Agent>());

            var result = await _controller.GetAllByContainsNameAsync(testName);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetAllByContainsNameAsync_ReturnsBadRequest_OnException()
        {
            const string testName = "test";
            var expectedException = new Exception();
            _serviceMock.Setup(service => service.GetAllByContainsNameAsync(testName)).ThrowsAsync(expectedException);

            var result = await _controller.GetAllByContainsNameAsync(testName);

            Assert.IsType<BadRequestResult>(result);
            _loggerMock.Verify(
                x => x.Log(
                    It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.Is<Exception>(exception => exception == expectedException),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
                Times.Once);
        }

        [Fact]
        public async Task AddAsync_ReturnsOkResult_WithAddedAgent()
        {
            var testRequest = new AddAgentRequest("TestName", "TestWebsite", "TestLogo");
            var expectedAgent = new Agent();
            _serviceMock.Setup(service => service.AddAsync(testRequest)).ReturnsAsync(expectedAgent);

            var result = await _controller.AddAsync(testRequest);

            var actualObjectResult = Assert.IsType<OkObjectResult>(result);
            var actualAgent = Assert.IsType<Agent>(actualObjectResult.Value);
            Assert.Equal(expectedAgent, actualAgent);
        }

        [Fact]
        public async Task AddAsync_ReturnsBadRequest_OnException()
        {
            var testRequest = new AddAgentRequest("TestName", "TestWebsite", "TestLogo");
            var expectedException = new Exception();
            _serviceMock.Setup(service => service.AddAsync(testRequest)).ThrowsAsync(expectedException);

            var result = await _controller.AddAsync(testRequest);

            Assert.IsType<BadRequestResult>(result);
            _loggerMock.Verify(
                x => x.Log(
                    It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.Is<Exception>(exception => exception == expectedException),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
                Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ReturnsOkResult_WithUpdatedAgent()
        {
            var testRequest = new UpdateAgentRequest(1, "TestName", "TestWebsite", "TestLogo");
            var expectedAgent = new Agent();
            _serviceMock.Setup(service => service.UpdateAsync(testRequest)).ReturnsAsync(expectedAgent);

            var result = await _controller.UpdateAsync(testRequest);

            var actualObjectResult = Assert.IsType<OkObjectResult>(result);
            var actualAgent = Assert.IsType<Agent>(actualObjectResult.Value);
            Assert.Equal(expectedAgent, actualAgent);
        }

        [Fact]
        public async Task UpdateAsync_ReturnsBadRequest_OnException()
        {
            var testRequest = new UpdateAgentRequest(1, "TestName", "TestWebsite", "TestLogo");
            var expectedException = new Exception();
            _serviceMock.Setup(service => service.UpdateAsync(testRequest)).ThrowsAsync(expectedException);

            var result = await _controller.UpdateAsync(testRequest);

            Assert.IsType<BadRequestResult>(result);
            _loggerMock.Verify(
                x => x.Log(
                    It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.Is<Exception>(exception => exception == expectedException),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
                Times.Once);
        }

        [Fact]
        public async Task SetInactiveAsync_ReturnsOkResult_WhenServiceSucceeds()
        {
            const int testId = 1;
            var expectedAgent = new Agent();
            _serviceMock.Setup(service => service.SetInactiveAsync(testId)).ReturnsAsync(expectedAgent);

            var result = await _controller.SetInactiveAsync(testId);

            var actualObjectResult = Assert.IsType<OkObjectResult>(result);
            var actualAgent = Assert.IsType<Agent>(actualObjectResult.Value);
            Assert.Equal(expectedAgent, actualAgent);
        }

        [Fact]
        public async Task SetInactiveAsync_ReturnsBadRequest_OnException()
        {
            const int testId = 1;
            var expectedException = new Exception();
            _serviceMock.Setup(service => service.SetInactiveAsync(testId)).ThrowsAsync(expectedException);

            var result = await _controller.SetInactiveAsync(testId);

            Assert.IsType<BadRequestResult>(result);
            _loggerMock.Verify(
                x => x.Log(
                    It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.Is<Exception>(exception => exception == expectedException),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
                Times.Once);
        }
    }
}
