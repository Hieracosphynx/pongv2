using Godot;
using System;

/**
* Create a simple circle.
**/
public partial class CircleShape : Node2D
{
    public Vector2 NewPosition;
    public int Radius;
    public Color CircleColor;

    public override void _Ready()
    {
        NewPosition = Vector2.Zero;
        Radius = 0;
        CircleColor = Colors.White;
    }

    public override void _Draw()
    {
        DrawCircle(NewPosition, Radius, CircleColor);
    }
}
