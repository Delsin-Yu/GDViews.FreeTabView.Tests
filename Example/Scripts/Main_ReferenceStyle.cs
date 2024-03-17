using System;
using Godot;

namespace GodotViews.Example;

public partial class Main_ReferenceStyle : Node
{
    [Export] private CheckButton _tab0;
    [Export] private CheckButton _tab1;
    [Export] private CheckButton _tab2;

    [Export] private View0 _view0;
    [Export] private View1 _view1;
    [Export] private View2 _view2;

    private FreeTabView _freeTabView;

    public override void _Ready()
    {
        _freeTabView = FreeTabView.CreateFromInstance(
            [
                new(_tab0, _view0),
                new(_tab1, _view1),
                new(_tab2, _view2),
            ],
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

    private bool _pressed;
    
    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("primary_switch_left")) _freeTabView.ShowPrevious();
        if (Input.IsActionJustPressed("primary_switch_right")) _freeTabView.ShowNext();
    }
}