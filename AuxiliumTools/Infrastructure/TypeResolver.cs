using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuxiliumServices.AdminTools.Infrastructure
{
    internal sealed class TypeResolver(IServiceProvider provider) : ITypeResolver, IDisposable
    {
        public object? Resolve(Type? type) =>
            type is null ? null : provider.GetService(type);

        public void Dispose()
        {
            if (provider is IDisposable disposable)
                disposable.Dispose();
        }
    }
}
