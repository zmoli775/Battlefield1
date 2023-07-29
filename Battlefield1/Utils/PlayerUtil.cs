namespace Battlefield1.Utils;

public static class PlayerUtil
{
    /// <summary>
    /// 时间戳转分钟数
    /// </summary>
    /// <param name="timeStamp"></param>
    /// <returns></returns>
    public static int GetPlayTimeMinute(long timeStamp)
    {
        var time = DateTimeOffset.FromUnixTimeMilliseconds(timeStamp / 1000).DateTime.ToLocalTime();

        var ts1 = new TimeSpan(DateTime.Now.Ticks);
        var ts2 = new TimeSpan(time.Ticks);

        return (int)ts1.Subtract(ts2).Duration().TotalMinutes;
    }

    /// <summary>
    /// 获取玩家游玩时间，传入时间为秒，返回分钟数或小时数
    /// </summary>
    /// <param name="second">秒</param>
    /// <returns></returns>
    public static string GetPlayTimeStrBySecond(float second)
    {
        var ts = TimeSpan.FromSeconds(second);

        // 低于一小时，则显示分钟数
        if (ts.TotalHours < 1)
            return $"{ts.TotalMinutes:0} 分鍾";

        return $"{ts.TotalHours:0} 小時";
    }

    /// <summary>
    /// 获取游玩小时数，传入时间为秒
    /// </summary>
    /// <param name="second">秒</param>
    /// <returns></returns>
    public static int GetPlayHoursBySecond(float second)
    {
        var ts = TimeSpan.FromSeconds(second);
        return (int)ts.TotalHours;
    }

    /// <summary>
    /// 获取游玩分钟数，传入时间为秒
    /// </summary>
    /// <param name="second">秒</param>
    /// <returns></returns>
    public static int GetPlayMinutesBySecond(float second)
    {
        var ts = TimeSpan.FromSeconds(second);
        return (int)ts.TotalMinutes;
    }

    /// <summary>
    /// 获取百分比
    /// </summary>
    /// <param name="num1">被除数</param>
    /// <param name="num2">除数，不可为0</param>
    /// <returns></returns> 
    public static float GetPlayerPercent(float num1, float num2)
    {
        if (num2 == 0)
            return 0.0f;

        return num1 / num2 * 100;
    }
}
