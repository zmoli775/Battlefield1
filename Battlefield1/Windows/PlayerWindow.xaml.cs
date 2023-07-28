using Battlefield1.API;
using Battlefield1.Data;
using Battlefield1.Models;
using Battlefield1.Utils;

using CommunityToolkit.Mvvm.Input;

namespace Battlefield1.Windows;

/// <summary>
/// PlayerWindow.xaml 的交互逻辑
/// </summary>
public partial class PlayerWindow : Window
{
    public PlayerModel PlayerModel { get; set; } = new();

    public ObservableCollection<PlayerItem> Team1PlayerItems { get; set; } = new();
    public ObservableCollection<PlayerItem> Team2PlayerItems { get; set; } = new();

    public readonly List<PlayerItem> Team1Players = new();
    public readonly List<PlayerItem> Team2Players = new();

    public readonly List<long> AdminList = new();
    public readonly List<long> VIPList = new();

    public PlayerWindow(ServerItem serverItem)
    {
        InitializeComponent();

        PlayerModel.GameId = serverItem.GameId;
        PlayerModel.Guid = serverItem.Guid;
        PlayerModel.RegionImage = serverItem.RegionImage;
        PlayerModel.Name = serverItem.Name;
        PlayerModel.Description = serverItem.Description;
        PlayerModel.Soldier = serverItem.Soldier;
        PlayerModel.MaxSoldier = serverItem.MaxSoldier;
        PlayerModel.Queue = serverItem.Queue;
        PlayerModel.Spectator = serverItem.Spectator;
        PlayerModel.MapMode = serverItem.MapMode;
        PlayerModel.MapName = serverItem.MapName;
        PlayerModel.MapImage = serverItem.MapImage;
        PlayerModel.IsCustom = serverItem.IsCustom;
        PlayerModel.IsOfficial = serverItem.IsOfficial;
        PlayerModel.TickRate = serverItem.TickRate;

        PlayerModel.Team1Image = serverItem.Team1Image;
        PlayerModel.Team2Image = serverItem.Team2Image;
    }

    private async void Window_Player_Loaded(object sender, RoutedEventArgs e)
    {
        await GetServerPlayer();
    }

    private void Window_Player_Closing(object sender, CancelEventArgs e)
    {
    }

    [RelayCommand]
    private async Task GetServerPlayer()
    {
        Team1Players.Clear();
        Team2Players.Clear();

        Team1PlayerItems.Clear();
        Team2PlayerItems.Clear();

        LoadingSpinner_Search.IsLoading = true;
        TextBlock_SearchResult.Visibility = Visibility.Hidden;

        ///////////////////////////////////////////////////

        var result = await Blaze2788Pro.GetFullGameData(PlayerModel.GameId);
        if (result == null)
        {
            LoadingSpinner_Search.IsLoading = false;
            TextBlock_SearchResult.Visibility = Visibility.Visible;
            TextBlock_SearchResult.Text = "未找到搜索结果或搜索失败，请重试";
            return;
        }

        LoadingSpinner_Search.IsLoading = false;

        ///////////////////////////////////////////////////

        var jsonObject = JsonNode.Parse(result);

        var LGAM = jsonObject["LGAM"];
        var GAME = LGAM[0]["GAME"];
        var PROS = LGAM[0]["PROS"];

        var ATTR = GAME["ATTR"];
        var admins = new StringBuilder();
        admins.Append(ATTR["admins1"].GetValue<string>().Trim());
        admins.Append(ATTR["admins2"].GetValue<string>().Trim());
        admins.Append(ATTR["admins3"].GetValue<string>().Trim());
        admins.Append(ATTR["admins4"].GetValue<string>().Trim());
        var vips = new StringBuilder();
        vips.Append(ATTR["vips1"].GetValue<string>().Trim());
        vips.Append(ATTR["vips2"].GetValue<string>().Trim());
        vips.Append(ATTR["vips3"].GetValue<string>().Trim());
        vips.Append(ATTR["vips4"].GetValue<string>().Trim());

        admins.ToString().Split(';').ToList().ForEach(x =>
        {
            if (long.TryParse(x, out long pid))
                AdminList.Add(pid);
        });
        vips.ToString().Split(';').ToList().ForEach(x =>
        {
            if (long.TryParse(x, out long pid))
                VIPList.Add(pid);
        });

        if (PROS is JsonArray pros)
        {
            for (int i = 0; i < pros.Count; i++)
            {
                var pro = pros[i];

                var teamId = pro["TIDX"].GetValue<int>();
                var pid = pro["PID"].GetValue<long>();
                var name = pro["NAME"].GetValue<string>();
                var playTime = pro["TIME"].GetValue<long>();

                var PATT = pro["PATT"];
                var rank = -1;
                var latency = -1;
                if (PATT != null)
                {
                    if (PATT["rank"] != null && int.TryParse(PATT["rank"].GetValue<string>(), out int tempRank))
                        rank = tempRank;

                    if (PATT["latency"] != null && int.TryParse(PATT["latency"].GetValue<string>(), out int tempLatency))
                        latency = tempLatency;
                }

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
        Team1Players.Sort(PlayerComparison);
        Team2Players.Sort(PlayerComparison);

        // 更新UI
        UpdateUI(Team1Players, Team1PlayerItems);
        UpdateUI(Team2Players, Team2PlayerItems);
    }

    private void UpdateUI(List<PlayerItem> teamPlayers, ObservableCollection<PlayerItem> teamPlayerItems)
    {
        var index = 0;
        teamPlayers.ForEach(player =>
        {
            teamPlayerItems.Add(new()
            {
                Index = ++index,
                PID = player.PID,
                Name = player.Name,
                PlayTime = PlayerUtil.GetPlayTimeMinute(player.PlayTime),
                Rank = player.Rank,
                RankImage = ClientUtil.GetPlayerRankImage(player.Rank),
                Latency = player.Latency,
                IsAdmin = AdminList.Contains(player.PID),
                IsVIP = VIPList.Contains(player.PID),
                Is100Plus = player.Rank >= 100,
                Is150 = player.Rank == 150
            });
        });
    }

    private int PlayerComparison(PlayerItem p1, PlayerItem p2)
    {
        if (p1.Rank != p2.Rank)
        {
            return -p1.Rank.CompareTo(p2.Rank);
        }
        else if (p1.PlayTime != p2.PlayTime)
        {
            return p1.PlayTime.CompareTo(p2.PlayTime);
        }
        else if (p1.Latency != p2.Latency)
        {
            return p1.Latency.CompareTo(p2.Latency);
        }
        return 0;
    }

    private async void GetPlayerLifeData(List<PlayerItem> team1Players, List<PlayerItem> team2Players)
    {
        var pidList = new List<long>();
        var pidListStr = string.Join(',', pidList.ToArray());

        team1Players.ForEach(player => pidList.Add(player.PID));
        team2Players.ForEach(player => pidList.Add(player.PID));

        var result = await Blaze2788Pro.GetPlayerCore(pidListStr);
        if (result == null)
        {

        }
    }
}
