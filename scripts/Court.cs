using Godot;
using System;

public partial class Court : Node2D
{
    [Export]
    public PackedScene SpawnableObstacles { get; set; }
    private Tween CenterObstaclesTween;
    private Node2D CenterObstacles;

    public override void _Ready()
    {
        CenterObstacles = GetNode<Node2D>("Obstacles");
        HandleCenterObstaclesTween();
    }

    private void HandleCenterObstaclesTween()
    {
        CenterObstaclesTween = GetTree().CreateTween();
        CenterObstaclesTween.TweenProperty(CenterObstacles, "rotation", Math.PI * 2, 50).AsRelative();
        CenterObstaclesTween.SetLoops();
    }
}
