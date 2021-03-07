#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4, T5, T6>
    {
        public Dependency<T1, T2, T3, T4, T5, T6, T7, T8> With<T7, T8>(
            Dependency<T7, T8> other)
            =>
            throw new NotImplementedException();

        private Dependency<T1, T2, T3, T4, T5, T6, T7, T8> InternalWith<T7, T8>(
            Dependency<T7, T8> other)
            =>
            new(
                firstResolver,
                secondResolver,
                thirdResolver,
                fourthResolver,
                fifthResolver,
                sixthResolver,
                other.ToFirstResolver(),
                other.ToSecondResolver());
    }
}