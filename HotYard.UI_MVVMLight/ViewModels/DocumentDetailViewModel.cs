using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using HotYard.Core.Models;
using HotYard.UI_MVVMLight.Messanges;

namespace HotYard.UI_MVVMLight.ViewModels
{
    public class DocumentDetailViewModel : ViewModelBase
    {
        private Document _selectedDocument;
        public Document SelectedDoucment
        {
            get => _selectedDocument;
            set
            {
                _selectedDocument = value;
                RaisePropertyChanged();
            }
        }

        public DocumentDetailViewModel(IMessenger messenger) => messenger.Register<SelectedDocumentChangedMessage>(this, m => SelectedDoucment = m.Document);
    }
}
