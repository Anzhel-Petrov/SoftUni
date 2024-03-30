using System;
using Microsoft.Extensions.DependencyInjection;

namespace MicrosoftDependencyInjection.DI
{
    public class DIContainer 
    {
        public IServiceProvider BuildServiceProvider()
        {
            ServiceCollection services = new ServiceCollection();

            return services.BuildServiceProvider();
        }
    }
}
