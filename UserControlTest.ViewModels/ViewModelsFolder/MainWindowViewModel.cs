using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;

namespace UserControlTest.ViewModels.ViewModelsFolder;

public class MainWindowViewModel : ReactiveObject
{
    public ObservableCollection<NoteViewModel> Notes { get; } = new();

    public ReactiveCommand<Unit, Unit> AddNoteCommand { get; }

    public MainWindowViewModel()
    {
      
        AddNoteCommand = ReactiveCommand.Create(() =>
        {
            var note = new NoteViewModel(RemoveNote);
            Notes.Add(note);
        });
    }

    private void RemoveNote(NoteViewModel note)
    {
        Notes.Remove(note);
    }
}
