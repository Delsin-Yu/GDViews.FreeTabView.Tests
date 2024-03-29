using Godot;
using GodotViews.ViewTweeners;

namespace GodotViews.Example;

/// <summary>
/// Attach this script to a <see cref="Control"/> to make it a ViewItem.
/// </summary>
public partial class View1 : FreeTabViewItem
{
    [Export] private Label _text;

    protected override void _OnViewItemInitialize() => ViewItemTweener = new FadeViewItemTweener();

    public override void _Process(double delta)
    {
        base._Process(delta);
        _text.Text = Time.GetTimeStringFromSystem();
    }
}