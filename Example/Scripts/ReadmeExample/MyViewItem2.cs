namespace GodotViews.Example.ReadmeExample;
using Godot;

/// <summary>
/// Attach this script to a <see cref="Control"/> to make it a ViewItem.
/// </summary>
public partial class MyViewItem2 : FreeTabViewItem
{
    [Export] private Label _text;
    [Export] private Button _pressButton;

    private int _clickCount;
    
    /// <summary>
    /// Called when the <see cref="FreeTabView"/> is initializing the view item.
    /// </summary>
    protected override void _OnViewItemInitialize()
    {
        _pressButton.Pressed += () => _text.Text = $"Clicked: {_clickCount++}";
    }

    /// <summary>
    /// Called when the <see cref="FreeTabView"/> is showing the view item.
    /// </summary>
    protected override void _OnViewShow()
    {
        _text.Text = "Hello World!";
        _pressButton.GrabFocus();
    }
}