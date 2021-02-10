using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet.Misc.Security.Test.Model
{
    public class Person : IStringSerializable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override bool Equals(object obj)
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
