using Camada.struture.DapperMapping;
using Camada.structure.DapperMapping;
using Dapper;
using System.Linq;

namespace Camada.structure.DapperMapping
{
    public class ColAttributeTypeMap<T> : DapperTypeMap
    {
        public ColAttributeTypeMap() : base(
            new SqlMapper.ITypeMap[]{
                new CustomPropertyTypeMap(typeof(T), (type, columnName) =>
                    type.GetProperties().FirstOrDefault(prop =>
                        prop.GetCustomAttributes(false).OfType<ColAttribute>().Any(att => att.Name == columnName)
                    )
                ),
                new DefaultTypeMap(typeof(T))
            })
        {

        }
    }
}
