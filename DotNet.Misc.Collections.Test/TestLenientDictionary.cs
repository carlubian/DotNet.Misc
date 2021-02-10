using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using FluentAssertions;
using System;

namespace DotNet.Misc.Collections.Test
{
    [TestClass]
    public class TestLenientDictionary
    {
        [TestMethod]
        public void TestOverwrite()
        {
            IDictionary<string, int> dict = new LenientDictionary<string, int>();

            dict["One"] = 1;
            dict["One"].Should().Be(1);

            Action act = () => dict["One"] = 2;
            act.Should().NotThrow();
            dict["One"].Should().Be(2);
        }

        [TestMethod]
        public void TestAddOverwrite()
        {
            IDictionary<string, int> dict = new LenientDictionary<string, int>();

            dict.Add("One", 1);
            dict["One"].Should().Be(1);

            Action act = () => dict.Add("One", 2);
            act.Should().NotThrow();
            dict["One"].Should().Be(2);
        }

        [TestMethod]
        public void TestGetNonexistant()
        {
            IDictionary<string, int> dict = new LenientDictionary<string, int>();

            var value = -1;
            Action act = () => value = dict["One"];
            act.Should().NotThrow();
            value.Should().Be(default);
        }

        [TestMethod]
        public void TestSetNonexistant()
        {
            IDictionary<string, int> dict = new LenientDictionary<string, int>();
            Action act = () => dict["One"] = 1;
            act.Should().NotThrow();
            dict["One"].Should().Be(1);
        }

        [TestMethod]
        public void TestRemoveNonexistant()
        {
            IDictionary<string, int> dict = new LenientDictionary<string, int>();
            Action act = () => dict.Remove("One");

            act.Should().NotThrow();
        }

        [TestMethod]
        public void TestContainsValue()
        {
            IDictionary<string, int> dict = new LenientDictionary<string, int>();

            dict.ContainsValue(1).Should().BeFalse();

            dict["One"] = 1;

            dict.ContainsValue(1).Should().BeTrue();
        }
    }
}
