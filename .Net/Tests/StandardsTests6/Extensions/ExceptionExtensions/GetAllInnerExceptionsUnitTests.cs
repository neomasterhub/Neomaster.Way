#pragma warning disable SA1124
using Neomaster.Extensions.Exception;

namespace StandardsTests6.Extensions.ExceptionExtensions;

/// <summary>
/// <c>e</c> - <see cref="Exception"/> instance,<br/>
/// <c>ae</c> - <see cref="AggregateException"/> instance,<br/>
/// <c>[e1,e2,e3]</c> - list,<br/>
/// <c>e1[e2,e3]</c> - root with children.
/// </summary>
public class GetAllInnerExceptionsUnitTests
{
    #region Should return empty
    [Fact(DisplayName = "null -> []")]
    public void ShouldReturnEmpty_1()
    {
        var actual = (null as Exception).GetAllInnerExceptions();

        Assert.Empty(actual);
    }

    [Fact(DisplayName = "ae -> []")]
    public void ShouldReturnEmpty_2()
    {
        var actual = new AggregateException().GetAllInnerExceptions();

        Assert.Empty(actual);
    }

    [Fact(DisplayName = "ae1[ae2[ae3]] -> []")]
    public void ShouldReturnEmpty_3()
    {
        var tree =
            new AggregateException(
                new AggregateException(
                    new AggregateException()));

        var actual = tree.GetAllInnerExceptions();

        Assert.Empty(actual);
    }

    [Fact(DisplayName = "ae1[ae2,ae3] -> []")]
    public void ShouldReturnEmpty_4()
    {
        var tree =
            new AggregateException(
                new AggregateException(),
                new AggregateException());

        var actual = tree.GetAllInnerExceptions();

        Assert.Empty(actual);
    }
    #endregion
}
