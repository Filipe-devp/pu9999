using Dapper;
using System;
using System.Linq;

namespace Camada.structure.DapperMapping
{
    public static class DapperTypeMapInitializer
    {

        public static void Initialize(string targetNamespace)
        {
            var types = from assembly in AppDomain.CurrentDomain.GetAssemblies().ToList()
                        from type in assembly.GetTypes()
                        where type.IsClass && type.Namespace == targetNamespace
                        select type;

            types.ToList().ForEach(e =>
            {
                var mapper = (SqlMapper.ITypeMap)Activator.CreateInstance(typeof(ColAttributeTypeMap<>).MakeGenericType(e));
                SqlMapper.SetTypeMap(e, mapper);
            });
        }

    }
}

