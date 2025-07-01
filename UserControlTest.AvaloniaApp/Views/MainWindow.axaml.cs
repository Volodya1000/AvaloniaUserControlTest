using Avalonia.ReactiveUI;
using UserControlTest.ViewModels.ViewModelsFolder;

namespace UserControlTest.AvaloniaApp.Views
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();

            ViewModel = viewModel;
        }
    }
}