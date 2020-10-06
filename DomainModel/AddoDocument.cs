namespace AddoSamples.DomainModel
{
    public class AddoDocument
    {
        public AddoDocument() { }

        public AddoDocument(byte[] documentData, string filename)
        {
            Data = documentData;
            Name = filename;
            MimeType = "PDF";
        }

        public byte[] Data { get; set; }
        public string MimeType { get; set; }
        public string Name { get; set; }
    }
}