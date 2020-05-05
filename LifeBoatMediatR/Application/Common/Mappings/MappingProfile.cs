using System;
using AutoMapper;
using System.Linq;
using System.Reflection;

namespace LifeBoatMediatR.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            Func<Type, bool> wherePredicate = w => 
                w.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>));
            
            var types = assembly.GetExportedTypes()
                .Where(wherePredicate)
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod(nameof(IMapFrom<object>.Mapping));
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
