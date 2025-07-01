using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Reactive;

namespace UserControlTest.ViewModels.ViewModelsFolder;

public class NoteViewModel : ReactiveObject
{
    [Reactive] public string Text { get; private set; } = "Новая заметка";
    [Reactive] public string EditableText { get; set; }
    [Reactive] public bool IsEditing { get; private set; }

    // Команды
    public ReactiveCommand<Unit, Unit> StartEditCommand { get; }
    public ReactiveCommand<Unit, Unit> SaveCommand { get; }
    public ReactiveCommand<Unit, Unit> CancelCommand { get; }
    public ReactiveCommand<Unit, Unit> DeleteCommand { get; }

    public NoteViewModel(Action<NoteViewModel> onDelete)
    {
        EditableText = Text;

        // Инициализация команд
        StartEditCommand = ReactiveCommand.Create(StartEdit);
        SaveCommand = ReactiveCommand.Create(Save);
        CancelCommand = ReactiveCommand.Create(Cancel);
        DeleteCommand = ReactiveCommand.Create(() => onDelete?.Invoke(this));
    }

    private void StartEdit()
    {
        EditableText = Text;
        IsEditing = true;
    }

    private void Save()
    {
        Text = EditableText;
        IsEditing = false;
    }

    private void Cancel()
    {
        IsEditing = false;
    }
}