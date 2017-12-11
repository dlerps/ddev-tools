using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DDev.Tools;
using FluentAssertions;
using Xunit;

namespace DDev.Tools.Test
{
    public class GenericDictionaryTest
    {
        [Theory]
        [InlineData(1, "davoagedy")]
        [InlineData(10, "atroksie")]
        [InlineData(5, "jorraelza")]
        public void Get_ShouldReturnValue_WhenOfTypeString(int key, string val)
        {
            DoValueTest<int, string>(key, val);
        }

        [Theory]
        [InlineData(0, -6)]
        [InlineData(50, 1337)]
        public void Get_ShouldReturnValue_WhenOfTypeInteger(int key, int val)
        {
            DoValueTest<int, int>(key, val);
        }

        [Fact]
        public void Get_ShouldReturnValue_WhenOfTypeDateTime()
        {
            DoValueTest<string, DateTime>("today", DateTime.UtcNow);
        }

        private void DoValueTest<K, V>(K key, V value)
        {
            GenericDictionary<K> dict = new GenericDictionary<K>();
            dict.Add(key, value);

            dict.Get<V>(key)
                .Should()
                .BeOfType(typeof(V));

            dict.Get<V>(key)
                .Should()
                .Be(value);
        }
    }
}
