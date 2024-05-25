using Godot;
using System;

public partial class Ball : RigidBody2D
{
    public float Speed = -550.0f;
    public override void _Ready()
    {
        LinearVelocity += new Vector2(GetRandomVelocity(), 0);
    }

    private float GetRandomVelocity()
    {
        var random = new Random();
        var xOffset = random.Next(0,2) * 2 - 1;

        return Speed * xOffset;
    }
}
