# Neomaster.Extensions.Exception

Retrieves all internal exceptions of the exception tree,
including `AggregateException` nodes.

![.NET Standard 2.1](https://img.shields.io/badge/.NET_Standard-v2.1-informational)

---

## Tests

### [GetAllInnerExceptions() Tests](https://github.com/neomasterhub/Neomaster.Way/blob/master/.Net/Tests/StandardsTests6/Extensions/ExceptionExtensions/GetAllInnerExceptionsUnitTests.cs)

### Conventions
* `e` - `Exception` instance
* `ae` - `AggregateException` instance
* `[e,ae]` - list
* `e1[e2,e3]` - root with children

### Examples
#### Don't include `AggregateException` *(default)*
```c#
[Fact(DisplayName = "ae1[e1,ae2[e2]] -> [e1,e2]")]
public void ShouldReturnOnlyNonAggregateExceptions_3()
{
    var e1 = new Exception("1");
    var e2 = new Exception("2");
    var expected = new Exception[]
    {
        e1,
        e2,
    };
    var tree =
        new AggregateException(
            e1,
            new AggregateException(
                e2));

    var actual = tree.GetAllInnerExceptions();

    Assert.Equal(expected.Length, actual.Count);
    Assert.Equal(expected, actual);
    Assert.Equal(expected.Select(e => e.Message), actual.Select(e => e.Message));
}
```
#### Include `AggregateException`
```c#
[Fact(DisplayName = "ae1[ae2[ae3]] -> [ae1,ae2,ae3]")]
public void ShouldReturnAllExceptions_3()
{
    var ae3 = new AggregateException();
    var ae2 = new AggregateException(ae3);
    var ae1 = new AggregateException(ae2);
    var expected = new Exception[]
    {
        ae1,
        ae2,
        ae3,
    };

    var actual = ae1.GetAllInnerExceptions(addAggregate: true);

    Assert.Equal(expected.Length, actual.Count);
    Assert.Equal(expected, actual);
    Assert.Equal(expected.Select(e => e.Message), actual.Select(e => e.Message));
}
```