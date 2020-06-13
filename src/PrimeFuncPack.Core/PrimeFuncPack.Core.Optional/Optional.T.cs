﻿#nullable enable

namespace System
{
    public readonly partial struct Optional<T> :
        IEquatable<Optional<T>>,
        ISamenessPossessor<Optional<T>>
    {
        private readonly Box<T>? box;

        public bool IsPresent => box is object;

        public bool IsAbsent => box is null;

        public T Value => box ?? throw new InvalidOperationException("The optional does not have a value.");

        public static implicit operator T(in Optional<T> optional)
            =>
            optional.Value;

        public override string? ToString()
            =>
            box switch { null => string.Empty, var present => present.ToString() };
    }
}
