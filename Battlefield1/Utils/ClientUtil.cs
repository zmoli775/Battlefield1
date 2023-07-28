namespace Battlefield1.Utils;

public static class ClientUtil
{
    /// <summary>
    /// 获取服务器区域图片
    /// </summary>
    /// <param name="region"></param>
    /// <returns></returns>
    public static string GetServerRegionImage(string region)
    {
        if (string.IsNullOrWhiteSpace(region))
            return string.Empty;

        return $"/Assets/Images/Region/{region.ToLower()}.png";
    }

    /// <summary>
    /// 获取服务器阵营图片
    /// </summary>
    /// <param name="faction"></param>
    /// <returns></returns>
    public static string GetServerFactionImage(string faction)
    {
        if (string.IsNullOrWhiteSpace(faction))
            return string.Empty;

        return $"/Assets/Images/Faction/{faction.ToLower()}.png";
    }

    /// <summary>
    /// 获取服务器地图图片（小型）
    /// </summary>
    /// <param name="map"></param>
    /// <returns></returns>
    public static string GetServerMapImageSmall(string map)
    {
        if (string.IsNullOrWhiteSpace(map))
            return string.Empty;

        var match = Regex.Match(map, "MP_.*_");
        if (match.Success)
            return $"/Assets/Images/Map/{match.Groups[0].Value.ToLower()}small.jpg";

        return string.Empty;
    }

    /// <summary>
    /// 获取服务器地图图片（中等）
    /// </summary>
    /// <param name="map"></param>
    /// <returns></returns>
    public static string GetServerMapImageMedium(string map)
    {
        if (string.IsNullOrWhiteSpace(map))
            return string.Empty;

        var match = Regex.Match(map, "MP_.*_");
        if (match.Success)
            return $"/Assets/Images/Map/{match.Groups[0].Value.ToLower()}medium.jpg";

        return string.Empty;
    }

    /// <summary>
    /// 获取玩家等级图片
    /// </summary>
    /// <param name="rank"></param>
    /// <returns></returns>
    public static string GetPlayerRankImage(int rank)
    {
        if (rank > 0 && rank <= 9)
            return "/Assets/Images/Rank/rank-1.png";
        if (rank >= 10 && rank <= 19)
            return "/Assets/Images/Rank/rank-10.png";
        if (rank >= 20 && rank <= 29)
            return "/Assets/Images/Rank/rank-20.png";
        if (rank >= 30 && rank <= 39)
            return "/Assets/Images/Rank/rank-30.png";
        if (rank >= 40 && rank <= 49)
            return "/Assets/Images/Rank/rank-40.png";
        if (rank >= 50 && rank <= 59)
            return "/Assets/Images/Rank/rank-50.png";
        if (rank >= 60 && rank <= 69)
            return "/Assets/Images/Rank/rank-60.png";
        if (rank >= 70 && rank <= 79)
            return "/Assets/Images/Rank/rank-70.png";
        if (rank >= 80 && rank <= 89)
            return "/Assets/Images/Rank/rank-80.png";
        if (rank >= 90 && rank <= 99)
            return "/Assets/Images/Rank/rank-90.png";
        if (rank >= 100 && rank <= 109)
            return "/Assets/Images/Rank/rank-100.png";
        if (rank >= 110 && rank <= 119)
            return "/Assets/Images/Rank/rank-110.png";
        if (rank >= 120 && rank <= 129)
            return "/Assets/Images/Rank/rank-120.png";
        if (rank >= 130 && rank <= 139)
            return "/Assets/Images/Rank/rank-130.png";
        if (rank >= 140 && rank <= 149)
            return "/Assets/Images/Rank/rank-140.png";
        if (rank == 150)
            return "/Assets/Images/Rank/rank-150.png";

        return "/Assets/Images/Rank/rank-0.png";
    }

    /// <summary>
    /// 获取游戏语言
    /// </summary>
    /// <param name="loc"></param>
    /// <returns></returns>
    public static string GetGameLanguage(long loc)
    {
        return loc switch
        {
            1936802124 => "阿尔巴尼亚语",
            1650803289 => "比利时语",
            1886667346 => "葡萄牙语(巴西)",
            1650934343 => "保加利亚语",
            1752320082 => "克罗地亚语",
            1668498266 => "捷克语",
            1684096075 => "丹麦语",
            1702118725 => "爱沙尼亚语",
            1718175305 => "芬兰语",
            1718765138 => "法语",
            1684358213 => "德语",
            1701594962 => "希腊语",
            1752516693 => "匈牙利语",
            1952532814 => "泰米尔语",
            1768842345 => "印度语",
            1751468364 => "希伯来语",
            1769228628 => "意大利语",
            1784760912 => "日语",
            1819692118 => "拉脱维亚语",
            1819561044 => "立陶宛语",
            1852591692 => "荷兰语",
            1851936335 => "挪威语",
            1886146636 => "波兰语",
            1802455890 => "朝鲜语",
            1919898191 => "罗马尼亚语",
            1920291413 => "俄语",
            2053653326 => "简体中文",
            1936479051 => "斯洛伐克语",
            1936479049 => "斯洛文尼亚语",
            1702053203 => "西班牙语",
            1634877765 => "阿拉伯语",
            1937134422 => "瑞典语",
            1952994376 => "泰语",
            2053657687 => "繁体中文",
            1953649746 => "土耳其语",
            1969968449 => "乌克兰语",
            1701726018 => "英式英语",
            1701729619 => "美式英语",
            1986614862 => "越南语",
            //_ => "未知",
            _ => $"{loc}",
        };
    }
}
