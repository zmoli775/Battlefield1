namespace Battlefield1.Utils;

public static class PlayerUtil
{
    public static int GetPlayTimeMinute(long timeStamp)
    {
        var time = DateTimeOffset.FromUnixTimeMilliseconds(timeStamp / 1000).DateTime.ToLocalTime();

        var ts1 = new TimeSpan(DateTime.Now.Ticks);
        var ts2 = new TimeSpan(time.Ticks);

        return (int)ts1.Subtract(ts2).Duration().TotalMinutes;
    }
}
