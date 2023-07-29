using Battlefield1.Models;

using CommunityToolkit.Mvvm.Input;

namespace Battlefield1;

/// <summary>
/// MainWindow.xaml 的交互逻辑
/// </summary>
public partial class MainWindow : Window
{
    public MainModel MainModel { get; set; } = new();

    public static event Action WindowClosingEvent;

    private int index = 0;

    public MainWindow()
    {
        InitializeComponent();

        var resStream = Application.GetResourceStream(new Uri("/Assets/Icons/Cursor.cur", UriKind.Relative));
        Mouse.OverrideCursor = new Cursor(resStream.Stream, true);
    }

    private void Window_Main_Loaded(object sender, RoutedEventArgs e)
    {
        var random = new Random();
        index = random.Next(0, 4);

        SwitchBackImage();
    }

    private void Window_Main_Closing(object sender, CancelEventArgs e)
    {
        WindowClosingEvent?.Invoke();
    }

    [RelayCommand]
    private void SwitchBackImage()
    {
        if (index >= 4)
            index = 0;

        switch (index++)
        {
            case 0:
                MainModel.BackImage = "/Assets/Images/BGLoop/MP_Beachhead.jpg";
                break;
            case 1:
                MainModel.BackImage = "/Assets/Images/BGLoop/MP_Harbor.jpg";
                break;
            case 2:
                MainModel.BackImage = "/Assets/Images/BGLoop/MP_Naval.jpg";
                break;
            case 3:
                MainModel.BackImage = "/Assets/Images/BGLoop/MP_Ridge.jpg";
                break;
        }
    }
}
