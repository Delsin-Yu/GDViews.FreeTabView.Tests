namespace GodotViews.Example.ReadmeExample;

using Godot;
using GodotViews;

/// <summary>
/// Attach this script to a <see cref="Control"/> to make it a ViewItem.
/// </summary>
public partial class MyViewItem : FreeTabViewItem
{
    [Export] private Label _text;

    public override void _Process(double delta)
    {
        base._Process(delta);
        _text.Text = Time.GetTimeStringFromSystem();
    }
}