namespace AddoSamples.DomainModel
{
    public class AddoFeedbackForm
    {
        public string Name { get; set; }
        public byte[] Data { get; set; }
        public string MimeType { get; set; }
        public string AdditionalData { get; set; }
    }
}