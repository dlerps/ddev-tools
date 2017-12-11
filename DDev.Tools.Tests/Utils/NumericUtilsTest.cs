using System;

using DDev.Tools.Extensions;
using FluentAssertions;
using Xunit;

namespace DDev.Tools.Test.Utils
{
    public class NumericUtilsTest
    {
        [Theory]
        [InlineData("13", 13)]
        [InlineData("-98", -98)]
        [InlineData("0", 0)]
        public void ToInteger_ShouldParseAnIntegerValue(string s, int n)
        {
            s.ToInteger()
                .Should()
                .Be(n);
        }

        [Theory]
        [InlineData("13h")]
        [InlineData("-99-")]
        [InlineData("0 + 3")]
        [InlineData("4+")]
        [InlineData("7*88")]
        public void ToInteger_ShouldReturnNull_WhenInputIsNotNumeric(string s)
        {
            s.ToInteger()
                .Should()
                .BeNull();
        }

        [Theory]
        [InlineData("7969869883", 7969869883)]
        [InlineData("-2978001238", -2978001238)]
        [InlineData("00", 0)]
        public void ToLong_ShouldParseALongValue(string s, long n)
        {
            s.ToLong()
                .Should()
                .Be(n);
        }

        [Theory]
        [InlineData("5oo")]
        [InlineData("notanumber")]
        [InlineData("")]
        [InlineData("--8")]
        [InlineData("5^2")]
        public void ToLong_ShouldReturnNull_WhenInputIsNotNumeric(string s)
        {
            s.ToLong()
                .Should()
                .BeNull();
        }

        [Theory]
        [InlineData("13.22", 13.22)]
        [InlineData("-02.1", -2.1)]
        [InlineData("0.0", 0)]
        public void ToDecimal_ShouldParseADecimalValue(string s, decimal n)
        {
            s.ToDecimal()
                .Should()
                .Be(n);
        }

        [Theory]
        [InlineData("0,8")]
        [InlineData("9..0")]
        [InlineData("122.03.2")]
        [InlineData("*")]
        [InlineData("5^2")]
        public void ToDecimal_ShouldReturnNull_WhenInputIsNotNumeric(string s)
        {
            s.ToLong()
                .Should()
                .BeNull();
        }

        [Theory]
        [InlineData("45.22100", 45.221)]
        [InlineData("-122333.09734234", -122333.09734234)]
        [InlineData(".7", 0.7)]
        [InlineData("0.0", 0)]
        public void ToDouble_ShouldParseADoubleValue(string s, decimal n)
        {
            s.ToDecimal()
                .Should()
                .Be(n);
        }

        [Theory]
        [InlineData("100,18")]
        [InlineData("1009.")]
        [InlineData(",9")]
        [InlineData("_")]
        public void ToDouble_ShouldReturnNull_WhenInputIsNotNumeric(string s)
        {
            s.ToLong()
                .Should()
                .BeNull();
        }
    }
}
