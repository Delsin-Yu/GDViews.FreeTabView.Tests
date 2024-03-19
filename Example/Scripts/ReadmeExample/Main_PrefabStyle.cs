namespace GodotViews.Example.ReadmeExample.ReferenceStyle;

using Godot;

/// <summary>
/// Attached to a node in scene tree.
/// </summary>
public partial class Main_PrefabStyle : Node
{
    // Assigned in Godot Editor, through inspector.
    [Export] private PackedScene _viewItem1;
    [Export] private PackedScene _viewItem2;

    [Export] private CheckButton _tab1;
    [Export] private CheckButton _tab2;

    // Required for storing the instances.
    [Export] private Control _container;

    private FreeTabView _tabView;

    public override void _Ready()
    {
        // Construct a tab view on ready.
        _tabView = FreeTabView.CreateFromPrefab(
            [
                // Associate a tab to its corresponding view item instance.
                new TabPrefabSetup(_tab1, _viewItem1), 
                new TabPrefabSetup(_tab2, _viewItem2), 
            ],
            _container
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