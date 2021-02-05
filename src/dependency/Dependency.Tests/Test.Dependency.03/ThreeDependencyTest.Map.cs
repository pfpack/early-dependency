#nullable enable

using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class ThreeDependencyTest
    {
        [Fact]
        public void Map_MapFirstFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => SomeTextStructType, _ => PlusFifteenIdRefType, _ => PlusFifteenIdSomeStringNameRecord);

            var mapFirst = null as Func<StructType, string>;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    mapFirst!, _ => MinusFifteen, _ => decimal.MinusOne));
            
            Assert.Equal("mapFirst", ex.ParamName);
        }

        [Fact]
        public void Map_MapSecondFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => SomeString, _ => MinusFifteenIdRefType, _ => new object());

            var mapSecond = null as Func<RefType, RecordType>;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    _ => PlusFifteenIdSomeStringNameRecord, mapSecond!, _ => long.MinValue));
            
            Assert.Equal("mapSecond", ex.ParamName);
        }

        [Fact]
        public void Map_MapThirdFuncIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(
                _ => SomeTextStructType, _ => ZeroIdRefType, _ => PlusFifteenIdRefType);

            var mapThird = null as Func<RefType?, RecordType>;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.Map(
                    _ => LowerSomeString, _ => decimal.MinusOne, mapThird!));
            
            Assert.Equal("mapThird", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void Map_MapFuncIsNotNull_ExpectResolvedValuesAreSameAsMapped(
            RefType? mappedLast)
        {
            var source = Dependency.Create(_ => SomeString, _ => Zero, _ => SomeTextStructType);

            var mappedFirst = decimal.One;
            var mappedSecond = MinusFifteenIdSomeStringNameRecord;

            var actual = source.Map(_ => mappedFirst, _ => mappedSecond, _ => mappedLast);
            var actualValue = actual.Resolve();

            var expectedValue = (mappedFirst, mappedSecond, mappedLast);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}