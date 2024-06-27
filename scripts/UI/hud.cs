using Godot;
using System;

public partial class hud : CanvasLayer
{
    [Signal]
    public delegate void ResumeEventHandler();

    [Signal]
    public delegate void QuitEventHandler();

    public void ResumeButtonPressed()
    {
        EmitSignal(SignalName.Resume);
    }

    public void QuitButtonPressed()
    {
        EmitSignal(SignalName.Quit);
    }
}
