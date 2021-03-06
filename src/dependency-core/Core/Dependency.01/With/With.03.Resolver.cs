#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T>
    {
        public Dependency<T, T2, T3> With<T2, T3>(
            Func<IServiceProvider, T2> second,
            Func<IServiceProvider, T3> third)
            =>
            InternalWith(
                second ?? throw new ArgumentNullException(nameof(second)),
                third ?? throw new ArgumentNullException(nameof(third)));

        private Dependency<T, T2, T3> InternalWith<T2, T3>(
            Func<IServiceProvider, T2> secondResolver,
            Func<IServiceProvider, T3> thirdResolver)
            =>
            new(
                resolver, secondResolver, thirdResolver);
    }
}