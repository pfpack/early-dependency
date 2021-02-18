#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4, T5, T6>
    {
        public Dependency<TR1, TR2, TR3, TR4, TR5, TR6> Map<TR1, TR2, TR3, TR4, TR5, TR6>(
            Func<T1, TR1> mapFirst,
            Func<T2, TR2> mapSecond,
            Func<T3, TR3> mapThird,
            Func<T4, TR4> mapFourth,
            Func<T5, TR5> mapFifth,
            Func<T6, TR6> mapSixth)
            =>
            InternalMap(
                mapFirst ?? throw new ArgumentNullException(nameof(mapFirst)),
                mapSecond ?? throw new ArgumentNullException(nameof(mapSecond)),
                mapThird ?? throw new ArgumentNullException(nameof(mapThird)),
                mapFourth ?? throw new ArgumentNullException(nameof(mapFourth)),
                mapFifth ?? throw new ArgumentNullException(nameof(mapFifth)),
                mapSixth ?? throw new ArgumentNullException(nameof(mapSixth)));

        private Dependency<TR1, TR2, TR3, TR4, TR5, TR6> InternalMap<TR1, TR2, TR3, TR4, TR5, TR6>(
            Func<T1, TR1> mapFirst,
            Func<T2, TR2> mapSecond,
            Func<T3, TR3> mapThird,
            Func<T4, TR4> mapFourth,
            Func<T5, TR5> mapFifth,
            Func<T6, TR6> mapSixth)
            =>
            new(
                sp => sp.Pipe(firstResolver).Pipe(mapFirst),
                sp => sp.Pipe(secondResolver).Pipe(mapSecond),
                sp => sp.Pipe(thirdResolver).Pipe(mapThird),
                sp => sp.Pipe(fourthResolver).Pipe(mapFourth),
                sp => sp.Pipe(fifthResolver).Pipe(mapFifth),
                sp => sp.Pipe(sixthResolver).Pipe(mapSixth));
    }
}