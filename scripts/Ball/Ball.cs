using Godot;
using System;

public partial class Ball : RigidBody2D
{
    public override void _Ready()
    {
        LinearVelocity += new Vector2(-550, 0);
    }
}
