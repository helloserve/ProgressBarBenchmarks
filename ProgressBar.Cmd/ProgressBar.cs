using System.Text;

namespace ProgressBar.Cmd;

public class ProgressBar
{
    public string GetProgressBarUnrolled(double percentage)
    {
        if (percentage == 0)
            return "○○○○○○○○○○";
        else if (percentage > 0 && percentage <= 0.1)
            return "●○○○○○○○○○";
        else if (percentage > 0.1 && percentage <= 0.2)
            return "●●○○○○○○○○";
        else if (percentage > 0.2 && percentage <= 0.3)
            return "●●●○○○○○○○";
        else if (percentage > 0.3 && percentage <= 0.4)
            return "●●●●○○○○○○";
        else if (percentage > 0.4 && percentage <= 0.5)
            return "●●●●●○○○○○";
        else if (percentage > 0.5 && percentage <= 0.6)
            return "●●●●●●○○○○";
        else if (percentage > 0.6 && percentage <= 0.7)
            return "●●●●●●●○○○";
        else if (percentage > 0.7 && percentage <= 0.8)
            return "●●●●●●●●○○";
        else if (percentage > 0.8 && percentage <= 0.9)
            return "●●●●●●●●●○";
        
        return "●●●●●●●●●●";
    }

    public string GetProgressBarBT(double percentage)
    {
        if (percentage >= 0 && percentage <= 0.5)
        {
            if (percentage <= 0.2)
            {
                if (percentage <= 0.1)
                {
                    if (percentage <= 0)
                        return "○○○○○○○○○○";
                    return "●○○○○○○○○○";
                }
                return "●●○○○○○○○○";
            }
            if (percentage <= 0.4)
            {
                if (percentage <= 0.3)
                    return "●●●○○○○○○○";
                return "●●●●○○○○○○";
            }
            return "●●●●●○○○○○";
        }
        if (percentage > 0.5 && percentage <= 0.9)
        {
            if (percentage <= 0.7)
            {
                if (percentage <= 0.6)
                    return "●●●●●●○○○○";
                return "●●●●●●●○○○";
            }
            if (percentage <= 0.8)
                return "●●●●●●●●○○";
            return "●●●●●●●●●○";
        }
        return "●●●●●●●●●●";
    }

    public string GetProgressBarLooped(double percentage)
    {
        var count = (int)Math.Ceiling(percentage * 10);
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < count; i++)
        {
            sb.Append("●");
        }
        for (int i = 0; i < 10 - count; i++)
        {
            sb.Append("○");
        }
        return sb.ToString();
    }

    public string GetProgressBarPadded(double percentage)
    {
        var count = (int)Math.Ceiling(percentage * 10);
        return "".PadLeft(Math.Min(10 - (Math.Min(10, count)), 10), '○').PadLeft(10, '●');
    }

    static Dictionary<int, string> progressCache = new Dictionary<int, string>();

    public string GetProgressBarPaddedWithCache(double percentage)
    {
        var count = (int)Math.Ceiling(percentage * 10);
        if (progressCache.ContainsKey(count))
            return progressCache[count];
        else
        {
            var s = "".PadLeft(Math.Min(10 - (Math.Min(10, count)), 10), '○').PadLeft(10, '●');
            progressCache.Add(count, s);
            return s;
        }
    }

    public string GetProgressBarEnumerable(double percentage)
    {
        return string.Concat(Enumerable.Range(0, 10).Select(x => percentage > x / 10.0 ? '●' : '○'));
    }

    static string[] preparedCache = new string[]
    {
        "○○○○○○○○○○",
        "●○○○○○○○○○",
        "●●○○○○○○○○",
        "●●●○○○○○○○",
        "●●●●○○○○○○",
        "●●●●●○○○○○",
        "●●●●●●○○○○",
        "●●●●●●●○○○",
        "●●●●●●●●○○",
        "●●●●●●●●●○",
        "●●●●●●●●●●",
    };

    public string GetProgressBarPrepared(double percentage)
    {
        var count = (int)Math.Ceiling(percentage * 10);
        return preparedCache[count];
    }
}