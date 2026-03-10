using EHU.Core.Driver;
using NUnit.Framework;

namespace EHU.NUnit
{
    public abstract class TestBase
    {
        [SetUp]
        public void Setup()
        {
            
            DriverSingleton.GetDriver();
        }

        [TearDown]
        public void TearDown()
        {
            DriverSingleton.QuitDriver();
        }
    }
}