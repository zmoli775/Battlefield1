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
}
