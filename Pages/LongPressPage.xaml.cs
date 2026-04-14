namespace MauiNet11Preview3Sample.Pages;

public partial class LongPressPage : ContentPage
{
    private readonly Color _primaryColor = Color.FromArgb("#512BD4");
    private readonly Color _successColor = Color.FromArgb("#34C759");
    private readonly Color _orangeColor = Color.FromArgb("#FF9800");
    private readonly Color _orangeSuccess = Color.FromArgb("#4CAF50");
    private readonly Color _purpleColor = Color.FromArgb("#9C27B0");
    private readonly Color _purpleActive = Color.FromArgb("#E040FB");

    public LongPressPage()
    {
        InitializeComponent();
    }

    // Basic card handlers
    private void OnBasicLongPressing(object? sender, LongPressingEventArgs e)
    {
        BasicCard.BackgroundColor = _successColor;
        BasicStatusLabel.Text = $"Pressing... State: {e.Status}";
        if (e.Status == GestureStatus.Canceled)
        {
            BasicCard.BackgroundColor = _primaryColor;
            BasicStatusLabel.Text = "Canceled - try again";
        }
    }

    private void OnBasicLongPressed(object? sender, LongPressedEventArgs e)
    {
        var pos = e.GetPosition(BasicCard);
        BasicStatusLabel.Text = $"Long pressed at ({pos?.X:F0}, {pos?.Y:F0})";
        BasicCard.BackgroundColor = _primaryColor;

        BasicCard.Scale = 0.95;
        _ = BasicCard.ScaleToAsync(1.0, 200, Easing.SpringOut);
    }

    // Slow card handlers
    private void OnSlowLongPressing(object? sender, LongPressingEventArgs e)
    {
        SlowCard.BackgroundColor = _orangeSuccess;
        SlowStatusLabel.Text = $"Holding... State: {e.Status}";
        if (e.Status == GestureStatus.Canceled)
        {
            SlowCard.BackgroundColor = _orangeColor;
            SlowStatusLabel.Text = "Released too early! Hold for 1.5 seconds.";
        }
    }

    private void OnSlowLongPressed(object? sender, LongPressedEventArgs e)
    {
        SlowStatusLabel.Text = "1.5 second long press completed!";
        SlowCard.BackgroundColor = _orangeColor;

        SlowCard.Scale = 0.95;
        _ = SlowCard.ScaleToAsync(1.0, 200, Easing.SpringOut);
    }

    // Position tracking card handlers
    private void OnPositionLongPressing(object? sender, LongPressingEventArgs e)
    {
        PositionCard.BackgroundColor = _purpleActive;
        var pos = e.GetPosition(PositionCard);
        PositionLabel.Text = $"Position: ({pos?.X:F1}, {pos?.Y:F1})";
        StateLabel.Text = $"State: {e.Status}";

        if (e.Status == GestureStatus.Canceled)
        {
            PositionCard.BackgroundColor = _purpleColor;
            StateLabel.Text = "State: Canceled";
        }
    }

    private void OnPositionLongPressed(object? sender, LongPressedEventArgs e)
    {
        var pos = e.GetPosition(PositionCard);
        PositionLabel.Text = $"Final position: ({pos?.X:F1}, {pos?.Y:F1})";
        StateLabel.Text = "State: Completed";
        PositionCard.BackgroundColor = _purpleColor;
    }
}
