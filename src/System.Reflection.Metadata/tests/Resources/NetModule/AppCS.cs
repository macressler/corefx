// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Linq.Expressions;

[assembly: System.Reflection.AssemblyTitle("MetadataReaderModuleTestData")]
[assembly: System.Reflection.AssemblyVersion("1.2.3.4")]
[assembly: System.Reflection.AssemblyCulture("")]

namespace AppCS
{
    public class App
    {
        static ModChainB AppField01 = default(ModChainC);
        internal NS.Module.CS01.CS02.ModIGen2<Expression, object> AppProp { get { return new NS.Module.CS01.CS02.ModStructImplExp(); } }
 
        public App(ref ModChainA p)
        {
            // p = AppField01.MA03(123); // CS0570
            var pp = AppField01.MA01();
            Extension.ExtModChainA01(AppField01, "String Parameter Constant");
        }

        protected NS.Module.CS01.CS02.ModClassImplImp<V> AppMethod<V>(V t) where V : class
        {
            return null;
        }
    }

    public class UseModule
    {
        ModVBClass AppField02 = default(ModVBClass);
        ModVBClass.ModVBInnerEnum this[ModVBClass.ModVBInnerEnum p] { get { return p; } }

        public NS.Module.CS01.CS02.ModClassImplImp<ModVBStruct.ModVBInnerStruct.ModVBInnerIFoo> Use()
        {
            // x-modules
            NS.Module.CS01.CS02.ModClassImplImp<ModVBStruct.ModVBInnerStruct.ModVBInnerIFoo> v = null;
            if (null != AppField02)
            {
                v = default(NS.Module.CS01.CS02.ModClassImplImp<ModVBStruct.ModVBInnerStruct.ModVBInnerIFoo>);
                ModVBStruct.ModVBInnerStruct.ModVBInnerIFoo refVal = null;
                v.M01(ref refVal);
            }
            return v;
        }  
    }  
}

namespace AppCS
{
    public interface IContraVar<in CT> where CT: class
    {
        CT ContraFooProp { set; }
    }
    public interface ICoVar<out CO>
    {
        CO CoFooMethod();
    }
    interface INormal<T> 
    { 
        T NormalFoo(T t);
    }

    internal class ContraInClass<CT1> : IContraVar<CT1> where CT1 : class
    {
        public CT1 ContraFooProp { set { } }
    }

    internal class CoOutClass<CO1> : ICoVar<CO1> where CO1 : new()
    {
        public CO1 CoFooMethod() { return new CO1(); }
    }

    internal class NormalClass<T1> : INormal<T1>
    {
        public T1 NormalFoo(T1 t) { return default(T1); }
    }

    class Animal { }
    class Tiger : Animal { }

    public class Test
    {
        public static int Main()
        {
            IContraVar<Tiger> v1 = new ContraInClass<Animal>();
            CoOutClass<Tiger> v2 = new CoOutClass<Tiger>();
            ICoVar<Animal> v3 = v2;
            var x = v2.CoFooMethod();

            INormal<Animal> vv1 = new NormalClass<Animal>();
            INormal<Tiger> vv2 = new NormalClass<Tiger>();
            vv1.NormalFoo(new Animal());
            return 0;
        }
    }
}