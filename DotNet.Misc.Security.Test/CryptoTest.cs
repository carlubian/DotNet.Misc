using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using DotNet.Misc.Security.Test.Model;
using DotNet.Misc.Security.Data;

namespace DotNet.Misc.Security.Test
{
    [TestClass]
    public class CryptoTest
    {
        [TestMethod]
        public void TestString()
        {
            // Encrypt
            var str = "Super secret text";
            var edata = Safely.Encrypt(str);

            edata.Data.Should().NotBe(str);

            // Decrypt
            var ddata = Safely.Decrypt(edata);

            ddata.Data.Should().Be(str);

            // Extract
            var res = ddata.As(out string str2);

            res.Should().BeTrue();
            str2.Should().Be(str);
        }

        [TestMethod]
        public void TestInt()
        {
            // Encrypt
            var num = 32768;
            var edata = Safely.Encrypt(num);

            edata.Data.Should().NotBe(num.ToString());

            // Decrypt
            var ddata = Safely.Decrypt(edata);

            ddata.Data.Should().Be(num.ToString());

            // Extract
            var res = ddata.AsValue(out int num2);

            res.Should().BeTrue();
            num2.Should().Be(num);
        }

        [TestMethod]
        public void TestDouble()
        {
            // Encrypt
            var num = 163.84D;
            var edata = Safely.Encrypt(num);

            edata.Data.Should().NotBe(num.ToString());

            // Decrypt
            var ddata = Safely.Decrypt(edata);

            ddata.Data.Should().Be(num.ToString());

            // Extract
            var res = ddata.AsValue(out double num2);

            res.Should().BeTrue();
            num2.Should().Be(num);
        }

        [TestMethod]
        public void TestBoolean()
        {
            // Encrypt
            var iable = true;
            var edata = Safely.Encrypt(iable);

            edata.Data.Should().NotBe(iable.ToString());

            // Decrypt
            var ddata = Safely.Decrypt(edata);

            ddata.Data.Should().Be(iable.ToString());

            // Extract
            var res = ddata.AsValue(out bool ean);

            res.Should().BeTrue();
            ean.Should().Be(iable);
        }

        [TestMethod]
        public void TestPerson()
        {
            // Encrypt
            var person = new Person
            {
                Name = "Test Person",
                Age = 21
            };
            var edata = Safely.Encrypt(person);

            edata.Data.Should().NotBe(person.Serialize());

            // Decrypt
            var ddata = Safely.Decrypt(edata);

            ddata.Data.Should().Be(person.Serialize());

            // Extract
            var res = ddata.As(out Person person2);

            res.Should().BeTrue();
            person2.Should().Be(person);
        }

        [TestMethod]
        public void TestDecryptString()
        {
            // Encrypt
            var str = "Super secret text";
            var edata = Safely.Encrypt(str);

            edata.Data.Should().NotBe(str);

            // Decrypt
            var ddata = Safely.Decrypt(edata.Data);

            ddata.Data.Should().Be(str);

            // Extract
            var res = ddata.As(out string str2);

            res.Should().BeTrue();
            str2.Should().Be(str);
        }

        [TestMethod]
        public void TestUsePassword()
        {
            var str = "Super secret message";
            var edata = new EncryptedData();

            // Encrypt with custom password
            using (new Password("FooBar"))
            {
                edata = Safely.Encrypt(str);
                Safely.Decrypt(edata).Data.Should().Be(str);
            }

            // Default password cannot decrypt
            Safely.Decrypt(edata).Data.Should().NotBe(str);

            // Custom password can decrypt
            using (new Password("FooBar"))
            {
                Safely.Decrypt(edata).Data.Should().Be(str);
            }
        }

        [TestMethod]
        public void TestUseDefault()
        {
            // Encrypt with default password
            var str = "Super secret message";
            var edata = Safely.Encrypt(str);

            // Custom password cannot decrypt
            using (new Password("FooBar"))
            {
                Safely.Decrypt(edata).Data.Should().NotBe(str);
            }

            // Default password can decrypt
            Safely.Decrypt(edata).Data.Should().Be(str);
        }
    }
}
