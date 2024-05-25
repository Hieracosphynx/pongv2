using Godot;
using System;

public partial class VerticalPaddle : CharacterBody2D
{
    public float Speed = 500.00f;
    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Vector2.Zero;

        if(Input.IsActionPressed("move_down")) { velocity.Y += Speed; }
        if(Input.IsActionPressed("move_up")) { velocity.Y -= Speed; }

        MoveAndCollide(velocity * (float)delta);
    }
}
