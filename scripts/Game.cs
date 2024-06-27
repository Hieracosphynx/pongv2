using Godot;
using System;

public partial class Game : Node
{
    private CanvasLayer HUD;
    public override void _Ready()
    {
        HUD = GetNode<CanvasLayer>("HUD");
    }

    public void OnResumeButtonPressed()
    {
        GetTree().Paused = false;
        HUD.Visible = false;
    }

    public void OnQuitButtonPressed()
    {
        GetTree().Quit();
    }

    public override void _Process(double delta)
    {
        if(Input.IsActionJustPressed("pause") || Input.IsActionPressed("pause"))
        {
            GetTree().Paused = true;
            HUD.Visible = true;
        }
    }
}
