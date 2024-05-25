using Godot;
using System;

/**
* Create a simple circle.
**/
public partial class CircleShape : Node2D
{
    public override void _Draw()
    {
        DrawCircle(Position, 20, Colors.DarkOrange);
    }
}
