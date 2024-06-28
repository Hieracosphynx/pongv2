using Godot;

public partial class HUD : CanvasLayer
{
    [Signal]
    public delegate void ResumeEventHandler();

    [Signal]
    public delegate void QuitEventHandler();

    private Label CounterLabel;

    public override void _Ready()
    {
        CounterLabel = GetNode<Label>("Panel/CounterLabel");
    }

    public async void PlayCountdown()
    {
    }

    public void ResumeButtonPressed()
    {
        EmitSignal(SignalName.Resume);
    }

    public void QuitButtonPressed()
    {
        EmitSignal(SignalName.Quit);
    }
}
