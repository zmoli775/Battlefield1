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
        MainWindow.WindowClosingEvent += MainWindow_WindowClosingEvent;

        TextBox_ServerName.Text = IniHelper.ReadValue("ServerSearch", "Name");
        TextBox_ServerFilter.Text = IniHelper.ReadValue("ServerSearch", "Filter");

        CheckBox_ZoneControl.IsChecked = IniHelper.ReadValue("GameModes", "ZoneControl").Equals("True", StringComparison.OrdinalIgnoreCase);
        CheckBox_AirAssault.IsChecked = IniHelper.ReadValue("GameModes", "AirAssault").Equals("True", StringComparison.OrdinalIgnoreCase);
        CheckBox_TugOfWar.IsChecked = IniHelper.ReadValue("GameModes", "TugOfWar").Equals("True", StringComparison.OrdinalIgnoreCase);
        CheckBox_Domination.IsChecked = IniHelper.ReadValue("GameModes", "Domination").Equals("True", StringComparison.OrdinalIgnoreCase);
        CheckBox_Breakthrough.IsChecked = IniHelper.ReadValue("GameModes", "Breakthrough").Equals("True", StringComparison.OrdinalIgnoreCase);
        CheckBox_Rush.IsChecked = IniHelper.ReadValue("GameModes", "Rush").Equals("True", StringComparison.OrdinalIgnoreCase);
        CheckBox_TeamDeathMatch.IsChecked = IniHelper.ReadValue("GameModes", "TeamDeathMatch").Equals("True", StringComparison.OrdinalIgnoreCase);
        CheckBox_BreakthroughLarge.IsChecked = IniHelper.ReadValue("GameModes", "BreakthroughLarge").Equals("True", StringComparison.OrdinalIgnoreCase);
        CheckBox_Possession.IsChecked = IniHelper.ReadValue("GameModes", "Possession").Equals("True", StringComparison.OrdinalIgnoreCase);
        CheckBox_Conquest.IsChecked = IniHelper.ReadValue("GameModes", "Conquest").Equals("True", StringComparison.OrdinalIgnoreCase);

        CheckBox_None.IsChecked = IniHelper.ReadValue("GameSlots", "None").Equals("True", StringComparison.OrdinalIgnoreCase);
        CheckBox_OneToFive.IsChecked = IniHelper.ReadValue("GameSlots", "OneToFive").Equals("True", StringComparison.OrdinalIgnoreCase);
        CheckBox_SixToTen.IsChecked = IniHelper.ReadValue("GameSlots", "SixToTen").Equals("True", StringComparison.OrdinalIgnoreCase);
        CheckBox_TenPlus.IsChecked = IniHelper.ReadValue("GameSlots", "TenPlus").Equals("True", StringComparison.OrdinalIgnoreCase);
        CheckBox_All.IsChecked = IniHelper.ReadValue("GameSlots", "All").Equals("True", StringComparison.OrdinalIgnoreCase);
        CheckBox_Spectator.IsChecked = IniHelper.ReadValue("GameSlots", "Spectator").Equals("True", StringComparison.OrdinalIgnoreCase);

        CheckBox_NAm.IsChecked = IniHelper.ReadValue("GameRegions", "NAm").Equals("True", StringComparison.OrdinalIgnoreCase);
        CheckBox_SAm.IsChecked = IniHelper.ReadValue("GameRegions", "SAm").Equals("True", StringComparison.OrdinalIgnoreCase);
        CheckBox_AC.IsChecked = IniHelper.ReadValue("GameRegions", "AC").Equals("True", StringComparison.OrdinalIgnoreCase);
        CheckBox_Afr.IsChecked = IniHelper.ReadValue("GameRegions", "Afr").Equals("True", StringComparison.OrdinalIgnoreCase);
        CheckBox_EU.IsChecked = IniHelper.ReadValue("GameRegions", "EU").Equals("True", StringComparison.OrdinalIgnoreCase);
        CheckBox_Asia.IsChecked = IniHelper.ReadValue("GameRegions", "Asia").Equals("True", StringComparison.OrdinalIgnoreCase);
        CheckBox_OC.IsChecked = IniHelper.ReadValue("GameRegions", "OC").Equals("True", StringComparison.OrdinalIgnoreCase);
    }

    private void MainWindow_WindowClosingEvent()
    {
        IniHelper.WriteValue("ServerSearch", "Name", TextBox_ServerName.Text.Trim());
        IniHelper.WriteValue("ServerSearch", "Filter", TextBox_ServerFilter.Text.Trim());

        IniHelper.WriteValue("GameModes", "ZoneControl", $"{CheckBox_ZoneControl.IsChecked == true}");
        IniHelper.WriteValue("GameModes", "AirAssault", $"{CheckBox_AirAssault.IsChecked == true}");
        IniHelper.WriteValue("GameModes", "TugOfWar", $"{CheckBox_TugOfWar.IsChecked == true}");
        IniHelper.WriteValue("GameModes", "Domination", $"{CheckBox_Domination.IsChecked == true}");
        IniHelper.WriteValue("GameModes", "Breakthrough", $"{CheckBox_Breakthrough.IsChecked == true}");
        IniHelper.WriteValue("GameModes", "Rush", $"{CheckBox_Rush.IsChecked == true}");
        IniHelper.WriteValue("GameModes", "TeamDeathMatch", $"{CheckBox_TeamDeathMatch.IsChecked == true}");
        IniHelper.WriteValue("GameModes", "BreakthroughLarge", $"{CheckBox_BreakthroughLarge.IsChecked == true}");
        IniHelper.WriteValue("GameModes", "Possession", $"{CheckBox_Possession.IsChecked == true}");
        IniHelper.WriteValue("GameModes", "Conquest", $"{CheckBox_Conquest.IsChecked == true}");

        IniHelper.WriteValue("GameSlots", "None", $"{CheckBox_None.IsChecked == true}");
        IniHelper.WriteValue("GameSlots", "OneToFive", $"{CheckBox_OneToFive.IsChecked == true}");
        IniHelper.WriteValue("GameSlots", "SixToTen", $"{CheckBox_SixToTen.IsChecked == true}");
        IniHelper.WriteValue("GameSlots", "TenPlus", $"{CheckBox_TenPlus.IsChecked == true}");
        IniHelper.WriteValue("GameSlots", "All", $"{CheckBox_All.IsChecked == true}");
        IniHelper.WriteValue("GameSlots", "Spectator", $"{CheckBox_Spectator.IsChecked == true}");

        IniHelper.WriteValue("GameRegions", "NAm", $"{CheckBox_NAm.IsChecked == true}");
        IniHelper.WriteValue("GameRegions", "SAm", $"{CheckBox_SAm.IsChecked == true}");
        IniHelper.WriteValue("GameRegions", "AC", $"{CheckBox_AC.IsChecked == true}");
        IniHelper.WriteValue("GameRegions", "Afr", $"{CheckBox_Afr.IsChecked == true}");
        IniHelper.WriteValue("GameRegions", "EU", $"{CheckBox_EU.IsChecked == true}");
        IniHelper.WriteValue("GameRegions", "Asia", $"{CheckBox_Asia.IsChecked == true}");
        IniHelper.WriteValue("GameRegions", "OC", $"{CheckBox_OC.IsChecked == true}");
    }

    private void Button_SearchServers_Click(object sender, RoutedEventArgs e)
    {
        Button_SearchServers.IsEnabled = false;
        SearchServers();
        Button_SearchServers.IsEnabled = true;
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

        var filter = TextBox_ServerFilter.Text.Trim();
        var filterList = new List<string>();
        if (!string.IsNullOrWhiteSpace(filter))
            filterList = filter.Split(',').ToList();

        var index = 0;
        foreach (var item in servers.servers)
        {
            if (filterList.Count != 0 &&
                filterList.Find(key => item.prefix.Contains(key, StringComparison.OrdinalIgnoreCase)) != null)
                continue;

            this.Dispatcher.Invoke(DispatcherPriority.Background, () =>
            {
                ServerItems.Add(new()
                {
                    Index = ++index,
                    GameId = item.gameId,
                    Guid = item.serverId,
                    Country = item.country,
                    CountryImage = ClientUtil.GetServerCountryImage(item.country),
                    Region = item.region,
                    Name = item.prefix,
                    Description = item.description,
                    Soldier = item.playerAmount,
                    MaxSoldier = item.maxPlayers,
                    Queue = item.inQue,
                    Spectator = item.inSpectator,
                    MapMode = item.mode,
                    MapName = item.currentMap,
                    MapImage = ClientUtil.GetServerMapImageSmall(item.url),
                    IsCustom = item.isCustom,
                    IsOfficial = item.official,
                    TickRate = 60,
                    PingImage = ClientUtil.GetServerPingImage(item.country),
                    PingNumber = ClientUtil.GetServerPingNumber(item.country),

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
