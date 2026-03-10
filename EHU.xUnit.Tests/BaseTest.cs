using EHU.Core.Driver;

namespace EHU.XUnit
{
    public abstract class TestBase : IDisposable
    {
        protected TestBase()
        {
            // Singleton создаёт драйвер
            DriverSingleton.GetDriver();
        }

        public void Dispose()
        {
            DriverSingleton.QuitDriver();
        }
    }
}