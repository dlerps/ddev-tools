using System;
using System.Collections.Generic;
using DDev.Tools;
using FluentAssertions;
using Xunit;

namespace DDev.Tools.Test
{
    public class CollectionUtilsTest
    {
        /// <summary>
        /// Tests the generic parsing of dictionary values with strings
        /// </summary>
        [Fact]
        public void ParseValue_ShouldReturnValue_WhenOfTypeString()
        {
            DictionaryTypeTest<string>("khalesie", "daenerys");
        }

        /// <summary>
        /// Tests the generic parsing of dictionary values with strings
        /// </summary>
        [Fact]
        public void ParseValue_ShouldReturnValue_WhenOfTypeInteger()
        {
            DictionaryTypeTest<int>("season", 7);
        }

        /// <summary>
        /// Tests the generic parsing of dictionary values with strings
        /// </summary>
        [Fact]
        public void ParseValue_ShouldReturnValue_WhenOfTypeDouble()
        {
            DictionaryTypeTest<double>("purpose of life", 42.0);
        }

        /// <summary>
        /// Tests the generic parsing of dictionary values with strings
        /// </summary>
        [Fact]
        public void ParseValue_ShouldReturnValue_WhenOfTypeDateTime()
        {
            DictionaryTypeTest<DateTime>("star wars day", new DateTime(1978, 5, 5));
        }

        /// <summary>
        /// Tests the generic parsing of dictionary values with strings
        /// </summary>
        [Fact]
        public void ParseValue_ShouldReturnValue_WhenOfTypeDecimal()
        {
            DictionaryTypeTest<decimal>("credits", 10000m);
        }

        private void DictionaryTypeTest<T>(string key, T value)
        {
            IDictionary<string, object> dict = new Dictionary<string, object>(1);
            
            dict.Add(key, value);

            dict.ParseValue<T>(key)
                .Should()
                .NotBeNull();

            dict.ParseValue<T>(key)
                .Should()
                .Be(value);
        }
    }

}
