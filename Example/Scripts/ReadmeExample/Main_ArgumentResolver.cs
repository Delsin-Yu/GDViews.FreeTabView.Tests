namespace GodotViews.Example.ReadmeExample.PrefabStyle;

using Godot;

/// <summary>
/// Attached to a node in scene tree.
/// </summary>
public partial class Main_ArgumentResolver : Node
{
    // Assigned in Godot Editor, through inspector.
    [Export] private MyViewItem _viewItem1;
    [Export] private MyViewItem2 _viewItem2;

    [Export] private CheckButton _tab1;
    [Export] private CheckButton _tab2;

    private FreeTabView _tabView;

    public override void _Ready()
    {
        // Construct a tab view on ready.
        _tabView = FreeTabView.CreateFromInstance(
            [
                // Associate a tab to its corresponding view item instance.
                new TabInstanceSetup(_tab1, _viewItem1), 
                new TabInstanceSetup(_tab2, _viewItem2), 
            ],
            ArgumentResolver
        );
        
        return;
        
        object? ArgumentResolver(IFreeTabViewItem arg)
        {
            if (arg == _viewItem1) return "Hello World!";
            if (arg == _viewItem2) return 10;
            return null;
        }
    }
}