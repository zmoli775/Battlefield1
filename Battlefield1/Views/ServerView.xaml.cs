using Battlefield1.API;
using Battlefield1.API.Response;
using Battlefield1.Data;
using Battlefield1.Utils;
using Battlefield1.Helpers;
using Battlefield1.Windows;

namespace Battlefield1.Views;

/// <summary>
/// ServerView.xaml 的交互逻辑
/// </summary>
public partial class ServerView : UserControl
{
    public ObservableCollection<ServerItem> ServerItems { get; set; } = new();

    public ServerView()
    {
        InitializeComponent();
    }

    private void Button_SearchServers_Click(object sender, RoutedEventArgs e)
    {
        SearchServers();
    }

    private void ListBox_SearchServers_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var index = ListBox_SearchServers.SelectedIndex;
        if (index == -1)
            return;

        var serverItem = ServerItems[index];
        var playerWindow = new PlayerWindow(serverItem);
        playerWindow.Show();

        ListBox_SearchServers.SelectedIndex = -1;
    }

    private async void SearchServers()
    {
        ServerItems.Clear();

        LoadingSpinner_Search.IsLoading = true;
        TextBlock_SearchResult.Visibility = Visibility.Hidden;

        ///////////////////////////////////////////////////

        var name = TextBox_ServerName.Text.Trim();

        var gameModes = GetGameModesString();
        var gameSlots = GetGameSlotsString();
        var gameRegions = GetGameRegionsString();

        var result = await GameTools.GetServers(name, gameRegions, gameModes, gameSlots);
        if (result == null)
        {
            LoadingSpinner_Search.IsLoading = false;
            TextBlock_SearchResult.Visibility = Visibility.Visible;
            TextBlock_SearchResult.Text = "未找到搜索结果或搜索失败，请重试";
            return;
        }

        LoadingSpinner_Search.IsLoading = false;

        ///////////////////////////////////////////////////

        var servers = JsonHelper.JsonDeserialize<Servers>(result);
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
                    RegionImage = ClientUtil.GetServerRegionImage(item.region),
                    Name = item.prefix,
                    Description = ChsHelper.ToSimplified(item.description),
                    Soldier = item.playerAmount,
                    MaxSoldier = item.maxPlayers,
                    Queue = item.inQue,
                    Spectator = item.inSpectator,
                    MapMode = ChsHelper.ToSimplified(item.mode),
                    MapName = ChsHelper.ToSimplified(item.currentMap),
                    MapImage = ClientUtil.GetServerMapImageSmall(item.url),
                    IsCustom = item.isCustom,
                    IsOfficial = item.official,
                    TickRate = 60,

                    Team1Image = ClientUtil.GetServerFactionImage(item.teams.teamOne.key),
                    Team1Key = item.teams.teamOne.key,
                    Team1Name = item.teams.teamOne.name,
                    Team2Image = ClientUtil.GetServerFactionImage(item.teams.teamTwo.key),
                    Team2Key = item.teams.teamTwo.key,
                    Team2Name = item.teams.teamTwo.name
                });
            });
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
