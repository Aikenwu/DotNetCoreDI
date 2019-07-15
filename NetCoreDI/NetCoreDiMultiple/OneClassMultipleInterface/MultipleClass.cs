using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreDiMultiple.OneClassMultipleInterface
{
    class MultipleClass
    {
    }

    public interface IBar { }

    public interface IFoo { }

    public class Foo : IFoo, IBar { }
}
