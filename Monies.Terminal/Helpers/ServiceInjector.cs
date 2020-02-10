using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Monies.Terminal.Helpers;
using Monies.Database;
using System.Collections.Generic;

namespace Monies.Terminal
{
    public static class ServiceInjector {
        static IServiceProvider _services;

        static Stack<IServiceScope> _scopeStack;

        static IServiceProvider _provider => _scopeStack.NullPeek()?.ServiceProvider ?? _services;
        public static void Configure() {
            var svcCollection = new ServiceCollection();
            svcCollection.AddLogging(opt => {
                //opt.AddFilter("Monies.Cons.Program", LogLevel.Debug);
                //opt.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning);
                //opt.AddFilter("Microsoft.EntityFrameworkCore.Infrastructure", LogLevel.Warning);
                opt.AddFile();
            });
            
            var connString = Settings.GetConnString();
            svcCollection.AddDbContext<MoniesDbContext>(opts => opts.UseNpgsql(connString, o => o.SetPostgresVersion(9, 6)));

            svcCollection.AddScreens();

            ConfigureServices(svcCollection);

            _services = svcCollection.BuildServiceProvider();
            _scopeStack = new Stack<IServiceScope>();
        }

        public static ILogger<T> Logger<T>()
        {
            return _provider.GetService<ILoggerFactory>().CreateLogger<T>();
        }

        public static T GetService<T>()
        {
            return _provider.GetService<T>();
        }

        public static void StartScope()
        {
            _scopeStack.Push(_services.CreateScope());
        }

        public static IServiceScope NewScope()
        {
            return _services.CreateScope();
        }

        public static void KillScope() 
        {
            if(_scopeStack.TryPop(out IServiceScope scope))
            {
                scope.Dispose();
            }
        }

        private static void ConfigureServices(ServiceCollection svcCollection) {

        }
    }
}