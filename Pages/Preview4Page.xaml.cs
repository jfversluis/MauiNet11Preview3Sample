namespace MauiNet11Preview3Sample.Pages;

public partial class Preview4Page : ContentPage
{
    private int _shellBadgeCount = 4;
    private int _toolbarBadgeCount = 3;

    public IReadOnlyList<Preview4Feature> Features { get; } =
    [
        new(
            "BADGE",
            "Shell and ToolbarItem badges",
            "Shell tabs and primary ToolbarItems can display count, text, or dot badges.",
            "Use BadgeText, BadgeColor, and BadgeTextColor on ShellContent, Tab, FlyoutItem, or ToolbarItem.",
            Color.FromArgb("#AD1457")),
        new(
            "CLR",
            "CoreCLR default",
            "MAUI projects targeting .NET 11 Preview 4 use CoreCLR by default across supported MAUI platforms.",
            "No extra code needed; the runtime choice comes from the Preview 4 workload.",
            Color.FromArgb("#512BD4")),
        new(
            "WATCH",
            "dotnet watch for Android and iOS",
            "Android and iOS simulator/device loops can now use dotnet watch plus Hot Reload.",
            "Run dotnet watch -f net11.0-android or net11.0-ios with the Preview 4 SDK.",
            Color.FromArgb("#1565C0")),
        new(
            "ICON",
            "MonochromeFile icons",
            "Android themed icons can use a dedicated monochrome layer instead of tinting the foreground layer.",
            "See the MauiIcon MonochromeFile attribute in the project file.",
            Color.FromArgb("#1B5E20"))
    ];

    public Preview4Page()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private void OnNotificationsToolbarItemClicked(object? sender, EventArgs e)
    {
        _toolbarBadgeCount = Math.Max(0, _toolbarBadgeCount - 1);
        NotificationsToolbarItem.BadgeText = _toolbarBadgeCount == 0 ? null : _toolbarBadgeCount.ToString();
        BadgeStatusLabel.Text = _toolbarBadgeCount == 0
            ? "ToolbarItem badge cleared by tapping Alerts."
            : $"ToolbarItem badge decremented to {_toolbarBadgeCount}.";
    }

    private void OnIncrementBadgesClicked(object? sender, EventArgs e)
    {
        _shellBadgeCount++;
        _toolbarBadgeCount++;

        SetShellBadge(_shellBadgeCount.ToString());
        NotificationsToolbarItem.BadgeText = _toolbarBadgeCount.ToString();
        BadgeStatusLabel.Text = $"Shell tab badge = {_shellBadgeCount}, toolbar badge = {_toolbarBadgeCount}";
    }

    private void OnShowDotBadgesClicked(object? sender, EventArgs e)
    {
        SetShellBadge(string.Empty);
        NotificationsToolbarItem.BadgeText = string.Empty;
        BadgeStatusLabel.Text = "BadgeText = empty string shows dot indicators.";
    }

    private void OnClearBadgesClicked(object? sender, EventArgs e)
    {
        SetShellBadge(null);
        NotificationsToolbarItem.BadgeText = null;
        BadgeStatusLabel.Text = "BadgeText = null clears badges.";
    }

    private static void SetShellBadge(string? badgeText)
    {
        if (Shell.Current is AppShell appShell)
            appShell.SetPreview4Badge(badgeText);
    }
}

public sealed record Preview4Feature(
    string Badge,
    string Title,
    string Description,
    string SampleHint,
    Color BadgeColor);
