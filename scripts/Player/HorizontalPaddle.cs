using Godot;
using System;

public partial class HorizontalPaddle : CharacterBody2D
{
    public float Speed = 700.00f;
    private Vector2 ScreenSize;

    public override void _Ready()
    {
        ScreenSize = GetViewportRect().Size;
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Vector2.Zero;

        if(Input.IsActionPressed("move_right")) { velocity.X += Speed; }
        if(Input.IsActionPressed("move_left")) { velocity.X -= Speed; }

        MoveAndCollide(velocity * (float)delta);
    }
}
