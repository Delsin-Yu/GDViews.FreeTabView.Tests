namespace GodotViews.Example.ReadmeExample.PrefabStyle;

using Godot;

/// <summary>
/// Attached to a node in scene tree.
/// </summary>
public partial class Main_ReferenceStyle : Node
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
            ]
        );
        
        // Make the tab view displays the first view item.
        _tabView.Show(0);
    }

    public override void _Process(double delta)
    {
        // Developer may use their own preferred way to handle switching between tabs.
        if (Input.IsActionJustPressed("ui_left")) _tabView.ShowPrevious();
        if (Input.IsActionJustPressed("ui_right")) _tabView.ShowNext();
    }
}