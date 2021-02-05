#nullable enable

using Microsoft.Extensions.DependencyInjection;
using Moq;
using PrimeFuncPack.UnitTest;
using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class DependencyRegistratorTest
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void RegisterScoped_ExpectSourceServices(
            bool isNotNull)
        {            
            var mockServices = MockServiceCollection.CreateMock();
            var sourceServices = mockServices.Object;
            
            string regService = isNotNull ? SomeString : null!;
            var registrator = DependencyRegistrator.Create(
                sourceServices,
                _ => regService);

            var actualServices = registrator.RegisterScoped();
            Assert.Same(sourceServices, actualServices);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void RegisterScoped_ExpectCallAddScopedOnce(
            bool isNotNull)
        {
            RefType regService = isNotNull ? ZeroIdRefType : null!;
            var mockServices = MockServiceCollection.CreateMock(
                sd =>
                {
                    Assert.Equal(typeof(RefType), sd.ServiceType);
                    Assert.Equal(ServiceLifetime.Scoped, sd.Lifetime);
                    Assert.NotNull(sd.ImplementationFactory);

                    var actualService = sd.ImplementationFactory!.Invoke(Mock.Of<IServiceProvider>());
                    Assert.Equal(regService, actualService);
                });

            var sourceServices = mockServices.Object;
            
            var registrator = DependencyRegistrator.Create(
                sourceServices,
                _ => regService);

            _ = registrator.RegisterScoped();
            mockServices.Verify(s => s.Add(It.IsAny<ServiceDescriptor>()), Times.Once);
        }
    }
}