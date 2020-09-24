using AuthenticateMicroservices;
using AuthenticateMicroservices.Controllers;
using AuthenticateMicroservices.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;

namespace AuthenticateUnit
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsTokenNotNullIsTokenNotNull_When_ValidUserCredentialsAreUsed()
        {
            Mock<IConfiguration> config = new Mock<IConfiguration>();
            TokenController TokenObj = new TokenController(config.Object);
            var Result = TokenObj.AuthenticateUser(new User() { UserId=1, Password = "1234",Roles="Employee" });
            Assert.IsNotNull(Result);
        }

        [Test]
        public void IsTokenNull_When_InvalidUserCredentialsAreUsed()
        {
            Mock<IConfiguration> config = new Mock<IConfiguration>();
            var TokenObj = new TokenController(config.Object);
            var Result = TokenObj.AuthenticateUser(new User() { UserId=0, Password = "wronginput",Roles="wronginput" });
            Assert.IsNull(Result);
        }

    }
}