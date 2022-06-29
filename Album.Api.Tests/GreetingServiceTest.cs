using Album.Api.Services;
using System;
using System.Net;
using Xunit;

namespace Album.Api.Tests
{
    public class GreetingServiceTest
    {

        [Fact]
        public void When_name_Given_Correctly()
        {
            String HostName = Dns.GetHostName();

            //arrange
            var expected = $"Hello TestOne {HostName} v2";
            var name = "TestOne";

            //act
            var actual = GreetingService.CheckNameExists(name);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void When_EmptySting_Given_For_Name()
        {
            String HostName = Dns.GetHostName();

            //arrange
            var expected = $"Hello World {HostName} v2";
            var name = "";

            //act
            var actual = GreetingService.CheckNameExists(name);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void When_Null_Given_For_Name()
        {
            String HostName = Dns.GetHostName();

            //arrange
            var expected = $"Hello World {HostName} v2";
            string name = null;

            //act
            var actual = GreetingService.CheckNameExists(name);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
