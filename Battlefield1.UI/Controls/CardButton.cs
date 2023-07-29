namespace Battlefield1.UI.Controls;

public class CardButton : Button
{    /// <summary>
     /// 图像
     /// </summary>
    public string Image
    {
        get { return (string)GetValue(ImageProperty); }
        set { SetValue(ImageProperty, value); }
    }
    public static readonly DependencyProperty ImageProperty =
        DependencyProperty.Register("Image", typeof(string), typeof(CardButton), new PropertyMetadata(default));

    /// <summary>
    /// 标题
    /// </summary>
    public string Title
    {
        get { return (string)GetValue(TitleProperty); }
        set { SetValue(TitleProperty, value); }
    }
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register("Title", typeof(string), typeof(CardButton), new PropertyMetadata(default));

    /// <summary>
    /// 描述信息
    /// </summary>
    public string Description
    {
        get { return (string)GetValue(DescriptionProperty); }
        set { SetValue(DescriptionProperty, value); }
    }
    public static readonly DependencyProperty DescriptionProperty =
        DependencyProperty.Register("Description", typeof(string), typeof(CardButton), new PropertyMetadata(default));
}
