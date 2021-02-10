using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using DotNet.Misc.Extensions;
using FluentAssertions;

namespace DotNet.Misc.Extensions.Test
{
    [TestClass]
    public class TestObjectExtensions
    {
        [TestMethod]
        public void TestHashCode()
        {
            var ThingA = new EquatableThing
            {
                NumberProperty = 16,
                TextProperty = "This is a thing.",
                IgnoreThisOne = 6.5
            };
            var ThingB = new EquatableThing
            {
                NumberProperty = 16,
                TextProperty = "This is a thing.",
                IgnoreThisOne = -7.125
            };
            var ThingC = new EquatableThing
            {
                NumberProperty = 16,
                TextProperty = "This is another thing.",
                IgnoreThisOne = 6.5
            };

            ThingA.GetHashCode().Should().Be(ThingB.GetHashCode());
            ThingA.GetHashCode().Should().NotBe(ThingC.GetHashCode());
            ThingB.GetHashCode().Should().NotBe(ThingC.GetHashCode());
        }
    }

    class EquatableThing
    {
        internal int NumberProperty { get; set; }
        internal string TextProperty { get; set; }
        internal double IgnoreThisOne { get; set; }

        public override int GetHashCode() => this.GetHashCode(NumberProperty, TextProperty);
    }
}
