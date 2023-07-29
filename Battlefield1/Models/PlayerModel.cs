using CommunityToolkit.Mvvm.ComponentModel;

namespace Battlefield1.Models;

public partial class PlayerModel : ObservableObject
{
    [ObservableProperty]
    private string gameId;
    [ObservableProperty]
    private string guid;
    [ObservableProperty]
    private string countryImage;
    [ObservableProperty]
    private string name;
    [ObservableProperty]
    private string description;
    [ObservableProperty]
    private int soldier;
    [ObservableProperty]
    private int maxSoldier;
    [ObservableProperty]
    private int queue;
    [ObservableProperty]
    private int spectator;
    [ObservableProperty]
    private string mapMode;
    [ObservableProperty]
    private string mapName;
    [ObservableProperty]
    private string mapImage;
    [ObservableProperty]
    private string mapImage2;
    [ObservableProperty]
    private string mapImage3;
    [ObservableProperty]
    private bool isCustom;
    [ObservableProperty]
    private bool isOfficial;
    [ObservableProperty]
    private int tickRate;
    [ObservableProperty]
    private string pingImage;
    [ObservableProperty]
    private int pingNumber;

    [ObservableProperty]
    private string team1Image;
    [ObservableProperty]
    private string team2Image;
}
