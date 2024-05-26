using Godot;
using System;

public partial class CircleObstacleShape : CircleShape 
{
    public override void _Ready()
    {
        Position = new Vector2(500, 500);
        CircleColor = Colors.WebPurple;
        Radius = 30;
    }
}
