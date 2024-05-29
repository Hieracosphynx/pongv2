using Godot;
using System;

public partial class SpawnableObstacle : Node2D
{
    private Node2D[] SpawnableObstacles;

    public override void _Ready()
    {
        SpawnableObstacles = new Node2D[] {GetNode<Node2D>("CircleObstacle"), GetNode<Node2D>("DiamondObstacle")};
        GD.Print(SpawnableObstacles);
    }
}
