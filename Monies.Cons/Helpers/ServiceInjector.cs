using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace Monies.Cons
{
    public static class ServiceInjector {
        static ServiceProvider _services;
        public static void Configure() {
            var svcCollection = new ServiceCollection();
            svcCollection.AddLogging(opt => {
                opt.AddFilter("Monies.Cons.Program", LogLevel.Debug);
                opt.AddConsole();
            });

            ConfigureServices(svcCollection);

            _services = svcCollection.BuildServiceProvider();
        }

        public static ILogger Logger<T>()
        {
            return _services.GetService<ILoggerFactory>().CreateLogger<T>();
        }

        private static void ConfigureServices(ServiceCollection svcCollection) {

        }
    }
}