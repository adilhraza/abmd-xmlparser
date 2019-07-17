using System;
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

                var filePath = "c:\\file.xml";

                Console.WriteLine(parser.ReadRefText(filePath, "MWB"));
                Console.WriteLine(parser.ReadRefText(filePath, "TRV"));
                Console.WriteLine(parser.ReadRefText(filePath, "CAR"));
            }

            Console.ReadKey();
        }
        
        private static void DiConfig()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<XmlParser>().As<IXmlParser>();
            Container = builder.Build();
        }

    }
}