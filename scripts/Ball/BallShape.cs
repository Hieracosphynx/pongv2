using Godot;
using System;

public partial class BallShape : CircleShape 
{
    public override void _Ready()
    {
        NewPosition = Position;
        Radius = 20;
        CircleColor = Colors.DarkOrange;
    }
}
