[![Build status](https://ci.appveyor.com/api/projects/status/tl89uy830l97qq6o?svg=true)](https://ci.appveyor.com/project/dlerps/ddev-tools)
# DDev Tools
**A collection of .Net tools and helper functions. Compatible with .Net Standard 1.3 and .Net Framework 4.6.1**

## How to use
The library is available on NuGet.org:
 
Install with package manager:
`PM > Install-Package DDev.Tools.Standard`

Install with donet CLI:
`> dotnet add package DDev.Tools.Standard`

## Content
### CollectionUtils
Collection utilities are a set of extension method. Currently there are only method for IDictionary.

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

// pos0 - pos3 -> true
bool pos0 = s0.IsLowerCamelCase();
bool pos1 = s1.IsUpperCamelCase(allowNumbers: true, maxLength: 30);
bool pos2 = s2.IsKebabStyle(RegexLetterCase.Both);
bool pos3 = s3.IsSnakeCase(RegexLetterCase.CaptialOnly);

// neg0 - neg3 -> false
bool neg0 = s0.IsUpperCamelCase();
bool neg1 = s1.IsUpperCamelCase(); // maxLength is 20 by default
bool neg2 = s2.IsKebabCase(); // RegexLetterCase.LowerOnly by default
bool neg3 = s3.IsLowerCamelCase();
```

## How to contribute
Any helpful utilities which are always welcome. Please fork the master branch and use pull requests if you would like to add some.
Please unit test your code and make sure existing unit tests continue to work.