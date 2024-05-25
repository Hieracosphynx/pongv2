using Godot;
using System;

public partial class Player : CharacterBody2D
{
    public float Speed = 500.00f;

    public Vector2 ScreenSize;

    public override void _Ready()
    {
        ScreenSize = GetViewportRect().Size;
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Vector2.Zero;

        if(Input.IsActionPressed("move_down"))
        {
            velocity.Y += Speed;
        }
        if(Input.IsActionPressed("move_up"))
        {
            velocity.Y -= Speed;
        }

        Position += velocity * (float)delta;
		Position = new Vector2(
			x: Mathf.Clamp(Position.X, 0, ScreenSize.X),
			y: Mathf.Clamp(Position.Y, 0, ScreenSize.Y)
		);
    }
}
