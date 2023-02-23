<p align="center">
  <img width="128" align="center" src="https://user-images.githubusercontent.com/48759429/219958220-1aa18bef-10cc-47ae-98b5-85145cd2beb9.png">
</p>

<h1 align="center">
  CookieCore
</h1>
<p align="center">
    .NET class library for simulation of Orteil's Cookie Clicker
</p>
<p align="center">
<img src="https://img.shields.io/badge/.NET-7-blue?style=for-the-badge"/>
</p>

## :rocket: Getting Started
Create a new project with your desired GUI framework or game engine.

Build the `CookieCore` solution, and add a reference to the `CookieCore.Services`, `CookieCore.ViewModels`, and `CookieCore.Models` assembly.

On startup, create a new instance of the `MainViewModel` class.

```cs
MainViewModel = new(timersService: new(), filesService: new(), ticksPerSecond: 60);
```
> :warning: Implementing `ITimersService` and `IFilesService` is required

#### :one: XAML Binding
You can effortlessly bind to properties under the `MainViewModel`
```xml
<TextBlock Text="{Binding MainViewModel.GameViewModel.Cookies}"/>
<Button Command="{Binding MainViewModel.GameViewModel.ClickCookieCommand}"/>
```

#### :two: Manual Subscriptions

Subscribe to the `PropertyChanged` event on any class you want, then update your view accordingly
```cs
MainViewModel.GameViewModel.PropertyChanged += delegate(object? sender, PropertyChangedEventArgs args)
{
    if (args.PropertyName == nameof(GameViewModel.Cookies))
    {
        // Update UI here...
    }
};
```
> :warning: Proper handling of changes in MainViewModel is required (binding cascade)  
