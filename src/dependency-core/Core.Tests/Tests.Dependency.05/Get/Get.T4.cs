#nullable enable

using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FiveDependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void GetFourth_ExpectResolvedValueIsEqualToFourthSource(
            StructType fourthSource)
        {
            var source = Dependency.Create(
                _ => MinusFifteenIdSomeStringNameRecord,
                _ => MinusFifteen,
                _ => EmptyString,
                _ => fourthSource,
                _ => ZeroIdRefType);

            var actual = source.GetFourth();

            var actualValue = actual.Resolve();
            Assert.Equal(fourthSource, actualValue);
        }
    }
}