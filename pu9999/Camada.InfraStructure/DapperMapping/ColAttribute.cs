using System;

namespace Camada.structure.DapperMapping
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ColAttribute : Attribute
    {
        public string Name { get; set; }

        public ColAttribute(string name)
        {
            Name = name;
        }
    }
}