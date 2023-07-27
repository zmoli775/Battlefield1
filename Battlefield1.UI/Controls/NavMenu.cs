namespace Battlefield1.UI.Controls;

public class NavMenu : Control
{
    /// <summary>
    /// 图像
    /// </summary>
    public string Image
    {
        get { return (string)GetValue(ImageProperty); }
        set { SetValue(ImageProperty, value); }
    }
    public static readonly DependencyProperty ImageProperty =
        DependencyProperty.Register("Image", typeof(string), typeof(NavMenu), new PropertyMetadata(default));

    /// <summary>
    /// 提示文本
    /// </summary>
    public string Hint
    {
        get { return (string)GetValue(HintProperty); }
        set { SetValue(HintProperty, value); }
    }
    public static readonly DependencyProperty HintProperty =
        DependencyProperty.Register("Hint", typeof(string), typeof(NavMenu), new PropertyMetadata(default));

    /// <summary>
    /// 是否选中
    /// </summary>
    public bool IsSelected
    {
        get { return (bool)GetValue(IsSelectedProperty); }
        set { SetValue(IsSelectedProperty, value); }
    }
    public static readonly DependencyProperty IsSelectedProperty =
        DependencyProperty.Register("IsSelected", typeof(bool), typeof(NavMenu), new PropertyMetadata(false));
}
