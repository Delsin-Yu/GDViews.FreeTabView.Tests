using Godot;
using GodotViews.ViewTweeners;

namespace GodotViews.Example;

public partial class View2 : FreeTabViewItemT<string>
{
    [Export] private Label _text;
    [Export] private Button _button;
    
    private string _arg;
    private int _pressCount;

    protected override void _OnViewItemInitialize()
    {
        ViewItemTweener = new FadeViewItemTweener();
        _button.Pressed += () =>
        {
            _pressCount++;
            UpdateText();
        };
    }

    protected override void _OnViewItemShow(string optionalArg)
    {
        _arg = optionalArg;
        UpdateText();
        _button.GrabFocus();
    }

    private void UpdateText() => _text.Text = $"{_arg}:{_pressCount:X}";
}