# .NET MAUI 11 Preview 3 Sample App

Sample app showcasing new features in [.NET MAUI 11 Preview 3](https://github.com/dotnet/core/blob/main/release-notes/11.0/preview/preview3/dotnetmaui.md).

For a full walkthrough, check out the video: **[What's New in .NET MAUI 11 Preview 3](https://youtu.be/nfJS1R27b_c)**

## Features

### Maps
- **Pin clustering** — group nearby pins automatically with `IsClusteringEnabled` and `ClusteringIdentifier`
- **Custom pin icons** — use any image as a pin marker via `Pin.ImageSource`
- **Long press to drop pins** — `MapLongClicked` event for adding pins interactively
- **Overlay click events** — `CircleClicked` and `PolygonClicked` on map elements
- **Overlay visibility** — toggle overlays with `MapElement.IsVisible`

### LongPressGestureRecognizer
- **Built-in long press** — first-party `LongPressGestureRecognizer` with configurable `MinimumPressDuration`
- **State tracking** — `LongPressing` event with `GestureStatus` for real-time feedback
- **Position tracking** — `GetPosition()` to get touch coordinates relative to any element

### XAML Improvements
- **Implicit namespaces** — no more `xmlns=` boilerplate; standard MAUI and `x:` namespaces are implicit in .NET 11
- **Source generation by default** — XAML source gen is now on for all pages with lazy resource loading
- **New style APIs** — `InvalidateStyle()` and `VisualStateManager.InvalidateVisualStates()` for runtime style mutations

## Prerequisites

- [.NET 11 Preview 3 SDK](https://dotnet.microsoft.com/download/dotnet/11.0)
- .NET MAUI workload: `dotnet workload install maui`
- Xcode 26.2+ (iOS/macOS)

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
```

## Screenshots

| Maps | Long Press | XAML |
|------|-----------|------|
| Pin clustering, custom icons, overlays | Configurable duration, position tracking | Implicit namespaces, source gen |

## License

This project is licensed under the MIT License.
