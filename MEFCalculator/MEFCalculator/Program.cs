using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace MEFCalculator
{
    class Program
    {
        private CompositionContainer _container;
        private Program()
        {
            // An aggregate catalog that combines multiple catalogs.
            var catalog = new AggregateCatalog();
            // Adds all the parts found in the same assembly as the Program class.
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));

            // Create the CompositionContainer with the parts in the catalog.
            _container = new CompositionContainer(catalog);

            // Fill the imports of this object.
            try
            {
                this._container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }

        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
