namespace ProgressBar.Tests;

[TestClass]
public class ProgressBarTests
{
    Cmd.ProgressBar factory = new Cmd.ProgressBar();

    [TestMethod]
    [DataRow(0.56, "●●●●●●○○○○")]
    [DataRow(0.5, "●●●●●○○○○○")]
    [DataRow(0.42, "●●●●●○○○○○")]
    [DataRow(0, "○○○○○○○○○○")]
    [DataRow(1, "●●●●●●●●●●")]
    public void TestAll(double value, string expected)
    {
        PerformTest(v => factory.GetProgressBarUnrolled(v), value, expected);
        PerformTest(v => factory.GetProgressBarBT(v), value, expected);
        PerformTest(v => factory.GetProgressBarLooped(v), value, expected);
        PerformTest(v => factory.GetProgressBarPadded(v), value, expected);
        PerformTest(v => factory.GetProgressBarEnumerable(v), value, expected);
        PerformTest(v => factory.GetProgressBarPrepared(v), value, expected);
    }

    private void PerformTest(Func<double, string> action, double value, string expected)
    {
        var result = action(value);
        Assert.AreEqual(expected, result);
    }
}