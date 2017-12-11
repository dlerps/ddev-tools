using System;
using DDev.Tools;
using FluentAssertions;
using Xunit;

namespace DDev.Tools.Test
{
    public class CompositeDictionaryTest
    {
        [Fact]
        public void Add_ShouldAddNewValue()
        {
            DateTime key1 = DateTime.UtcNow;
            Guid key2 = Guid.NewGuid();
            string value = "Johnny Drama";

            var dict = GetDictionary();            

            dict.Add(key1, key2, value);

            dict.Should()
                .HaveCount(1);
        }

        [Fact]
        public void Add_ShouldIgnoreOperation_WhenKeysAlreadyExist()
        {
            DateTime key1 = DateTime.UtcNow;
            Guid key2 = Guid.NewGuid();
            string value = "Vincent Chase";

            var dict = GetDictionary();

            dict.Add(key1, key2, value);
            dict.Add(key1, key2, value);

            dict.Should()
                .HaveCount(1);
        }

        [Fact]
        public void Get_ShouldReturnValue()
        {
            DateTime key1 = DateTime.UtcNow;
            Guid key2 = Guid.NewGuid();
            string value = "E";

            var dict = GetDictionary();

            dict.Add(key1, key2, value);
            
            dict.Get(key1, key2)
                .Should()
                .NotBeNullOrEmpty();

            dict.Get(key1, key2)
                .Should()
                .Be(value);
        }

        [Fact]
        public void Set_ShouldChangeValue()
        {
            DateTime key1 = DateTime.UtcNow;
            Guid key2 = Guid.NewGuid();
            string value = "Ari";

            var dict = GetDictionary();

            dict.Add(key1, key2, "Turtle");
            dict.Set(key1, key2, value);
            
            dict.Get(key1, key2)
                .Should()
                .NotBeNullOrEmpty();

            dict.Get(key1, key2)
                .Should()
                .Be(value);
        }

        [Fact]
        public void Count_ShouldGiveNumberOfElements()
        {
            CompositeDictionary<int, double, string> dict = new CompositeDictionary<int, double, string>();

            string[] values = {
                "Bart",
                "Homer",
                "Marge",
                "Lisa",
                "Maggie"
            };

            dict.Add(1, 6.1, values[0]);
            dict.Add(2, 0.1, values[1]);
            dict.Add(3, 2.0, values[2]);
            dict.Add(4, -2.1, values[3]);
            dict.Add(5, 7.01, values[4]);
            
            dict.Should()
                .HaveCount(values.Length);
        }

        [Fact]
        public void Add_ShouldAddMultipleElements()
        {
            CompositeDictionary<int, double, string> dict = new CompositeDictionary<int, double, string>();

            string[] values = {
                "Bart",
                "Homer",
                "Marge",
                "Lisa",
                "Maggie"
            };

            dict.Add(1, 6.1, values[0]);
            dict.Add(2, 0.1, values[1]);
            dict.Add(3, 2.0, values[2]);
            dict.Add(4, -2.1, values[3]);
            dict.Add(5, 7.01, values[4]);
            
            dict.Values
                .Should()
                .Contain(values);
        }

        [Fact]
        public void Add_ShouldRespectCompositeKeys()
        {
            DateTime key1_1 = DateTime.UtcNow;
            Guid key2_1 = Guid.NewGuid();
            string value1 = "Queens Boulevard";

            DateTime key1_2 = DateTime.UtcNow.AddDays(-1);
            Guid key2_2 = Guid.NewGuid();
            string value2 = "Aquaman";

            var dict = GetDictionary();

            dict.Add(key1_1, key2_1, value1);
            dict.Add(key1_2, key2_2, value2);

            dict.Get(key1_1, key2_1)
                .Should()
                .Be(value1);

            dict.Get(key1_1, key2_1)
                .Should()
                .NotBe(value2);

            dict.Get(key1_2, key2_2)
                .Should()
                .Be(value2);

            dict.Get(key1_2, key2_2)
                .Should()
                .NotBe(value1);
        }

        [Fact]
        public void Set_ShouldRespectCompositeKeys()
        {
            DateTime key1_1 = DateTime.UtcNow;
            Guid key2_1 = Guid.NewGuid();
            string value1 = "Butch Cassidy";

            DateTime key1_2 = DateTime.UtcNow.AddDays(-1);
            Guid key2_2 = Guid.NewGuid();
            string value2 = "Sundance Kid";

            var dict = GetDictionary();

            // setting initial values
            dict.Add(key1_1, key2_1, value2);
            dict.Add(key1_2, key2_2, value1);

            // switching values with set
            dict.Set(key1_1, key2_1, value1);
            dict.Set(key1_2, key2_2, value2);

            dict.Get(key1_1, key2_1)
                .Should()
                .Be(value1);

            dict.Get(key1_1, key2_1)
                .Should()
                .NotBe(value2);

            dict.Get(key1_2, key2_2)
                .Should()
                .Be(value2);

            dict.Get(key1_2, key2_2)
                .Should()
                .NotBe(value1);
        }

        [Fact]
        public void PrimaryKeys_ShouldContainAll1stKeys()
        {
            CompositeDictionary<string, Guid, Guid> dict = new CompositeDictionary<string, Guid, Guid>();

            string[] primaryKeys = {
                "Leonard",
                "Raj",
                "Sheldon",
                "Howard"
            };

            foreach (string key1 in primaryKeys)
                dict.Add(key1, Guid.NewGuid(), Guid.NewGuid());
            
            dict.PrimaryKeys
                .Should()
                .Contain(primaryKeys);
        }

        [Fact]
        public void SecondaryKeys_ShouldContainAll2ndKeys()
        {
            CompositeDictionary<Guid, string, Guid> dict = new CompositeDictionary<Guid, string, Guid>();

            string[] secondaryKeys = {
                "Sledge",
                "Leckie",
                "Snaffu"
            };

            foreach (string key2 in secondaryKeys)
                dict.Add(Guid.NewGuid(), key2, Guid.NewGuid());
            
            dict.SecondaryKeys
                .Should()
                .Contain(secondaryKeys);
        }

        private CompositeDictionary<DateTime, Guid, string> GetDictionary()
        {
            return new CompositeDictionary<DateTime, Guid, string>();
        }
    }
}