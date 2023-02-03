using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teacher.Extensions;

namespace teacher.Test.Unit
{
    internal class ProgramStart
    {
        WebApplicationBuilder builder;

        [SetUp]
        public void Setup()
        {
            builder = WebApplication.CreateBuilder();
            builder.Services.AddConfigs("\\.env.test");

        }

        [Test, Order(3)]
        [TestCase("DEVELOP_USER", "userName")]
        [TestCase("DEVELOP_PW", "My123PW!VeryStr0ng")]
        [TestCase("PRODUCTION_USER", "adminUser")]
        [TestCase("PRODUCTION_PW", "Strong!Strong!PW!")]
        public void ConfigFileRead(string variableName, string expectedValue)
        {
            Assert.That(Environment.GetEnvironmentVariable(variableName), Is.EqualTo(expectedValue));
        }


        [Test, Order(5)]
        [TestCase(true, "Server=myServer;User ID={USERNAME};Password={PASSWORD}","Server=myServer;User ID=userName;Password=My123PW!VeryStr0ng")]
        [TestCase(false, "Server=myServer;User ID={USERNAME};Password={PASSWORD}", "Server=myServer;User ID=adminUser;Password=Strong!Strong!PW!")]
        [TestCase(true, "Server=myServer;", "Server=myServer;")]
        public void GetConnectionStringWithValues(bool isDevelopment, string input, string output)
        {
            Assert.That(ServiceExtensions.GetConnectionStringWithValues(isDevelopment,input), Is.EqualTo((string)output));
        }

    }
}
