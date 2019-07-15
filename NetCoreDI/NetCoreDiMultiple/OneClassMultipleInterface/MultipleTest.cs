using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NetCoreDiMultiple.OneClassMultipleInterface
{
    [TestClass]
    public class MultipleTest
    {
        [TestMethod]
        public void WhenRegisteredAsSeparateSingleton_InstancesAreNotTheSame()
        {
            //IServiceCollection
            var services = new ServiceCollection();

            //ServiceLifeTime
            services.AddSingleton<IFoo, Foo>();
            services.AddSingleton<IBar, Foo>();

            //IServiceProvider
            var provider = services.BuildServiceProvider();

            var foo1 = provider.GetService<IFoo>(); // An instance of Foo
            var foo2 = provider.GetService<IBar>(); // An instance of Foo

            Assert.AreNotSame(foo1, foo2); // PASSES
        }

        [TestMethod]
        public void WhenRegisteredAsForwardedSingleton_InstancesAreTheSame()
        {
            var services = new ServiceCollection();

            services.AddSingleton<Foo>(); // We must explicitly register Foo
            services.AddSingleton<IFoo>(x => x.GetRequiredService<Foo>()); // Forward requests to Foo
            services.AddSingleton<IBar>(x => x.GetRequiredService<Foo>()); // Forward requests to Foo

            var provider = services.BuildServiceProvider();

            var foo1 = provider.GetService<Foo>(); // An instance of Foo
            var foo2 = provider.GetService<IFoo>(); // An instance of Foo
            var foo3 = provider.GetService<IBar>(); // An instance of Foo

            Assert.AreSame(foo1, foo2); // PASSES
            Assert.AreSame(foo1, foo3); // PASSES
        }
    }
}
