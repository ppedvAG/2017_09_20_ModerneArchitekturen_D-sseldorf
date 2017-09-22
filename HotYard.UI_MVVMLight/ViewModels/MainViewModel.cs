using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HotYard.Core.Models;
using HotYard.Core.Repositories;
using HotYard.UI_MVVMLight.Messanges;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HotYard.UI_MVVMLight.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IMessenger _messenger;

        private ObservableCollection<Document> _documents;
        private Document _selectedDocument;
        private ICommand _initializeCommand;

        public ObservableCollection<Document> Documents
        {
            get => _documents;
            set
            {
                _documents = value;
                RaisePropertyChanged();
            }
        }
        public Document SelectedDocument
        {
            get => _selectedDocument;
            set
            {
                _selectedDocument = value;
                RaisePropertyChanged();

                _messenger.Send(new SelectedDocumentChangedMessage(SelectedDocument));
            }
        }

        public MainViewModel(IDocumentRepository documentRepository, IMessenger messenger)
        {
            _documentRepository = documentRepository;
            _messenger = messenger;
        }

        public ICommand InitializeCommand => _initializeCommand ?? (_initializeCommand = new RelayCommand(
            execute: Initialize,
            canExecute: () => Documents == null));

        internal void Initialize()
        {
            var documents = _documentRepository.GetAll();
            Documents = new ObservableCollection<Document>(documents);
        }
    }
}