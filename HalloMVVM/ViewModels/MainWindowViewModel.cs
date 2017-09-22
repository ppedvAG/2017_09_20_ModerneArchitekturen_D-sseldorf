using System.Threading.Tasks;
using System.Windows.Input;

namespace HalloMVVM.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private string _welcomeText = "Hallo MVVM.";
        public string WelcomeText
        {
            get => _welcomeText;
            set
            {
                _welcomeText = value;
                RaisePropertyChanged();
            }
        }

        public ICommand ChangeTextCommand { get; }

        public MainWindowViewModel()
        {
            ChangeTextCommand = new RelayCommand(
                execute: async () => await ChangeText(),
                canExecute: () => WelcomeText.Length < 10);
        }

        internal async Task ChangeText()
        {
            await Task.Run(() =>
            {
                System.Threading.Thread.Sleep(1000);
                WelcomeText = "Mein neuer Text aus dem VM";
            });
        }
    }
}
