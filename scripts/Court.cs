using Godot;
using System;

public partial class Court : Node2D
{
    [Export]
    public PackedScene SpawnableObstaclesScene { get; set; }
    private Area2D SpawnableArea;
    private CollisionShape2D SpawnableAreaShape;
    private Tween CenterObstaclesTween;
    private Node2D CenterObstacles;

    public override void _Ready()
    {
        CenterObstacles = GetNode<Node2D>("CenterObstacles");
        SpawnableArea = GetNode<Area2D>("SpawnableArea");
        SpawnableAreaShape = SpawnableArea.GetNode<CollisionShape2D>("CollisionShape2D");
    }

    public void OnDummyTimerTimeout()
    {
        Vector2 spawnableAreaPosition = SpawnableAreaShape.Position;
        Vector2 spawnableAreaSize = SpawnableAreaShape.Shape.GetRect().Size;
        Vector2 newPosition = GetRandomPosition(spawnableAreaPosition, spawnableAreaSize);
        SpawnableObstacle spawnableObstacle = SpawnableObstaclesScene.Instantiate<SpawnableObstacle>();

        spawnableObstacle.Position = newPosition; 
        SpawnableArea.AddChild(spawnableObstacle);
    }

    private Vector2 GetRandomPosition(Vector2 relativePosition, Vector2 size)
    {
        float xRandomInteger = GetRandomInteger(size.X, relativePosition.X);
        float yRandomInteger = GetRandomInteger(size.Y, relativePosition.Y);

        static float GetRandomInteger(float size, float vectorPosition)
        {
            float halfSize = size / 2;
            float maxBoundary = halfSize + vectorPosition; 
            float minBoundary = vectorPosition - halfSize;
            float randomInteger = (float)GD.RandRange(minBoundary, maxBoundary);

            return randomInteger;
        }

        return new Vector2(xRandomInteger, yRandomInteger);
    }

    private void HandleCenterObstaclesTween()
    {
        CenterObstaclesTween = GetTree().CreateTween();
        CenterObstaclesTween.TweenProperty(CenterObstacles, "rotation", Math.PI * 2, 50).AsRelative();
        CenterObstaclesTween.SetLoops();
    }
}
