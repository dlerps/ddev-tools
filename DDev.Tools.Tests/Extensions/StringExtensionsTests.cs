using System;
using DDev.Tools.Extensions;
using FluentAssertions;
using Xunit;

namespace DDev.Tools.Tests.Extensions
{
    public class StringExtensionsTests
    {
        [Fact]
        public void ExtendWithPattern_ShouldThrow_WhenNoPlaceholderInPattern()
        {
            string s = "Hello World";

            try
            {
                s = s.ExtendWithPattern("no pattern", new string[] { "l" });
                throw new Exception("Failed to throw correct exception");
            }
            catch (DDevToolsException dte)
            {
                dte.Should()
                    .NotBeNull();
            }
        }

        [Fact]
        public void ExtendWithPattern_ShouldThrow_WhenPatternIsNull()
        {
            string s = "Hello World";

            try
            {
                s = s.ExtendWithPattern(null, new string[] { "l" });
                throw new Exception("Failed to throw correct exception");
            }
            catch (DDevToolsException dte)
            {
                dte.Should()
                    .NotBeNull();
            }
        }

        [Theory]
        [InlineData("Leira Silvertongue")]
        [InlineData("Oxford")]
        public void ExtendWithPattern_ShouldReturnOriginal_WhenNoReplacementsAreNull(string s)
        {
            s.ExtendWithPattern("-{0}", null)
                .Should()
                .Be(s);
        }

        [Theory]
        [InlineData("Pantaleimon")]
        [InlineData("Lord Asriel")]
        public void ExtendWithPattern_ShouldReturnOriginal_WhenNoReplacementsAreEmpty(string s)
        {
            s.ExtendWithPattern("-{0}", new string[] { })
                .Should()
                .Be(s);
        }

        [Theory]
        [InlineData("Queen Margery", "{0}!", new string[] { "y" }, "Queen Margery!")]
        [InlineData("Wintrfll", "{0}e", new string[] { "f", "t" }, "Winterfell")]
        [InlineData("Lu Skywalr", "{0}ke", new string[] { "u", "l" }, "Luke Skywalker")]
        public void ExtendWithPattern_ShouldExtendEachOccurance(string s, string pattern, string[] replacements, string expected)
        {
            s.ExtendWithPattern("-{0}", new string[] { })
                .Should()
                .Be(s);
        }
    }
}