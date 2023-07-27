namespace Battlefield1.Utils;

public static class ServerUtil
{
    /// <summary>
    /// 获取服务器区域图片
    /// </summary>
    /// <param name="region"></param>
    /// <returns></returns>
    public static string GetServerRegionImage(string region)
    {
        return $"/Assets/Images/Region/{region.ToLower()}.png";
    }

    /// <summary>
    /// 获取服务器地图小图片
    /// </summary>
    /// <param name="map"></param>
    /// <returns></returns>
    public static string GetServerMapImageSmall(string map)
    {
        var match = Regex.Match(map, "MP_.*_");
        if (match.Success)
            return $"/Assets/Images/Map/{match.Groups[0].Value.ToLower()}small.jpg";

        return string.Empty;
    }

    /// <summary>
    /// 获取服务器地图中等图片
    /// </summary>
    /// <param name="map"></param>
    /// <returns></returns>
    public static string GetServerMapImageMedium(string map)
    {
        var match = Regex.Match(map, "MP_.*_");
        if (match.Success)
            return $"/Assets/Images/Map/{match.Groups[0].Value.ToLower()}medium.jpg";

        return string.Empty;
    }
}
