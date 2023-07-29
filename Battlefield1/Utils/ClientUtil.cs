namespace Battlefield1.Utils;

public static class ClientUtil
{
    /// <summary>
    /// 获取服务器国家图片
    /// </summary>
    /// <param name="country"></param>
    /// <returns></returns>
    public static string GetServerCountryImage(string country)
    {
        if (string.IsNullOrWhiteSpace(country))
            return string.Empty;

        return $"/Assets/Images/Country/{country.ToLower()}.png";
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
    /// 从URL中提取服务器地图名称
    /// </summary>
    /// <param name="map"></param>
    /// <returns></returns>
    public static string GetServerMapNameFormURL(string map)
    {
        var match = Regex.Match(map, "MP_.*_");
        if (match.Success)
            return match.Groups[0].Value.ToLower();

        return string.Empty;
    }

    /// <summary>
    /// 获取服务器地图图片（小型）
    /// </summary>
    /// <param name="map"></param>
    /// <returns></returns>
    public static string GetServerMapImageSmall(string map)
    {
        var mapName = GetServerMapNameFormURL(map);
        if (string.IsNullOrWhiteSpace(mapName))
            return string.Empty;

        return $"/Assets/Images/Map/{mapName}small.jpg";
    }

    /// <summary>
    /// 获取服务器地图图片（中等）
    /// </summary>
    /// <param name="map"></param>
    /// <returns></returns>
    public static string GetServerMapImageMedium(string map)
    {
        var mapName = GetServerMapNameFormURL(map);
        if (string.IsNullOrWhiteSpace(mapName))
            return string.Empty;

        return $"/Assets/Images/Map/{mapName}medium.jpg";
    }

    /// <summary>
    /// 获取服务器地图图片（大型）
    /// </summary>
    /// <param name="map"></param>
    /// <returns></returns>
    public static string GetServerMapImageAny(string map)
    {
        var mapName = GetServerMapNameFormURL(map);
        if (string.IsNullOrWhiteSpace(mapName))
            return string.Empty;

        return $"/Assets/Images/Map/{mapName}any.jpg";
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
        var temp = loc / 100000;

        return temp switch
        {
            16840 => "丹語",
            16843 => "德語",
            17017 => "英語",
            17020 => "西語",
            17181 => "芬語",
            17187 => "法語",
            17525 => "匈語",
            17692 => "意語",
            17847 => "日語",
            18024 => "韓語",
            18525 => "荷語",
            18861 => "波語",
            18866 => "葡語",
            19202 => "俄語",
            19371 => "瑞語",
            19529 => "泰語",
            19536 => "土語",
            19699 => "烏語",
            20536 => "中文",
            _ => "其他",
        };
    }

    /// <summary>
    /// 获取服务器ping数字
    /// </summary>
    /// <param name="country"></param>
    /// <returns></returns>
    public static int GetServerPingNumber(string country)
    {
        return country.ToLower() switch
        {
            "hk" => 34,
            "jp" => 56,
            "de" => 149,
            "au" => 180,
            "us" => 206,
            "br" => 231,
            _ => 300,
        };
    }

    /// <summary>
    /// 获取服务器ping图片
    /// </summary>
    /// <param name="country"></param>
    /// <returns></returns>
    public static string GetServerPingImage(string country)
    {
        var name = country.ToLower() switch
        {
            "hk" => "ping-best",
            "jp" => "ping-good",
            "de" => "ping-ok",
            "au" => "ping-bad",
            "us" => "ping-worst",
            "br" => "ping-worst",
            _ => "ping-unknown"
        };

        return $"/Assets/Images/Ping/{name}.png";
    }
}
