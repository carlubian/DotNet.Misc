using System;

namespace DotNet.Misc.Security.Test.Model
{
#pragma warning disable CS0659 // El tipo reemplaza a Object.Equals(object o), pero no reemplaza a Object.GetHashCode()
    public class Person : IStringSerializable<Person>
#pragma warning restore CS0659 // El tipo reemplaza a Object.Equals(object o), pero no reemplaza a Object.GetHashCode()
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is Person p)
                return p.Name.Equals(Name) && p.Age.Equals(Age);

            return false;
        }

        public string Serialize() => $"Person#{Name}#{Age}";

        public static Person Deserialize(string v)
        {
            var parts = v.Split('#');
            if (parts.Length is 3
                && int.TryParse(parts[2], out int age))
                return new Person
                {
                    Name = parts[1],
                    Age = age
                };

            throw new NotImplementedException();
        }
    }
}
