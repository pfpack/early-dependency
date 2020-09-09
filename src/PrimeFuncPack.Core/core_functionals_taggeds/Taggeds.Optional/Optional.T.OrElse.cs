﻿#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public T OrElse(T other)
            =>
            ImplFold(Pipeline.Pipe, () => other);

        public T OrElse(Func<T> otherFactory)
            =>
            ImplFold(Pipeline.Pipe, otherFactory);

        public Task<T> OrElseAsync(Func<Task<T>> otherFactoryAsync)
            =>
            ImplFold(Task.FromResult, otherFactoryAsync);

        public ValueTask<T> OrElseValueAsync(Func<ValueTask<T>> otherFactoryAsync)
            =>
            ImplFold(ValueTask.FromResult, otherFactoryAsync);
    }
}
