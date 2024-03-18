using Godot;

namespace GodotViews.Example;

public partial class View1 : FreeTabViewItem
{
    [Export] private Label _text;

    public override void _Process(double delta)
    {
        base._Process(delta);
        _text.Text = Time.GetTimeStringFromSystem();
    }
}