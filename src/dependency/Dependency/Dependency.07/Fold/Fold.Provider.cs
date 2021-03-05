#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4, T5, T6, T7>
    {
        public Dependency<TR> Fold<TR>(
            Func<IServiceProvider, T1, T2, T3, T4, T5, T6, T7, TR> fold)
            =>
            throw new NotImplementedException();
        
        private Dependency<TR> InternalFold<TR>(
            Func<IServiceProvider, T1, T2, T3, T4, T5, T6, T7, TR> fold)
            =>
            new(
                sp => fold.Invoke(
                    sp,
                    firstResolver.Invoke(sp),
                    secondResolver.Invoke(sp),
                    thirdResolver.Invoke(sp),
                    fourthResolver.Invoke(sp),
                    fifthResolver.Invoke(sp),
                    sixthResolver.Invoke(sp),
                    seventhResolver.Invoke(sp)));
    }
}