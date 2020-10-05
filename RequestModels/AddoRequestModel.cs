namespace AddoSamples.RequestModels
{
    public class AddoRequestModel<T>
    {
        public AddoRequestModel(string loginToken, T addoRequest)
        {
            token = loginToken;
            request = addoRequest;
        }

        public string token { get; set; }
        public T request { get; set; }
    }
}