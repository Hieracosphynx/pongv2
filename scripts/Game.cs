using Godot;
using System;

public partial class Game : Node
{
    private HUD HUDNode;
    private Timer ResumeTimer;
    public override void _Ready()
    {
        HUDNode = GetNode<HUD>("HUD");
        ResumeTimer = GetNode<Timer>("ResumeTimer");
    }

    public void OnResumeButtonPressed()
    {
        HUDNode.HideButtons();
        HUDNode.PlayCountdown();
        ResumeTimer.Start();
        // TODO: Counter Animation 
    }

    public void OnResumeTimerTimeout()
    {
        GetTree().Paused = false;

        HUDNode.HideCounterLabel();
        HUDNode.Visible = false;
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
            HUDNode.Visible = true;
            HUDNode.ShowButtons();
        }
    }
}
