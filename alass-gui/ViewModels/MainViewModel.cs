using CommunityToolkit.Mvvm.ComponentModel;

namespace alass_gui.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] public partial string Greeting { get; set; } = "Welcome to Avalonia!";
}