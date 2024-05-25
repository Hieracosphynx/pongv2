using Godot;
using System;

public partial class HorizontalPaddle : CharacterBody2D
{
    public float Speed = 500.00f;
    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Vector2.Zero;

        if(Input.IsActionPressed("move_right")) { velocity.X += Speed; }
        if(Input.IsActionPressed("move_left")) { velocity.X -= Speed; }

        MoveAndCollide(velocity * (float)delta);
    }
}
