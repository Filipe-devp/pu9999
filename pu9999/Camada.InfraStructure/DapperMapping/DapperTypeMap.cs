using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Camada.struture.DapperMapping
{
    public class DapperTypeMap : SqlMapper.ITypeMap
    {

        private readonly IEnumerable<SqlMapper.ITypeMap> _mappers;

        public DapperTypeMap(IEnumerable<SqlMapper.ITypeMap> mappers)
        {
            _mappers = mappers;
        }

        public ConstructorInfo FindConstructor(string[] names, Type[] types)
        {
            foreach (var mapper in _mappers)
            {
                try
                {
                    var constructorinfo = mapper.FindConstructor(names, types);

                    if (constructorinfo != null)
                    {
                        return constructorinfo;
                    }
                }
                catch { }
            }

            return null;
        }

        public ConstructorInfo FindExplicitConstructor()
        {
            return _mappers.Select(e => e.FindExplicitConstructor()).FirstOrDefault(r => r != null);
        }

        public SqlMapper.IMemberMap GetConstructorParameter(ConstructorInfo constructor, string columnName)
        {
            foreach (var mapper in _mappers)
            {
                try
                {
                    var result = mapper.GetConstructorParameter(constructor, columnName);

                    if (result != null)
                    {
                        return result;
                    }
                }
                catch { }
            }

            return null;
        }

        public SqlMapper.IMemberMap GetMember(string columnName)
        {
            foreach (var mapper in _mappers)
            {
                try
                {
                    var member = mapper.GetMember(columnName);

                    if (member != null)
                    {
                        return member;
                    }
                }
                catch { }
            }

            return null;
        }
    }
}
