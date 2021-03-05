#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2>
    {
        public Dependency<TR> Fold<TR>(
            Func<IServiceProvider, T1, T2, TR> fold)
            =>
            InternalFold(
                fold ?? throw new ArgumentNullException(nameof(fold)));
        
        private Dependency<TR> InternalFold<TR>(
            Func<IServiceProvider, T1, T2, TR> fold)
            =>
            new(
                sp => fold.Invoke(
                    sp,
                    firstResolver.Invoke(sp),
                    secondResolver.Invoke(sp)));
    }
}