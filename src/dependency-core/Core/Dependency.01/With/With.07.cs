#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T>
    {
        public Dependency<T, T2, T3, T4, T5, T6, T7> With<T2, T3, T4, T5, T6, T7>(
            Dependency<T2, T3, T4, T5, T6, T7> other)
            =>
            InternalWith(
                other ?? throw new ArgumentNullException(nameof(other)));

        private Dependency<T, T2, T3, T4, T5, T6, T7> InternalWith<T2, T3, T4, T5, T6, T7>(
            Dependency<T2, T3, T4, T5, T6, T7> other)
            =>
            new(
                resolver,
                other.ToFirstResolver(),
                other.ToSecondResolver(),
                other.ToThirdResolver(),
                other.ToFourthResolver(),
                other.ToFifthResolver(),
                other.ToSixthResolver());
    }
}