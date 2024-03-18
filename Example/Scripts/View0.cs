using Godot;

namespace GodotViews.Example;

public partial class View0 : FreeTabViewItem
{
    [Export] private Control _focus;

    protected override void _OnViewShow() => _focus.GrabFocus();
}