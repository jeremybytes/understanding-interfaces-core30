using PersonReader.Interface;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;

namespace PeopleViewer
{
    public static class ReaderFactory
    {
        private static IPersonReader reader;

        public static IPersonReader GetReader()
        {
            if (reader != null)
                return reader;

            string readerAssemblyName = ConfigurationManager.AppSettings["ReaderAssembly"];
            string readerLocation = AppDomain.CurrentDomain.BaseDirectory
                                    + "ReaderAssemblies"
                                    + Path.DirectorySeparatorChar
                                    + readerAssemblyName;

            ReaderLoadContext loadContext = new ReaderLoadContext(readerLocation);
            AssemblyName assemblyName = new AssemblyName(Path.GetFileNameWithoutExtension(readerLocation));
            Assembly readerAssembly = loadContext.LoadFromAssemblyName(assemblyName);

            string readerTypeName = ConfigurationManager.AppSettings["ReaderType"];
            Type readerType = readerAssembly.ExportedTypes
                                .FirstOrDefault(t => t.FullName == readerTypeName);
            reader = Activator.CreateInstance(readerType) as IPersonReader;
            return reader;
        }
    }
}
