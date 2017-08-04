using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DDev.Tools;
using NUnit.Framework;
using FluentAssertions;

namespace DDev.Tools.Test
{
    [Author("Daniel Lerps")]
    [TestFixture]
    public class GenericDictionaryTest
    {
        [Test]
        public void Get_ShouldReturnValue_WhenOfTypeString(
            [Values(1, 10, 5)] int key,
            [Values("davoagedy", "atroksie", "jorraelza")] string val)
        {
            DoValueTest<int, string>(key, val);
        }

        [Test]
        public void Get_ShouldReturnValue_WhenOfTypeInteger(
            [Values(0, -6, 11)] int key,
            [Values(5, 0, 1337)] int val)
        {
            DoValueTest<int, int>(key, val);
        }

        [Test]
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
