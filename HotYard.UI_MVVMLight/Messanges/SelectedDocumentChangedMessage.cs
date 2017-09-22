using HotYard.Core.Models;

namespace HotYard.UI_MVVMLight.Messanges
{
    internal class SelectedDocumentChangedMessage
    {
        public Document Document { get; }

        public SelectedDocumentChangedMessage(Document document) => Document = document;
    }
}
