using Battlefield1.Utils;
using Battlefield1.Helpers;

namespace Battlefield1.Views;

/// <summary>
/// HomeView.xaml 的交互逻辑
/// </summary>
public partial class HomeView : UserControl
{
    public HomeView()
    {
        InitializeComponent();

        TextBlock_WelcomeMsg.Text = $"{Dns.GetHostName()}，快樂{MiscUtil.GetWeekName()}。新的每週勛章在等著您。";
    }

    private void Button_VisitGitHub_Click(object sender, RoutedEventArgs e)
    {
        ProcessHelper.OpenLink("https://github.com/CrazyZhang666/Battlefield1");
    }
}
