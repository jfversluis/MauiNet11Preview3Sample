using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace MauiNet11Preview3Sample.Pages;

public partial class MapsPage : ContentPage
{
    private readonly Circle _circle;
    private readonly Polygon _polygon;
    private int _longPressPinCount;
    private bool _overlaysVisible = true;

    // Seattle area locations for demo
    private static readonly Location SeattleCenter = new(47.6062, -122.3321);

    private static readonly (string Label, double Lat, double Lon)[] SeattlePins =
    [
        ("Pike Place Market", 47.6097, -122.3425),
        ("Space Needle", 47.6205, -122.3493),
        ("Pioneer Square", 47.6019, -122.3343),
        ("Capitol Hill", 47.6253, -122.3222),
        ("Fremont", 47.6510, -122.3505),
        ("Ballard", 47.6677, -122.3840),
        ("University District", 47.6615, -122.3130),
        ("Chinatown", 47.5982, -122.3267),
        ("South Lake Union", 47.6249, -122.3381),
        ("Queen Anne", 47.6370, -122.3570),
        ("Belltown", 47.6145, -122.3470),
        ("Wallingford", 47.6583, -122.3352),
    ];

    public MapsPage()
    {
        InitializeComponent();

        // Create a circle overlay around Seattle center
        _circle = new Circle
        {
            Center = SeattleCenter,
            Radius = new Distance(800),
            FillColor = Color.FromArgb("#302196F3"),
            StrokeColor = Color.FromArgb("#802196F3"),
            StrokeWidth = 3,
            ZIndex = 1
        };
        _circle.CircleClicked += OnCircleClicked;

        // Create a polygon (a triangle in a nearby area)
        _polygon = new Polygon
        {
            FillColor = Color.FromArgb("#30FF9800"),
            StrokeColor = Color.FromArgb("#80FF9800"),
            StrokeWidth = 3,
            ZIndex = 2
        };
        _polygon.Geopath.Add(new Location(47.640, -122.370));
        _polygon.Geopath.Add(new Location(47.635, -122.355));
        _polygon.Geopath.Add(new Location(47.645, -122.355));
        _polygon.PolygonClicked += OnPolygonClicked;

        DemoMap.MapElements.Add(_circle);
        DemoMap.MapElements.Add(_polygon);

        AddDefaultPins();

        // Center on Seattle
        DemoMap.MoveToRegion(MapSpan.FromCenterAndRadius(SeattleCenter, Distance.FromKilometers(4)));
    }

    // Pins that get a custom icon (dotnet_bot.png)
    private static readonly HashSet<string> CustomIconPins =
    [
        "Space Needle", "Pike Place Market", "Capitol Hill"
    ];

    private void AddDefaultPins()
    {
        DemoMap.Pins.Clear();

        foreach (var (label, lat, lon) in SeattlePins)
        {
            var pin = new Pin
            {
                Label = label,
                Location = new Location(lat, lon),
                ClusteringIdentifier = "seattle-places"
            };

            // Showcase new Pin.ImageSource for custom icons
            if (CustomIconPins.Contains(label))
                pin.ImageSource = ImageSource.FromFile("dotnet_bot.png");

            pin.MarkerClicked += OnPinClicked;
            DemoMap.Pins.Add(pin);
        }
    }

    private void OnMapClicked(object? sender, MapClickedEventArgs e)
    {
        StatusLabel.Text = $"Map tapped at ({e.Location.Latitude:F4}, {e.Location.Longitude:F4})";
    }

    private void OnMapLongClicked(object? sender, MapClickedEventArgs e)
    {
        _longPressPinCount++;
        var pin = new Pin
        {
            Label = $"Dropped Pin #{_longPressPinCount}",
            Location = e.Location,
            ClusteringIdentifier = "user-pins"
        };
        pin.MarkerClicked += OnPinClicked;
        DemoMap.Pins.Add(pin);

        StatusLabel.Text = $"Long press! Dropped pin at ({e.Location.Latitude:F4}, {e.Location.Longitude:F4})";
    }

    private void OnPinClicked(object? sender, PinClickedEventArgs e)
    {
        if (sender is Pin pin)
            StatusLabel.Text = $"Pin tapped: {pin.Label}";
    }

    private void OnCircleClicked(object? sender, EventArgs e)
    {
        StatusLabel.Text = "Circle overlay tapped! (new CircleClicked event)";
        _circle.FillColor = Color.FromArgb("#504CAF50");
        // Reset after a moment
        Dispatcher.DispatchDelayed(TimeSpan.FromSeconds(1), () =>
            _circle.FillColor = Color.FromArgb("#302196F3"));
    }

    private void OnPolygonClicked(object? sender, EventArgs e)
    {
        StatusLabel.Text = "Polygon overlay tapped! (new PolygonClicked event)";
        _polygon.FillColor = Color.FromArgb("#50E91E63");
        Dispatcher.DispatchDelayed(TimeSpan.FromSeconds(1), () =>
            _polygon.FillColor = Color.FromArgb("#30FF9800"));
    }

    private void OnToggleOverlays(object? sender, EventArgs e)
    {
        _overlaysVisible = !_overlaysVisible;
        _circle.IsVisible = _overlaysVisible;
        _polygon.IsVisible = _overlaysVisible;
        ToggleOverlaysButton.Text = _overlaysVisible ? "Toggle Overlays" : "Show Overlays";
        StatusLabel.Text = _overlaysVisible
            ? "Overlays visible (MapElement.IsVisible = true)"
            : "Overlays hidden (MapElement.IsVisible = false)";
    }

    private void OnToggleClustering(object? sender, EventArgs e)
    {
        DemoMap.IsClusteringEnabled = !DemoMap.IsClusteringEnabled;
        ClusterToggle.Text = DemoMap.IsClusteringEnabled ? "Clustering: On" : "Clustering: Off";
        ClusterToggle.BackgroundColor = DemoMap.IsClusteringEnabled
            ? Color.FromArgb("#34C759")
            : Color.FromArgb("#FF3B30");
        StatusLabel.Text = DemoMap.IsClusteringEnabled
            ? "Pin clustering enabled - zoom out to see clusters"
            : "Pin clustering disabled - all pins shown individually";
    }

    private void OnResetPins(object? sender, EventArgs e)
    {
        _longPressPinCount = 0;
        AddDefaultPins();
        DemoMap.MoveToRegion(MapSpan.FromCenterAndRadius(SeattleCenter, Distance.FromKilometers(4)));
        StatusLabel.Text = "Pins reset to default Seattle locations";
    }
}
