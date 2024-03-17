using System;
using Godot;

namespace GodotViews.Example;

public partial class Main_PrefabStyle : Node
{
    [Export] private Control _container;
        
    [Export] private CheckButton _tab0;
    [Export] private CheckButton _tab1;
    [Export] private CheckButton _tab2;

    [Export] private PackedScene _view0;
    [Export] private PackedScene _view1;
    [Export] private PackedScene _view2;

    private FreeTabView _freeTabView;

    public override void _Ready()
    {
        _freeTabView = FreeTabView.CreateFromPrefab(
            [
                new(_tab0, _view0),
                new(_tab1, _view1),
                new(_tab2, _view2),
            ],
            _container,
            control => control switch
            {
                View0 => null,
                View1 => null,
                View2 => "Hello World: ",
                _ => throw new ArgumentOutOfRangeException(nameof(control), control.GetType(), null)
            }
        );
        _freeTabView.Show(2, "Hello World!");
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("primary_switch_left")) _freeTabView.ShowPrevious();
        if (Input.IsActionJustPressed("primary_switch_right")) _freeTabView.ShowNext();
    }
}