using Autofac;
using XmlDocReader.Services;
using XmlDocReader.Services.Impl;

namespace XmlDocReader
{
    internal class Program
    {
        private static IContainer Container { get; set; }

        public static void Main(string[] args)
        {
            DiConfig();

            using (var scope = Container.BeginLifetimeScope())
            {
                var parser = scope.Resolve<IXmlParser>();
                
                // todo: give it the xml file and get your result back
            }
        }
        
        private static void DiConfig()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<XmlParser>().As<IXmlParser>();
            Container = builder.Build();
        }

    }
}