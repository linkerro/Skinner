using System;
using System.Reflection;
using System.Linq;
using Skinner;

namespace SkinnerSpecsRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathToSpecDll = @"C:\Users\linke\Documents\Visual Studio 2015\Projects\Skinner\SkinnerSpecs\bin\Debug\SkinnerSpecs.dll";
            var assembly = Assembly.LoadFrom(pathToSpecDll);
            AppDomain.CurrentDomain.Load(assembly.GetName());
            var types = assembly.GetTypes().Where(t=>t.IsSubclassOf(typeof(Spec)) && t.IsPublic);
            foreach (var type in types)
            {
                var spec = (Spec)Activator.CreateInstance(type);
                spec.onDescription += (o,a)=> { Console.WriteLine(a.Description); };
                spec.Run();
            }
            Console.ReadKey();

        }

    }
}
