using Godot;

public partial class HUD : CanvasLayer
{
    [Signal]
    public delegate void ResumeEventHandler();

    [Signal]
    public delegate void QuitEventHandler();

    private Button ResumeButton;
    private Button QuitButton;
    private Label CounterLabel;
    private int Counter = 0;

    public override void _Ready()
    {
        CounterLabel = GetNode<Label>("Panel/CounterLabel");
        ResumeButton = GetNode<Button>("Panel/Resume");
        QuitButton = GetNode<Button>("Panel/Quit");
    }

    public async void PlayCountdown()
    {
        Tween tween = GetTree().CreateTween();
        tween.SetPauseMode(Tween.TweenPauseMode.Process);
        CounterLabel.Visible = true;
        //tween.TweenProperty(CounterLabel, "scale", Vector2.Zero, 1.0f);
        tween.TweenMethod(Callable.From<int>(UpdateCounterValue), 4.0f, 1.0f, 3.0f);
    }

    public void HideButtons()
    {
        ResumeButton.Visible = false;
        QuitButton.Visible = false;
    }

    public void ShowButtons()
    {
        ResumeButton.Visible = true;
        QuitButton.Visible = true;
    }

    public void ResumeButtonPressed()
    {
        EmitSignal(SignalName.Resume);
    }

    public void QuitButtonPressed()
    {
        EmitSignal(SignalName.Quit);
    }

    private void UpdateCounterValue(int counter)
    {
        CounterLabel.Text = $"{counter}";
    }
}
