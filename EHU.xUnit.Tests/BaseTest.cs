using EHU.Core.Driver;

namespace EHU.XUnit
{
    public abstract class TestBase : IDisposable
    {
        protected TestBase()
        {
            
            DriverSingleton.GetDriver();
        }

        public void Dispose()
        {
            DriverSingleton.QuitDriver();
        }
    }
}