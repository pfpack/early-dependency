#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T>
    {
        public Dependency<T, T2, T3, T4, T5> With<T2, T3, T4, T5>(
            Dependency<T2, T3, T4, T5> other)
            =>
            InternalWith(
                other ?? throw new ArgumentNullException(nameof(other)));

        private Dependency<T, T2, T3, T4, T5> InternalWith<T2, T3, T4, T5>(
            Dependency<T2, T3, T4, T5> other)
            =>
            new(
                resolver,
                other.ToFirstResolver(),
                other.ToSecondResolver(),
                other.ToThirdResolver(),
                other.ToFourthResolver());
    }
}