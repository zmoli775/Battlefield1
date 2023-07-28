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
            1936802124 => "sq-AL",
            1650803289 => "be-BY",
            1886667346 => "pt-BR",
            1650934343 => "bg-BG",
            1752320082 => "hr-HR",
            1668498266 => "cs-CZ",
            1684096075 => "da-DK",
            1702118725 => "et-EE",
            1718175305 => "fi-FI",
            1718765138 => "fr-FR",
            1684358213 => "de-DE",
            1701594962 => "el-GR",
            1752516693 => "hu-HU",
            1952532814 => "ta-IN",
            1768842345 => "in-di",
            1751468364 => "he-IL",
            1769228628 => "it-IT",
            1784760912 => "ja-JP",
            1819692118 => "lv-LV",
            1819561044 => "lt-LT",
            1852591692 => "nl-NL",
            1851936335 => "nb-NO",
            1886146636 => "pl-PL",
            1802455890 => "ko-KR",
            1919898191 => "ro-RO",
            1920291413 => "ru-RU",
            2053653326 => "zh-CN",
            1936479051 => "sl-SK",
            1936479049 => "sl-SI",
            1702053203 => "es-ES",
            1634877765 => "ar-AE",
            1937134422 => "sv-SV",
            1952994376 => "th-TH",
            2053657687 => "zh-TW",
            1953649746 => "tr-TR",
            1969968449 => "uk-UA",
            1701726018 => "en-GB",
            1701729619 => "en-US",
            1986614862 => "vi-VN",
            _ => "未知",
        };
    }
}
