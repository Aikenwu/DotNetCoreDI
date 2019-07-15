using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreDiMultiple.OneInterfaceMultipleImplement
{
    class MultipleClass
    {
    }

    public interface IFoo
    {
        string GetVs();
    }

    public class FooOne : IFoo
    {
        public string GetVs()
        {
            return "FooOne";
        }
    }

    public class FooTwo : IFoo
    {
        public string GetVs()
        {
            return "FooTwo";
        }
    }
}
