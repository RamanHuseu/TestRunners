using OpenQA.Selenium.Chrome;

namespace EHU.Core.Driver
{
    public class DriverOptionsBuilder
    {
        private readonly ChromeOptions _options;

        public DriverOptionsBuilder()
        {
            _options = new ChromeOptions();
        }

        public DriverOptionsBuilder WithNoSandbox()
        {
            _options.AddArgument("--no-sandbox");
            return this;
        }

        public DriverOptionsBuilder WithDisabledDevShm()
        {
            _options.AddArgument("--disable-dev-shm-usage");
            return this;
        }

        public DriverOptionsBuilder WithWindowSize(int width, int height)
        {
            _options.AddArgument($"--window-size={width},{height}");
            return this;
        }

        public DriverOptionsBuilder WithHeadless()
        {
            _options.AddArgument("--headless");
            return this;
        }

        public DriverOptionsBuilder WithDisabledGpu()
        {
            _options.AddArgument("--disable-gpu");
            return this;
        }

        public ChromeOptions Build()
        {
            return _options;
        }
    }
}