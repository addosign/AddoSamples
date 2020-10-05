namespace AddoSamples.RequestModels
{
    public class GetSigningsModel
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string CreatedOnFrom { get; set; }
        public string CreatedOnTo { get; set; }
        public int OrderType { get; set; }
    }
}