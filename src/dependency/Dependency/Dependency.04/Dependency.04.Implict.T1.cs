#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4>
    {
        public static implicit operator Func<IServiceProvider, T1>(
            Dependency<T1, T2, T3, T4> dependency)
            =>
            InternalToFirstResolver(
                dependency ?? throw new ArgumentNullException(nameof(dependency)));

        private static Func<IServiceProvider, T1> InternalToFirstResolver(
            Dependency<T1, T2, T3, T4> dependency)
            =>
            dependency.firstResolver;
    }
}