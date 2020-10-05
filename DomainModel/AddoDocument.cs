namespace AddoSamples.DomainModel
{
    public class AddoDocument
    {
        public AddoDocument() { }

        public AddoDocument(byte[] documentData, string filename)
        {
            Data = documentData;
            Name = filename;
        }

        public byte[] Data { get; set; }
        public string MimeType { get { return "PDF"; } }
        public string Name { get; set; }
    }
}