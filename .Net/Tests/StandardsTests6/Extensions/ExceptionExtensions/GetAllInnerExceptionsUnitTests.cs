#pragma warning disable SA1124, SA1116
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

    #region Should return single
    [Fact(DisplayName = "e -> [e]")]
    public void ShouldReturnSingle_1()
    {
        var expectedSingle = new Exception();

        var actual = expectedSingle.GetAllInnerExceptions();

        Assert.Single(actual);
        Assert.Equal(expectedSingle, actual.Single());
    }

    [Fact(DisplayName = "ae -> [ae]")]
    public void ShouldReturnSingle_2()
    {
        var expectedSingle = new AggregateException();

        var actual = expectedSingle.GetAllInnerExceptions(addAggregate: true);
        var actualSingle = actual.Single();

        Assert.Single(actual);
        Assert.IsType<AggregateException>(actualSingle);
        Assert.Equal(expectedSingle, actualSingle);
    }

    [Fact(DisplayName = "ae -> [e]")]
    public void ShouldReturnSingle_3()
    {
        var expectedSingleMessage = "error";

        var actual = new AggregateException(expectedSingleMessage).GetAllInnerExceptions(
            addAggregate: true,
            aggregateToSingle: true);
        var actualSingle = actual.Single();

        Assert.Single(actual);
        Assert.IsNotType<AggregateException>(actualSingle);
        Assert.Equal(nameof(Exception), actualSingle.GetType().Name);
        Assert.Equal(expectedSingleMessage, actualSingle.Message);
    }

    [Fact(DisplayName = "e[ae] -> [e]")]
    public void ShouldReturnSingle_4()
    {
        var actual = new Exception(null, new AggregateException()).GetAllInnerExceptions();

        Assert.Single(actual);
        Assert.Equal(nameof(Exception), actual.Single().GetType().Name);
    }

    [Fact(DisplayName = "ae[e] -> [e]")]
    public void ShouldReturnSingle_5()
    {
        var actual = new AggregateException(new Exception()).GetAllInnerExceptions();

        Assert.Single(actual);
        Assert.Equal(nameof(Exception), actual.Single().GetType().Name);
    }

    [Fact(DisplayName = "e[ae1[ae2]] -> [e]")]
    public void ShouldReturnSingle_6()
    {
        var tree =
            new Exception(null,
                new AggregateException(
                    new AggregateException()));

        var actual = tree.GetAllInnerExceptions();

        Assert.Single(actual);
        Assert.Equal(nameof(Exception), actual.Single().GetType().Name);
    }

    [Fact(DisplayName = "ae1[ae2[e]] -> [e]")]
    public void ShouldReturnSingle_7()
    {
        var tree =
            new AggregateException(
                new AggregateException(
                    new Exception()));

        var actual = tree.GetAllInnerExceptions();

        Assert.Single(actual);
        Assert.Equal(nameof(Exception), actual.Single().GetType().Name);
    }

    [Fact(DisplayName = "ae1[e[ae2]] -> [e]")]
    public void ShouldReturnSingle_8()
    {
        var tree =
            new AggregateException(
                new Exception(null,
                    new AggregateException()));

        var actual = tree.GetAllInnerExceptions();

        Assert.Single(actual);
        Assert.Equal(nameof(Exception), actual.Single().GetType().Name);
    }
    #endregion
}
