namespace HotYard.Core.Models
{
    public class Document : Entity
    {
        public string Name { get; set; }
        public string FileType { get; set; }
        public string FullName => $"{Name}{FileType}";

        public byte[] Content { get; set; }
    }
}
