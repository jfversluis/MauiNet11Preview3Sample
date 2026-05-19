# .NET MAUI 11 Preview Samples

Sample app that separates the new [.NET MAUI 11 Preview 4](https://github.com/dotnet/core/blob/main/release-notes/11.0/preview/preview4/dotnetmaui.md) additions from the [.NET MAUI 11 Preview 3](https://github.com/dotnet/core/blob/main/release-notes/11.0/preview/preview3/dotnetmaui.md) samples that are still included for comparison.

For the previous walkthrough, check out the video: **[What's New in .NET MAUI 11 Preview 3](https://youtu.be/nfJS1R27b_c)**

## Features

### Preview 4 additions
- **Shell and ToolbarItem badges** — `BadgeText`, `BadgeColor`, and `BadgeTextColor` on Shell tabs and primary toolbar items
- **CoreCLR runtime default** — Preview 4 uses CoreCLR by default for .NET MAUI targets
- **Material 3 Android controls** — sample `ImageButton`, `DatePicker`, `Entry`, and `Slider` controls that pick up the expanded Material 3 handlers on Android
- **`x:Code` directive** — inline C# event handler declared directly in XAML
- **Compiled bindings in `DataTemplate`s** — strongly typed `CollectionView` template with `x:DataType`
- **`dotnet watch` for Android and iOS** — project settings include the iOS simulator `MtouchLink=None` workaround from the Preview 4 release notes
- **Android themed icons** — `MauiIcon` now declares a dedicated `MonochromeFile` layer

### Preview 3 samples

#### Maps
- **Pin clustering** — group nearby pins automatically with `IsClusteringEnabled` and `ClusteringIdentifier`
- **Custom pin icons** — use any image as a pin marker via `Pin.ImageSource`
- **Long press to drop pins** — `MapLongClicked` event for adding pins interactively
- **Overlay click events** — `CircleClicked` and `PolygonClicked` on map elements
- **Overlay visibility** — toggle overlays with `MapElement.IsVisible`

#### LongPressGestureRecognizer
- **Built-in long press** — first-party `LongPressGestureRecognizer` with configurable `MinimumPressDuration`
- **State tracking** — `LongPressing` event with `GestureStatus` for real-time feedback
- **Position tracking** — `GetPosition()` to get touch coordinates relative to any element

#### XAML Improvements
- **Implicit namespaces** — no more `xmlns=` boilerplate; standard MAUI and `x:` namespaces are implicit in .NET 11
- **Source generation by default** — XAML source gen is now on for all pages with lazy resource loading
- **New style APIs** — `InvalidateStyle()` and `VisualStateManager.InvalidateVisualStates()` for runtime style mutations

## Prerequisites

- [.NET 11 Preview 4 SDK](https://dotnet.microsoft.com/download/dotnet/11.0)
- .NET MAUI workload: `dotnet workload install maui`
- Xcode 26.4+ (iOS/macOS)

## Getting Started

```bash
git clone https://github.com/jfversluis/MauiNet11Preview3Sample.git
cd MauiNet11Preview3Sample

# iOS
dotnet build -f net11.0-ios
dotnet build -t:Run -f net11.0-ios

# Android
dotnet build -f net11.0-android
dotnet build -t:Run -f net11.0-android

# Hot Reload with Preview 4 dotnet watch
dotnet watch -f net11.0-android
dotnet watch -f net11.0-ios
```

## Screenshots

| Preview 4 additions | Preview 3 Maps | Preview 3 Long Press | Preview 3 XAML |
|---------------------|----------------|----------------------|----------------|
| Badges, x:Code, Material 3, compiled DataTemplates | Pin clustering, custom icons, overlays | Configurable duration, position tracking | Implicit namespaces, source gen |

## License

This project is licensed under the MIT License.
