#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4, T5>
    {
        public Func<IServiceProvider, T1> ToFirstResolver()
            =>
            firstResolver;
        
        public static implicit operator Func<IServiceProvider, T1>(
            Dependency<T1, T2, T3, T4, T5> dependency)
            =>
            Pipeline.Pipe(
                dependency ?? throw new ArgumentNullException(nameof(dependency)))
            .firstResolver;
    }
}