using System;
using System.Collections.Generic;
using System.Linq;
using FreshMvvm;
using FreshTinyIoC;
using SampleFreshApp.Interfaces;

namespace SampleFreshApp.Helpers
{
    public static class DependencyInjectionTool
    {
        public static void Register()
        {
            StoreToIOCByNameSpace(nameof(Services));
            StorToIOCDynamic("IGetAll");
            StorToIOCDynamic("IPostWithSingleReturn");
        }

        private static void StoreToIOCByNameSpace(string name) 
        {
           var classes =  GetRespositoryPatternClasses(name);
            foreach (var classs in classes)
                FreshTinyIoCContainer
                    .Current
                    .Register
                    (classs
                    .GetInterfaces()
                    .FirstOrDefault
                    (x => x.Name.Contains($"I{classs.Name}"))
                    ,classs);
        }
        private static void StorToIOCDynamic(string interfaceName)
        {
            var classes = GetClasseseOfAnInterface(interfaceName);
            foreach (var classs in classes)
                foreach (var iInterface in classs.GetInterfaces()
                    .Where(x => x.Name.Contains(interfaceName))
                    .ToList())
                    FreshTinyIoCContainer.Current.Register(iInterface, classs);
        }

        private static List<Type> GetRespositoryPatternClasses(string name)
        {
            var filteredTypes = new List<Type>();
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => p.IsClass).OrderBy(x => x.Name).ToList();

            foreach (var type in types)
            {
                var interfaces = type.GetInterfaces();
                var isRepositoryPatternAccepted = (interfaces.FirstOrDefault(x => x.Name.Contains($"I{type.Name}"))) != null;
                if (isRepositoryPatternAccepted)
                    filteredTypes.Add(type);
            }
            return filteredTypes.Where(x => x.Namespace.Contains(name)).ToList();
        }

        private static List<Type> GetClasseseOfAnInterface(string interfaceName)
        {
            return (AppDomain.CurrentDomain
                     .GetAssemblies()
                     .SelectMany(x => x.GetTypes())
                     .Where(x => x.IsClass)
                     .OrderBy(x => x.Name))
                     .Where(x => x.GetInterfaces().Any(xx => xx.Name.Contains(interfaceName)))
                     .ToList();

        }
    }
}
