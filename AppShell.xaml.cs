namespace MauiNet11Preview3Sample;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
	}

	public void SetPreview4Badge(string? badgeText)
	{
		Preview4Tab.BadgeText = badgeText;
		Preview4ShellContent.BadgeText = badgeText;
	}
}
