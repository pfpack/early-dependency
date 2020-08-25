﻿#nullable enable

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        private static InvalidOperationException CreateNotSuccessException()
            =>
            CreateNotCategoryException(CategorySuccess);

        private static InvalidOperationException CreateNotFailureException()
            =>
            CreateNotCategoryException(CategoryFailure);

        private static InvalidOperationException CreateNotCategoryException(in string category)
            =>
            new InvalidOperationException($"The result does not represent a {category} instance.");
    }
}
