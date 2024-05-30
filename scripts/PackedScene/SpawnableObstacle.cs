using Godot;
using System;

public partial class SpawnableObstacle : Node2D
{
    private Node2D[] SpawnableObstacles;
    private Node2D ActiveObstacle;

    public override void _Ready()
    {
        SpawnableObstacles = new Node2D[] {GetNode<Node2D>("CircleObstacle"), GetNode<Node2D>("DiamondObstacle")};

        var randomIndex = GD.Randi() % SpawnableObstacles.Length;
        var randomScale = GD.Randf();

        ActiveObstacle = SpawnableObstacles[randomIndex];

        ActiveObstacle.Visible = true;
        ActiveObstacle.ProcessMode = ProcessModeEnum.Inherit;
        ActiveObstacle.Scale = new Vector2(randomScale, randomScale);
        
    }

    public void OnBodyEntered(Node2D body)
    {
        if(body.GetType() == typeof(Ball))
        {
            QueueFree();
        }
    }
}
