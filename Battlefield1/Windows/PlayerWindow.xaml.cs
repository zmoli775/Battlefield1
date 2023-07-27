using Battlefield1.API;
using Battlefield1.Data;
using Battlefield1.Utils;
using System.Security.Cryptography;

namespace Battlefield1.Windows;

/// <summary>
/// PlayerWindow.xaml 的交互逻辑
/// </summary>
public partial class PlayerWindow : Window
{
    public List<PlayerItem> Team1Players { get; set; } = new();
    public List<PlayerItem> Team2Players { get; set; } = new();

    public ObservableCollection<PlayerItem> Team1PlayerItems { get; set; } = new();
    public ObservableCollection<PlayerItem> Team2PlayerItems { get; set; } = new();

    private readonly ServerItem serverItem;

    public PlayerWindow(ServerItem serverItem)
    {
        InitializeComponent();

        this.serverItem = serverItem;
    }

    private void Window_Player_Loaded(object sender, RoutedEventArgs e)
    {
        GetServerPlayer();
    }

    private void Window_Player_Closing(object sender, CancelEventArgs e)
    {

    }

    private async void GetServerPlayer()
    {
        var result = await Blaze2788Pro.GetFullGameData(serverItem.GameId);
        if (result == null)
        {
            return;
        }

        var jsonObject = JsonNode.Parse(result);

        var LGAM = jsonObject["LGAM"];
        var GAME = LGAM[0]["GAME"];
        var PROS = LGAM[0]["PROS"];

        var ATTR = GAME["ATTR"];
        var admins = new StringBuilder();
        admins.Append(ATTR["admins1"].GetValue<string>());
        admins.Append(ATTR["admins2"].GetValue<string>());
        admins.Append(ATTR["admins3"].GetValue<string>());
        admins.Append(ATTR["admins4"].GetValue<string>());
        var vips = new StringBuilder();
        vips.Append(ATTR["vips1"].GetValue<string>());
        vips.Append(ATTR["vips2"].GetValue<string>());
        vips.Append(ATTR["vips3"].GetValue<string>());
        vips.Append(ATTR["vips4"].GetValue<string>());

        var adminList = admins.ToString().Split(';').Select(x => Convert.ToInt64(x)).ToList();
        var vipList = vips.ToString().Split(';').Select(x => Convert.ToInt64(x)).ToList();

        if (PROS is JsonArray pros)
        {
            for (int i = 0; i < pros.Count; i++)
            {
                var pro = pros[i];

                var teamId = pro["TIDX"].GetValue<int>();
                var pid = pro["PID"].GetValue<long>();
                var name = pro["NAME"].GetValue<string>();
                var playTime = pro["TIME"].GetValue<long>();

                var rank = 0;
                if (pro["PATT"]["rank"] != null && int.TryParse(pro["PATT"]["rank"].GetValue<string>(), out int tempRank))
                    rank = tempRank;

                var latency = pro["PATT"]["latency"].GetValue<string>();

                if (teamId == 0)
                {
                    // 队伍1
                    Team1Players.Add(new()
                    {
                        PID = pid,
                        Name = name,
                        PlayTime = playTime,
                        Rank = rank,
                        Latency = latency
                    });
                }
                else
                {
                    // 队伍2
                    Team2Players.Add(new()
                    {
                        PID = pid,
                        Name = name,
                        PlayTime = playTime,
                        Rank = rank,
                        Latency = latency
                    });
                }
            }
        }

        // 等级排序
        Team1Players.Sort((a, b) => -a.Rank.CompareTo(b.Rank));
        Team2Players.Sort((a, b) => -a.Rank.CompareTo(b.Rank));

        var index = 0;
        Team1Players.ForEach(player =>
        {
            Team1PlayerItems.Add(new()
            {
                Index = ++index,
                PID = player.PID,
                Name = player.Name,
                PlayTime = PlayerUtil.GetPlayTimeMinute(player.PlayTime),
                Rank = player.Rank,
                RankImage = ClientUtil.GetPlayerRankImage(player.Rank),
                Latency = player.Latency,
                IsAdmin = adminList.Contains(player.PID),
                IsVIP = vipList.Contains(player.PID)
            });
        });

        index = 0;
        Team2Players.ForEach(player =>
        {
            Team2PlayerItems.Add(new()
            {
                Index = ++index,
                PID = player.PID,
                Name = player.Name,
                PlayTime = PlayerUtil.GetPlayTimeMinute(player.PlayTime),
                Rank = player.Rank,
                RankImage = ClientUtil.GetPlayerRankImage(player.Rank),
                Latency = player.Latency,
                IsAdmin = adminList.Contains(player.PID),
                IsVIP = vipList.Contains(player.PID)
            });
        });
    }
}
