using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CookieCore.Services;
using CookieCore.Services.Abstractions;
using CookieCore.Services.Extensions;
using Newtonsoft.Json;

namespace CookieCore.ViewModels;

/// <summary>
///     Represents an orchestrator viewmodel for the <see cref="GameViewModel" />
/// </summary>
public partial class MainViewModel : ObservableObject
{
    private readonly IFilesService _filesService;
    private readonly ITimer _timer;

    private static readonly TimeSpan Tickrate = TimeSpan.FromMilliseconds(1000 / 60);

    public GameViewModel GameViewModel { get; private set; }

    public MainViewModel(ITimersService timersService, IFilesService filesService)
    {
        _filesService = filesService;

        _timer = timersService.Create(Tickrate, () => { GameViewModel?.Tick(Tickrate.TotalMilliseconds / 1000); });

        // load default save
        LoadFromJson(JsonConvert.SerializeObject(Game.Default));
    }

    [RelayCommand]
    private async Task Save()
    {
        var file = await _filesService.TryPickSaveFileAsync("save.json", ("Save file", new[] { "json" }));
        if (file != null)
        {
            await using var stream = await file.OpenStreamForWriteAsync();

            var json = JsonConvert.SerializeObject(GameViewModel.Game);

            stream.Write(Encoding.Default.GetBytes(json));
        }
    }

    [RelayCommand]
    private async Task Load()
    {
        var file = await _filesService.TryPickOpenFileAsync(new[] { "json" });
        if (file != null)
        {
            var bytes = await file.ReadAllBytes();
            LoadFromJson(Encoding.Default.GetString(bytes));
        }
    }

    private void LoadFromJson(string json)
    {
        // we pause the timer during game vm instance mutation to avoid issues if timer
        // is invoking on another thread

        _timer.IsRunning = false;

        GameViewModel = new GameViewModel(JsonConvert.DeserializeObject<Game>(json));
        OnPropertyChanged(nameof(GameViewModel));

        _timer.IsRunning = true;
    }
}