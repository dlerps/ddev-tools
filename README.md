[![Build status](https://ci.appveyor.com/api/projects/status/tl89uy830l97qq6o?svg=true)](https://ci.appveyor.com/project/dlerps/ddev-tools) [![NuGet](https://img.shields.io/nuget/dt/DDev.Tools.Standard.svg)](https://preview.nuget.org/packages/DDev.Tools.Standard/)
# DDev Tools
**A collection of .Net tools and helper functions. Compatible with `.Net Standard 1.3` and `.Net Framework 4.6.1`**

## How to use
The library is available on [NuGet] and can be added to any project compatible with the target frameworks.
 
Install with package manager:
`PM > Install-Package DDev.Tools.Standard`

Install with donet CLI:
`> dotnet add package DDev.Tools.Standard`

## Content
### CollectionUtils
Collection utilities are a set of extension methods. Currently there are only methods for `IDictionary`.

### GenericDictionary
A dictionary implementation which only takes a generic type for the key and accepts all types of values.

```C#
using DDev.Tools;

GenericDictionary<string> dict = new GenericDictionary<string>();

dict.Add("key1", "stringValue");
dict.Add("key2", 2);
dict.Add("key3", 3.0);
dict.Add("key4", DateTime.UtcNow);

var val1 = dict.Get<string>("key1"); // "stringValue"
var val2 = dict.Get<int>("key2"); // 2
var val3 = dict.Get<double>("key3"); // 3.0
var val4 = dict.Get<DateTime>("key4"); // {1/1/2017 - 12:00:00}
```

### Convention Regex
Some convenience regex check for common convention styles are located in `ConventionRegex` as extension method of `string`.

```C#
using DDev.Tools;

string s0 = "lowerCamelCase";
string s1 = "UpperCamelCaseWith1Number";
string s2 = "mixed-Kebab-Case";
string s3 = "UPPER_SNAKE_CASE";
string s4 = "dot.notation";

// pos0 - pos3 -> true
bool pos0 = s0.IsLowerCamelCase();
bool pos1 = s1.IsUpperCamelCase(allowNumbers: true, maxLength: 30);
bool pos2 = s2.IsKebabStyle(allowedLetters: RegexLetterCase.Both);
bool pos3 = s3.IsSnakeCase(allowedLetters: RegexLetterCase.CaptialOnly);
bool pos4 = s4.IsDotNotation();

// neg0 - neg3 -> false
bool neg0 = s0.IsUpperCamelCase();
bool neg1 = s1.IsUpperCamelCase(); // maxLength is 20 by default
bool neg2 = s2.IsKebabCase(); // RegexLetterCase.LowerOnly by default
bool neg3 = s3.IsLowerCamelCase();
bool neg4 = s4.IsDotNotation(allowedLetters: RegexLetterCase.CaptialOnly);
```

### LinqUtils
The `LinqUtils` class only includes a single extension method for the `IEnumerable` interface. It Allows to split up the flat collection in an `IDictionary`.
You can select a common attribute of the items with a lambda expression. All items with the same attributes are afterwards added to a `List` which is the value to the shared attributed as a key.

```C#
using DDev.Tools;

internal class FictionCharacter
{
    public string Franchise { get; set; }
    public string Name { get; set; }
    // ...
}

var idols = new List<FictionCharacter>();
list.Add(new TestObject("Star Wars", "Luke Skywalker");
list.Add(new TestObject("Star Wars", "Han Solo");
list.Add(new TestObject("LotR", "Frodo");
list.Add(new TestObject("Star Wars", "Leia Organa");
list.Add(new TestObject("LotR", "Gandalf");
list.Add(new TestObject("Friends", "Joey Tribbiani");

var clustered = list.ToClusteredDictionary(attr => attr.Franchise);
// clustered:
// { 
//      "Star Wars" -> [ "Luke Skywalker", "Han Solo", "Leia" ],
//      "LotR" -> [ "Frodo", "Gandalf" ],
//      "Friends" -> [ "Joey Tribbiani" ],
// }
```

## How to contribute
Any helpful utilities which are always welcome. Please fork the master branch and use pull requests if you would like to add some.

Just keep in mind:
 - Write unit tests for your code 
 - Make sure existing unit tests continue to work.
 - Document the added functionality

### CI
The master branch is automatically built on AppVeyor. All unit tests are executed and a new library version is pushed to [NuGet].

[//]: #References
[NuGet]:<https://preview.nuget.org/packages/DDev.Tools.Standard/>
