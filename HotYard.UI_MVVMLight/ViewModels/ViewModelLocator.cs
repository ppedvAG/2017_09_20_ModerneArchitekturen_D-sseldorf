using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using HotYard.Core.Repositories;
using HotYard.SampleData;
using Microsoft.Practices.ServiceLocation;

namespace HotYard.UI_MVVMLight.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<IDocumentRepository, DocumentRepository>();
            SimpleIoc.Default.Register<IMessenger, Messenger>();

            SimpleIoc.Default.Register<DocumentDetailViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
        }

        public DocumentDetailViewModel DocumentDetail => ServiceLocator.Current.GetInstance<DocumentDetailViewModel>();
        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
    }
}