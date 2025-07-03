using Avalonia.Controls;
using Avalonia.ReactiveUI;
using UserControlTest.ViewModels.ViewModelsFolder;

namespace UserControlTest.AvaloniaApp.Views;

public partial class NoteControl : ReactiveUserControl<NoteViewModel>
{
    public NoteControl()
    {
        InitializeComponent();
    }
}