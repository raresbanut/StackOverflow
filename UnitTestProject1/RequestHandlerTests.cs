namespace UnitTests
{
    using System.Net.Http;
    using AutoFixture;
    using FluentAssertions;
    using Moq;
    using NUnit.Framework;
    using StackOverflow;
    using StackOverflow.Response;
    using StackOverflow.UrlHandling;
    using Autofixture_Helper;

    [TestFixture]
    public class RequestHandlerTests
    {
        private RequestManager requestManager;
        private Mock<IUrlManager> urlManager;
        private Mock<IHttpClientManager> httpClientManager;

        [SetUp]
        public void SetUp()
        {
            urlManager = new Mock<IUrlManager>();
            httpClientManager = new Mock<IHttpClientManager>();
            requestManager = new RequestManager();
        }

        [Test]
        public void Search_SuccessAsync()
        {
            // Arrange
            httpClientManager.Setup(call => call.GetHttpClient()).Returns(AutoFixtureHelper.Generator.Create<HttpClient>());

            urlManager.Setup(call => call.GetUrl(It.IsAny<SearchUrl>()))
                .Returns(AutoFixtureHelper.Generator.Create<string>());

            // Act
            var result = requestManager.Search(AutoFixtureHelper.Generator.Create<SearchUrl>()).Result;

            // Assert
            result.Should().BeOfType(typeof(ResponseContent));
        }

        [TearDown]
        public void TearDown()
        {
            urlManager.Invocations.Clear();
            httpClientManager.Invocations.Clear();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            urlManager = null;
            httpClientManager = null;
        }

    }
}
