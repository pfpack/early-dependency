#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3>
    {   
        public static implicit operator Func<IServiceProvider, T3>(
            Dependency<T1, T2, T3> dependency)
            =>
            Pipeline.Pipe(
                dependency ?? throw new ArgumentNullException(nameof(dependency)))
            .thirdResolver;
    }
}