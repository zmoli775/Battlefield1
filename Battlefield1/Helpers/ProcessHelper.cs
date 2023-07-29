namespace Battlefield1.Helpers;

public static class ProcessHelper
{
    /// <summary>
    /// 打开http链接
    /// </summary>
    /// <param name="url"></param>
    public static void OpenLink(string url)
    {
        if (!url.StartsWith("http"))
            return;

        Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
    }
}
