// https://www.youtube.com/watch?v=JV6u4xfyaM8&list=PL82C6-O4XrHeyeJcI5xrywgpfbrqdkQd4&index=8

using CalculatorXUnit.DNS;
using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Extensions;
using NetworkUtility.Ping;
using System.Net.NetworkInformation;

namespace CalculatorXUnit.PingTests
{
    public class NetWorkServiceTests
    {
        private readonly NetworkService _pingService;
        private readonly IDNS _dNS;

        public NetWorkServiceTests()
        {

            // Dependencies
            _dNS = A.Fake<IDNS>();

            // SUT
            _pingService = new NetworkService(_dNS);
        }

        [Fact]
        public void NetworkService_SendPing_ReturnString()
        {
            // Arrange - Variables, classes, mocks
            //var pingService = new NetworkService();
            A.CallTo(() => _dNS.SendDNS()).Returns(true);


            // Act
            var result = _pingService.SendPing();

            // Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Success: Ping Sent!");
            result.Should().Contain("Success", Exactly.Once());
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        public void NetworkService_PingTimeout_ReturnInt(int a, int b, int expected)
        {
            // Arrange
            //var pingService = new NetworkService();

            // Act
            var result = _pingService.PingTimeout(a, b);

            // Assert
            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(2);
            result.Should().NotBeInRange(-10000, 0);
        }

        [Fact]
        public void NetworkService_lastPingDate_ReturnDate()
        {
            // Arrange
            //var pingService = new NetworkService();

            // Act
            var result = _pingService.LastPingDate();
            // Assert
            result.Should().BeAfter(1.January(2010));
            result.Should().BeBefore(1.January(2030));
        }

        [Fact]
        public void NetworkService_GetPingOptions_ReturnsObject()
        {
            //Arrange
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };

            // Act
            var result = _pingService.MostRecentPings();

            // Assert WARNING: "BE" careful
            result.Should().BeOfType<PingOptions[]>();
            result.Should().BeAssignableTo<IEnumerable<PingOptions>>();
            result.Should().ContainEquivalentOf(expected);
            result.Should().Contain(x => x.DontFragment == true);
        }

    }
}
