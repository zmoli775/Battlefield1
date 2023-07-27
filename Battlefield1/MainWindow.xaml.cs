using Battlefield1.Helpers;

namespace Battlefield1;

/// <summary>
/// MainWindow.xaml 的交互逻辑
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        var resStream = Application.GetResourceStream(new Uri("/Assets/Icons/Cursor.cur", UriKind.Relative));
        Mouse.OverrideCursor = new Cursor(resStream.Stream, true);
    }

    private void Window_Main_Loaded(object sender, RoutedEventArgs e)
    {
        Task.Run(() =>
        {
            ChsHelper.PreHeat();
        });
    }

    private void Window_Main_Closing(object sender, CancelEventArgs e)
    {

    }
}
