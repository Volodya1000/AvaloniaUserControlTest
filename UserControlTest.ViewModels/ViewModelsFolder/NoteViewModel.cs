using ReactiveUI;
using System.Reactive;

namespace UserControlTest.ViewModels.ViewModelsFolder;

public class NoteViewModel : ReactiveObject
{
    private string _text;
    public string Text
    {
        get => _text;
        private set => this.RaiseAndSetIfChanged(ref _text, value);
    }

    private string _editableText;
    public string EditableText
    {
        get => _editableText;
        set => this.RaiseAndSetIfChanged(ref _editableText, value);
    }

    private bool _isEditing;
    public bool IsEditing
    {
        get => _isEditing;
        private set
        {
            this.RaiseAndSetIfChanged(ref _isEditing, value);
            this.RaisePropertyChanged(nameof(IsNotEditing)); // 💡 уведомляем, что IsNotEditing тоже изменился
        }
    }

    public bool IsNotEditing => !IsEditing;

    public ReactiveCommand<Unit, Unit> StartEditCommand { get; }
    public ReactiveCommand<Unit, Unit> SaveCommand { get; }
    public ReactiveCommand<Unit, Unit> CancelCommand { get; }
    public ReactiveCommand<Unit, Unit> DeleteCommand { get; }

    public NoteViewModel(Action<NoteViewModel> onDelete)
    {
        _text = "Новая заметка";
        _editableText = _text;
        _isEditing = false;

        StartEditCommand = ReactiveCommand.Create(() =>
        {
            EditableText = Text;
            IsEditing = true;
        });

        SaveCommand = ReactiveCommand.Create(() =>
        {
            Text = EditableText;
            IsEditing = false;
        });

        CancelCommand = ReactiveCommand.Create(() =>
        {
            EditableText = Text;
            IsEditing = false;
        });

        DeleteCommand = ReactiveCommand.Create(() =>
        {
            onDelete?.Invoke(this);
        });
    }
}
