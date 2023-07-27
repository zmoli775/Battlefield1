using Battlefield1.API;
using Battlefield1.Data;
using Battlefield1.Utils;

namespace Battlefield1.Views;

/// <summary>
/// ServerView.xaml 的交互逻辑
/// </summary>
public partial class ServerView : UserControl
{
    /// <summary>
    /// 动态集合
    /// </summary>
    public ObservableCollection<ServerItem> ServerItems { get; set; } = new();

    public ServerView()
    {
        InitializeComponent();
    }

    private void Button_SearchServers_Click(object sender, RoutedEventArgs e)
    {
        SearchServers();
    }

    private async void SearchServers()
    {
        ServerItems.Clear();

        var name = TextBox_ServerName.Text.Trim();

        var gameModes = GetGameModesString();
        var gameSlots = GetGameSlotsString();
        var gameRegions = GetGameRegionsString();

        var servers = await GameTools.GetServers(name, gameModes, gameSlots);
        if (servers != null)
        {
            servers.servers = servers.servers.OrderByDescending(s => s.playerAmount).ThenByDescending(s => s.inQue).ToList();

            var index = 0;
            foreach (var item in servers.servers)
            {
                this.Dispatcher.Invoke(DispatcherPriority.Background, () =>
                {
                    ServerItems.Add(new()
                    {
                        Index = ++index,
                        GameId = item.gameId,
                        Guid = item.serverId,
                        Region = item.region,
                        RegionImage = ServerUtil.GetServerRegionImage(item.region),
                        Name = item.prefix,
                        Description = ChsUtil.ToSimplified(item.description),
                        Soldier = item.playerAmount,
                        MaxSoldier = item.maxPlayers,
                        Queue = item.inQue,
                        Spectator = item.inSpectator,
                        MapMode = ChsUtil.ToSimplified(item.mode),
                        MapName = ChsUtil.ToSimplified(item.currentMap),
                        MapImage = ServerUtil.GetServerMapImageSmall(item.url),
                        IsCustom = item.isCustom,
                        IsOfficial = item.official,
                        TickRate = 60,
                    });
                });
            }
        }
    }

    private string GetGameModesString()
    {
        var gameModes = new List<string>();

        if (CheckBox_ZoneControl.IsChecked == true)
            gameModes.Add("ZoneControl");
        if (CheckBox_AirAssault.IsChecked == true)
            gameModes.Add("AirAssault");
        if (CheckBox_TugOfWar.IsChecked == true)
            gameModes.Add("TugOfWar");
        if (CheckBox_Domination.IsChecked == true)
            gameModes.Add("Domination");
        if (CheckBox_Breakthrough.IsChecked == true)
            gameModes.Add("Breakthrough");
        if (CheckBox_Rush.IsChecked == true)
            gameModes.Add("Rush");
        if (CheckBox_TeamDeathMatch.IsChecked == true)
            gameModes.Add("TeamDeathMatch");
        if (CheckBox_BreakthroughLarge.IsChecked == true)
            gameModes.Add("BreakthroughLarge");
        if (CheckBox_Possession.IsChecked == true)
            gameModes.Add("Possession");
        if (CheckBox_Conquest.IsChecked == true)
            gameModes.Add("Conquest");

        return string.Join(",", gameModes);
    }

    private string GetGameSlotsString()
    {
        var gameSlots = new List<string>();

        if (CheckBox_None.IsChecked == true)
            gameSlots.Add("None");
        if (CheckBox_OneToFive.IsChecked == true)
            gameSlots.Add("OneToFive");
        if (CheckBox_SixToTen.IsChecked == true)
            gameSlots.Add("SixToTen");
        if (CheckBox_TenPlus.IsChecked == true)
            gameSlots.Add("TenPlus");
        if (CheckBox_All.IsChecked == true)
            gameSlots.Add("_All");
        if (CheckBox_Spectator.IsChecked == true)
            gameSlots.Add("Spectator");

        return string.Join(",", gameSlots);
    }

    private string GetGameRegionsString()
    {
        var gameRegions = new List<string>();

        if (CheckBox_NAm.IsChecked == true)
            gameRegions.Add("NAm");
        if (CheckBox_SAm.IsChecked == true)
            gameRegions.Add("SAm");
        if (CheckBox_AC.IsChecked == true)
            gameRegions.Add("AC");
        if (CheckBox_Afr.IsChecked == true)
            gameRegions.Add("Afr");
        if (CheckBox_EU.IsChecked == true)
            gameRegions.Add("EU");
        if (CheckBox_Asia.IsChecked == true)
            gameRegions.Add("Asia");
        if (CheckBox_OC.IsChecked == true)
            gameRegions.Add("OC");

        return string.Join(",", gameRegions);
    }
}
