using BenchmarkDotNet.Attributes;

namespace ProgressBar.Cmd;

public class ProgressBarBenchmarks
{
    double[] testValues;

    public ProgressBarBenchmarks(int count = 100)
    {
        Random rnd = new Random();
        testValues = Enumerable.Range(0, count).Select(x => rnd.NextDouble()).ToArray();
    }

    [Benchmark]
    public void GetProgressUnrolled()
    {
        ProgressBar factory = new ProgressBar();

        for (int i = 0; i < testValues.Length; i++)
        {
            _ = factory.GetProgressBarUnrolled(testValues[i]);
        }            
    }

    [Benchmark]
    public void GetProgressBT()
    {
        ProgressBar factory = new ProgressBar();

        for (int i = 0; i < testValues.Length; i++)
        {
            _ = factory.GetProgressBarBT(testValues[i]);
        }
    }

    [Benchmark]
    public void GetProgressLooped()
    {
        ProgressBar factory = new ProgressBar();

        for (int i = 0; i < testValues.Length; i++)
        {
            _ = factory.GetProgressBarLooped(testValues[i]);
        }
    }

    [Benchmark]
    public void GetProgressPadded()
    {
        ProgressBar factory = new ProgressBar();

        for (int i = 0; i < testValues.Length; i++)
        {
            _ = factory.GetProgressBarPadded(testValues[i]);
        }
    }

    [Benchmark]
    public void GetProgressPaddedWithCache()
    {
        ProgressBar factory = new ProgressBar();

        for (int i = 0; i < testValues.Length; i++)
        {
            _ = factory.GetProgressBarPaddedWithCache(testValues[i]);
        }
    }

    [Benchmark]
    public void GetProgressEnumerable()
    {
        ProgressBar factory = new ProgressBar();

        for (int i = 0; i < testValues.Length; i++)
        {
            _ = factory.GetProgressBarEnumerable(testValues[i]);
        }
    }

    [Benchmark]
    public void GetProgressPrepared()
    {
        ProgressBar factory = new ProgressBar();

        for (int i = 0; i < testValues.Length; i++)
        {
            _ = factory.GetProgressBarPrepared(testValues[i]);
        }
    }
}

