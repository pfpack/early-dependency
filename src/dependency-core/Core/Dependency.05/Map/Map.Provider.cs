#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4, T5>
    {
        public Dependency<TResult1, TResult2, TResult3, TResult4, TResult5> Map<TResult1, TResult2, TResult3, TResult4, TResult5>(
            Func<IServiceProvider, T1, TResult1> mapFirst,
            Func<IServiceProvider, T2, TResult2> mapSecond,
            Func<IServiceProvider, T3, TResult3> mapThird,
            Func<IServiceProvider, T4, TResult4> mapFourth,
            Func<IServiceProvider, T5, TResult5> mapFifth)
            =>
            InternalMap(
                mapFirst ?? throw new ArgumentNullException(nameof(mapFirst)),
                mapSecond ?? throw new ArgumentNullException(nameof(mapSecond)),
                mapThird ?? throw new ArgumentNullException(nameof(mapThird)),
                mapFourth ?? throw new ArgumentNullException(nameof(mapFourth)),
                mapFifth ?? throw new ArgumentNullException(nameof(mapFifth)));

        private Dependency<TResult1, TResult2, TResult3, TResult4, TResult5> InternalMap<TResult1, TResult2, TResult3, TResult4, TResult5>(
            Func<IServiceProvider, T1, TResult1> mapFirst,
            Func<IServiceProvider, T2, TResult2> mapSecond,
            Func<IServiceProvider, T3, TResult3> mapThird,
            Func<IServiceProvider, T4, TResult4> mapFourth,
            Func<IServiceProvider, T5, TResult5> mapFifth)
            =>
            new(
                sp => sp.Pipe(firstResolver).Pipe(first => mapFirst.Invoke(sp, first)),
                sp => sp.Pipe(secondResolver).Pipe(second => mapSecond.Invoke(sp, second)),
                sp => sp.Pipe(thirdResolver).Pipe(third => mapThird.Invoke(sp, third)),
                sp => sp.Pipe(fourthResolver).Pipe(fourth => mapFourth.Invoke(sp, fourth)),
                sp => sp.Pipe(fifthResolver).Pipe(fifth => mapFifth.Invoke(sp, fifth)));
    }
}