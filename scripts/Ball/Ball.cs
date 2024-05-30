using Godot;
using System;

public partial class Ball : RigidBody2D
{
    public float Speed = -850.0f;
    public override void _Ready()
    {
        LinearVelocity += new Vector2(GetRandomVelocity(), 0);
    }

    public void OnBodyEntered(Node body)
    {
        GD.Print(body.GetType());
    }

    private float GetRandomVelocity()
    {
        var random = new Random();
        var xOffset = random.Next(0,2) * 2 - 1;

        return Speed * xOffset;
    }
}
