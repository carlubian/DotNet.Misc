using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using DotNet.Misc.Extensions.Linq;
using FluentAssertions;

namespace DotNet.Misc.Extensions.Test
{
    [TestClass]
    public class TestLinqExtensions
    {
        [TestMethod]
        public void TestForeach()
        {
            var list = new[] { 1, 2, 3, 4, 5 };
            var sum = 0;

            Action act = () => list.ForEach(n => sum += n);
            act.Should().NotThrow();
            sum.Should().Be(15);
        }

        [TestMethod]
        public void TestForeachNull()
        {
            var list = new[] { 1, 2, 3, 4, 5 };

            Action act = () => list.ForEach(null);
            act.Should().NotThrow();
        }

        [TestMethod]
        public void TestPeek()
        {
            var list = new[] { 1, 2, 3, 4, 5 };
            IList<int> result = null;
            var sum = 0;

            Action act = () => result = list.Peek(n => sum += n).ToList();
            act.Should().NotThrow();
            sum.Should().Be(15);
            result.Should().HaveCount(5).And.BeEquivalentTo(list);
        }

        [TestMethod]
        public void TestPeekNull()
        {
            var list = new[] { 1, 2, 3, 4, 5 };
            IList<int> result = null;

            Action act = () => result = list.Peek(null).ToList();
            act.Should().NotThrow();
            result.Should().HaveCount(5).And.BeEquivalentTo(list);
        }

        [TestMethod]
        public void TestGenerate()
        {
            1.Generate(n => n + 1).Take(5).Should().HaveCount(5)
                .And.Match(list => list.Sum() == 15);

            1.Generate(n => n + 1).Take(99).Should().Contain(99)
                .And.NotContain(100).And.Contain(1).And.NotContain(0);
        }

        [TestMethod]
        public void TestGenerateNull()
        {
            1.Generate(null).Take(5).Should().HaveCount(0);
        }

        [TestMethod]
        public void TestEnumerate()
        {
            var list = 64.Enumerate();

            list.Should().HaveCount(1).And.Contain(64);
            list.Should().AllBeAssignableTo(typeof(int));
        }

        [TestMethod]
        public void TestEnumerateNull()
        {
            string str = null;
            str.Enumerate().Should().HaveCount(1);
            str.Enumerate().First().Should().BeNull();
        }

        [TestMethod]
        public void TestStringify()
        {
            var list = new[] { 1, 2, 3, 4, 5 };

            var str = list.Stringify(n => n.ToString(), "-");
            str.Should().HaveLength(9).And.StartWith("1")
                .And.NotEndWith("-");

            str = list.Stringify(n => n.ToString(), ".-^-.");
            str.Should().HaveLength(25).And.StartWith("1")
                .And.NotEndWith(".");

            str = list.Stringify(n => n.ToString());
            str.Should().HaveLength(5).And.StartWith("1")
                .And.EndWith("5");
        }

        [TestMethod]
        public void TestStringifyNull()
        {
            IEnumerable<int> foo = null;

            foo.Stringify(n => n.ToString()).Should().Be("");

            foo = new[] { 1, 2, 3, 4, 5 };

            foo.Stringify(null).Should().Be("12345");
            foo.Stringify(n => n.ToString(), null).Should()
                .HaveLength(5).And.StartWith("1")
                .And.EndWith("5");
        }

        [TestMethod]
        public void TestStringifyImplicit()
        {
            IEnumerable<string> foo = new string[]
            {
                "Element 1",
                "Element 2",
                "Element 3"
            };

            foo.Stringify().Should().Be("Element 1Element 2Element 3");
            foo.Stringify(separator: " ").Should().Be("Element 1 Element 2 Element 3");

            IEnumerable<int> bar = new int[]
            {
                12,
                16,
                24
            };

            bar.Stringify().Should().Be("121624");
            bar.Stringify(separator: " ").Should().Be("12 16 24");
        }

        [TestMethod]
        public void TestRandom()
        {
            var source = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int n1 = 0, n2 = 0;

            Action act = () => n1 = source.Random();
            act.Should().NotThrow();
            act = () => n2 = source.Random();
            act.Should().NotThrow();

            // Randomness is non-deterministic
            if (n1.Equals(n2))
                n2 = source.Random();

            n1.Should().NotBe(n2);
        }

        [TestMethod]
        public void TestRandomSingle()
        {
            var source = new[] { 1 };
            int n1 = 0, n2 = 0;

            Action act = () => n1 = source.Random();
            act.Should().NotThrow();
            act = () => n2 = source.Random();
            act.Should().NotThrow();

            n1.Should().Be(n2);
        }

        [TestMethod]
        public void TestRandomEmpty()
        {
            var source = new int[] { };
            int n1 = -1, n2 = -1;

            Action act = () => n1 = source.Random();
            act.Should().NotThrow();
            act = () => n2 = source.Random();
            act.Should().NotThrow();

            n1.Should().Be(default(int));
            n1.Should().Be(n2);
        }

        [TestMethod]
        public void TestRandomNull()
        {
            IEnumerable<int> source = null;
            var n1 = -1;

            Action act = () => n1 = source.Random();
            act.Should().NotThrow();

            n1.Should().Be(default(int));
        }

        [TestMethod]
        public void TestSecond()
        {
            var source = new int[] { 1, 2, 3, 4 };
            source.Second().Should().Be(2);
        }

        [TestMethod]
        public void TestThird()
        {
            var source = new int[] { 1, 2, 3, 4 };
            source.Third().Should().Be(3);
        }
    }
}
