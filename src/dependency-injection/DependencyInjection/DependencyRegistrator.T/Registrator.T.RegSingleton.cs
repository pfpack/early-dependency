#nullable enable

using Microsoft.Extensions.DependencyInjection;

namespace PrimeFuncPack
{
    partial class DependencyRegistrator<T>
    {
        public IServiceCollection RegisterSingleton()
            =>
            services.AddSingleton(resolver);
    }
}