using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace NetCoreDiMultiple.OneInterfaceMultipleImplement
{
    [TestClass]
    public class MultipleTest
    {
        [TestMethod]
        public void WhenRegisteredOneInterfaceMultipleImplement_LastInstance()
        {
            var services = new ServiceCollection();

            services.AddScoped<IFoo, FooOne>();
            services.AddScoped<IFoo, FooTwo>();

            var provider = services.BuildServiceProvider();

            var footwo = provider.GetService<IFoo>(); // Last instance of Foo

            Assert.AreEqual(footwo.GetVs(), "FooTwo"); // PASSES
        }

        [TestMethod]
        public void WhenRegisteredOneInterfaceMultipleImplement_MultipleInstance()
        {
            var services = new ServiceCollection();

            services.AddScoped<IFoo, FooOne>();
            services.AddScoped<IFoo, FooTwo>();

            var provider = services.BuildServiceProvider();

            var fooOneAndTwo = provider.GetService<IEnumerable<IFoo>>(); // Multiple instance of Foo

            Assert.AreEqual(fooOneAndTwo.FirstOrDefault()?.GetVs(), "FooOne"); // PASSES
            Assert.AreEqual(fooOneAndTwo.LastOrDefault()?.GetVs(), "FooTwo"); // PASSES

            Assert.AreEqual(fooOneAndTwo.FirstOrDefault(f=>f.GetType().Name.Equals("FooOne"))?.GetVs(), "FooOne"); // PASSES
            Assert.AreEqual(fooOneAndTwo.FirstOrDefault(f => f.GetType().Name.Equals("FooTwo"))?.GetVs(), "FooTwo"); // PASSES
            //GetNameSpace
        }

        [TestMethod]
        public void WhenRegisteredOneInterfaceMultipleImplement_MultipleInstanceFunc()
        {
            var services = new ServiceCollection();

            //services.AddTransient<IFoo, FooOne>();
            //services.AddTransient<IFoo, FooTwo>();

            services.AddTransient<FooOne>();
            services.AddTransient<FooTwo>();

            services.AddTransient(implementationFactory =>
            {
                Func<string, IFoo> accesor = key =>
                {
                    if (key.Equals("fooone"))
                    {
                        return implementationFactory.GetService<FooOne>();
                    }
                    else if (key.Equals("footwo"))
                    {
                        return implementationFactory.GetService<FooTwo>();
                    }
                    else
                    {
                        throw new ArgumentException($"Not Support key : {key}");
                    }
                };
                return accesor;
            });


            var provider = services.BuildServiceProvider();

            var fooAccesor = provider.GetService<Func<string, IFoo>>(); // Get instance of Services Func

            var fooone = fooAccesor("fooone");
            var footwo = fooAccesor("footwo");

            Assert.AreEqual(fooone.GetVs(), "FooOne"); // PASSES
            Assert.AreEqual(footwo.GetVs(), "FooTwo"); // PASSES

        }
    }
}
