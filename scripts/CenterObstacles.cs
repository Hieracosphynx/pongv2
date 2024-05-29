using Godot;
using System;

public partial class CenterObstacles : Node2D
{
    private Tween ExampleTween;
    private StaticBody2D TopLeftCenter;

    public override void _Ready()
    {
        TopLeftCenter = GetNode<StaticBody2D>("TopLeftCenterTriangle");
        ExampleTween = GetTree().CreateTween();
        ExampleTween.TweenProperty(TopLeftCenter, "rotation", Math.PI * 2, 10).AsRelative();
        ExampleTween.SetLoops();
    }
}
