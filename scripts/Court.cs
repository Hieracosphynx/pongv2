using Godot;
using System;

public partial class Court : Node2D
{
    [Export]
    public PackedScene SpawnableObstaclesScene { get; set; }
    private Tween CenterObstaclesTween;
    private Node2D CenterObstacles;

    public override void _Ready()
    {
        CenterObstacles = GetNode<Node2D>("CenterObstacles");
        //HandleCenterObstaclesTween();
    }

    public void OnDummyTimerTimeout()
    {
        GD.Print("Timeout");
        SpawnableObstacle spawnableObstacle = SpawnableObstaclesScene.Instantiate<SpawnableObstacle>();
        spawnableObstacle.Position = new Vector2(GD.Randi() % 500, 250); 
        AddChild(spawnableObstacle);
    }

    private void HandleCenterObstaclesTween()
    {
        CenterObstaclesTween = GetTree().CreateTween();
        CenterObstaclesTween.TweenProperty(CenterObstacles, "rotation", Math.PI * 2, 50).AsRelative();
        CenterObstaclesTween.SetLoops();
    }
}
