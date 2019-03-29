namespace UnitTests
{
    using AutoFixture;
    using FluentAssertions;
    using Moq;
    using NUnit.Framework;
    using StackOverflow.UrlHandling;
    using UnitTests.Autofixture_Helper;

    [TestFixture]
    public class UrlManagerTests
    {
        private UrlManager urlManager;
        private Mock<IUrlBuilder> urlBuilder;

        [SetUp]
        public void SetUp()
        {
            urlManager = new UrlManager();
            urlBuilder = new Mock<IUrlBuilder>();
        }

        [Test]
        public void GetUrl_Success()
        {
            // Arrange
            urlBuilder.Setup(call => call.ConstructUrl(It.IsAny<SearchUrl>()))
                .Returns(AutoFixtureHelper.Generator.Create<string>());

            // Act
            var result = urlManager.GetUrl(AutoFixtureHelper.Generator.Create<SearchUrl>());

            // Assert
            result.Should().BeOfType(typeof(string));
        }

        [TearDown]
        public void TearDown()
        {
            urlBuilder.Invocations.Clear();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            urlBuilder = null;
        }
    }
}
