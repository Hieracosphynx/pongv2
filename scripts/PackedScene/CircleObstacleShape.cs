using Godot;
using System;

public partial class CircleObstacleShape : CircleShape 
{
    public override void _Ready()
    {
        CircleColor = Colors.WebPurple;
        Radius = 50;
    }
}
