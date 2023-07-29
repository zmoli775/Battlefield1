namespace Battlefield1.Utils;

public static class MiscUtil
{
    /// <summary>
    /// 获取当前星期数字符串
    /// </summary>
    /// <returns></returns>
    public static string GetWeekName()
    {
        return (int)DateTime.Now.DayOfWeek switch
        {
            0 => "星期日",
            1 => "星期壹",
            2 => "星期二",
            3 => "星期三",
            4 => "星期四",
            5 => "星期五",
            _ => "星期六",
        };
    }
}
