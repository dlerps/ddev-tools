using NUnit.Framework;
using System;

using DDev.Tools.Extensions;
using FluentAssertions;

namespace DDev.Tools.Test.Utils
{
    [TestFixture]
    [Author("Daniel Lerps")]
    public class NumericUtilsTest
    {
        [TestCase("13", 13)]
        [TestCase("-98", -98)]
        [TestCase("0", 0)]
        public void ToInteger_ShouldParseAnIntegerValue(string s, int n)
        {
            s.ToInteger()
                .Should()
                .Be(n);
        }

        [TestCase("13h")]
        [TestCase("-99-")]
        [TestCase("0 + 3")]
        [TestCase("4+")]
        [TestCase("7*88")]
        public void ToInteger_ShouldReturnNull_WhenInputIsNotNumeric(string s)
        {
            s.ToInteger()
                .Should()
                .BeNull();
        }

        [TestCase("7969869883", 7969869883)]
        [TestCase("-2978001238", -2978001238)]
        [TestCase("00", 0)]
        public void ToLong_ShouldParseALongValue(string s, long n)
        {
            s.ToLong()
                .Should()
                .Be(n);
        }

        [TestCase("5oo")]
        [TestCase("notanumber")]
        [TestCase("")]
        [TestCase("--8")]
        [TestCase("5^2")]
        public void ToLong_ShouldReturnNull_WhenInputIsNotNumeric(string s)
        {
            s.ToLong()
                .Should()
                .BeNull();
        }

        [TestCase("13.22", 13.22)]
        [TestCase("-02.1", -2.1)]
        [TestCase("0.0", 0)]
        public void ToDecimal_ShouldParseADecimalValue(string s, decimal n)
        {
            s.ToDecimal()
                .Should()
                .Be(n);
        }

        [TestCase("0,8")]
        [TestCase("9..0")]
        [TestCase("122.03.2")]
        [TestCase("*")]
        [TestCase("5^2")]
        public void ToDecimal_ShouldReturnNull_WhenInputIsNotNumeric(string s)
        {
            s.ToLong()
                .Should()
                .BeNull();
        }

        [TestCase("45.22100", 45.221)]
        [TestCase("-122333.09734234", -122333.09734234)]
        [TestCase(".7", 0.7)]
        [TestCase("0.0", 0)]
        public void ToDouble_ShouldParseADoubleValue(string s, decimal n)
        {
            s.ToDecimal()
                .Should()
                .Be(n);
        }

        [TestCase("100,18")]
        [TestCase("1009.")]
        [TestCase(",9")]
        [TestCase("_")]
        public void ToDouble_ShouldReturnNull_WhenInputIsNotNumeric(string s)
        {
            s.ToLong()
                .Should()
                .BeNull();
        }
    }
}
