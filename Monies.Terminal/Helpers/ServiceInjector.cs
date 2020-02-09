using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Monies.Terminal.Helpers;
using Monies.Database;

namespace Monies.Terminal
{
    public static class ServiceInjector {
        static IServiceProvider _services;
        static IServiceScope _scope;

        static IServiceProvider _provider => _scope?.ServiceProvider ?? _services;
        public static void Configure() {
            var svcCollection = new ServiceCollection();
            svcCollection.AddLogging(opt => {
                opt.AddFilter("Monies.Cons.Program", LogLevel.Debug);
                opt.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning);
                opt.AddFilter("Microsoft.EntityFrameworkCore.Infrastructure", LogLevel.Warning);
                opt.AddConsole();
            });
            
            var connString = Settings.GetConnString();
            svcCollection.AddDbContext<MoniesDbContext>(opts => opts.UseNpgsql(connString, o => o.SetPostgresVersion(9, 6)));

            svcCollection.AddScreens();

            ConfigureServices(svcCollection);

            _services = svcCollection.BuildServiceProvider();
        }

        public static ILogger Logger<T>()
        {
            return _provider.GetService<ILoggerFactory>().CreateLogger<T>();
        }

        public static T GetService<T>()
        {
            return _provider.GetService<T>();
        }

        public static void StartScope()
        {
            KillScope();
            _scope = _services.CreateScope();
        }

        public static void KillScope() 
        {
            if(_scope != null)
            {
                _scope.Dispose();
                _scope = null;
            }
        }

        private static void ConfigureServices(ServiceCollection svcCollection) {

        }
    }
}