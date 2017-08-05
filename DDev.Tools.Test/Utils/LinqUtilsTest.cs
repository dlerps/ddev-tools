using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DDev.Tools;
using FluentAssertions;

namespace DDev.Tools.Test
{
    [TestFixture]
    [Author("Daniel Lerps")]
    public class LinqUtilsTest
    {
        /// <summary>
        /// Tests the clustering
        /// </summary>
        /// <param name="key"></param>
        /// <param name="values"></param>
        [TestCase(1, new string[] { "astapor", "meereen", "braavos" })]
        [TestCase(6, new string[] { "kings landing", "winterfell", "pentos" })]
        public void ToClusteredDictionary_ShouldCreateSubset_WhenKeyMatches(int key, string[] values)
        {
            List<TestObject<int, string>> testObjects = new List<TestObject<int, string>>(values.Length);

            foreach (string v in values)
                testObjects.Add(new TestObject<int, string>(key, v));

            testObjects.ToClusteredDictionary(v => v.Key)
                .Keys
                .Should()
                .HaveCount(1);

            testObjects.ToClusteredDictionary(v => v.Key)
                .First()
                .Value
                .Should()
                .HaveCount(values.Count());

            testObjects.ToClusteredDictionary(v => v.Key)
                .First()
                .Value
                .Select(t => t.Value)
                .Should()
                .Contain(values);
        }

        /// <summary>
        /// Checks if different keys cause multiple subsets by the clusered dictionary method
        /// </summary>
        [Test]
        public void ToClusteredDictionary_ShouldCreate2Subsets_WhenThereAre2Keys()
        {
            List<TestObject<DateTime, int>> testObjects = new List<TestObject<DateTime, int>>(3);

            int[] values1 = new int[] { 5, 10 };
            int[] values2 = new int[] { 1003 };

            DateTime dt1 = DateTime.UtcNow;
            DateTime dt2 = dt1.AddHours(-1);

            testObjects.Add(new TestObject<DateTime, int>(dt1, values1[0]));
            testObjects.Add(new TestObject<DateTime, int>(dt1, values1[1]));
            testObjects.Add(new TestObject<DateTime, int>(dt2, values2[0]));

            testObjects.ToClusteredDictionary(t => t.Key)
                .Keys
                .Should()
                .HaveCount(2);

            testObjects.ToClusteredDictionary(t => t.Key)[dt1]
                .Should()
                .HaveCount(2);

            testObjects.ToClusteredDictionary(t => t.Key)[dt2]
                .Should()
                .HaveCount(1);

            testObjects.ToClusteredDictionary(t => t.Key)[dt1]
                .Select(tObj => tObj.Value)
                .Should()
                .Contain(values1);

            testObjects.ToClusteredDictionary(t => t.Key)[dt2]
                .Select(tObj => tObj.Value)
                .Should()
                .Contain(values2);
        }
    }

    /// <summary>
    /// Testing class
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class TestObject<K, V>
    {
        public TestObject(K k, V v)
        {
            Value = v;
            Key = k;
        }

        public K Key { get; set; }
        public V Value { get; set; }
    }
}
