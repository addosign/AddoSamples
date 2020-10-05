using System.Text;
using AddoSamples.DomainModel;
using AddoSamples.Http;
using AddoSamples.RequestModels;
using AddoSamples.ResponseModels;
using Newtonsoft.Json;

namespace AddoSamples.Actions
{
    public class CreateSigningRequest
    {
        readonly Context _context;

        public CreateSigningRequest(Context context)
        {
            _context = context;
        }

        public string Execute(AddoSigningTemplate template, AddoSigningData signingData)
        {
            var initiateSigning = new InitiateSigningModel(template.Id, signingData);
            var addoRequest = new AddoRequestModel<InitiateSigningModel>(_context.Token, initiateSigning);
            var url = $"{_context.BaseUrl}/InitiateSigning";
            var body = JsonConvert.SerializeObject(addoRequest);
            var result = new Post().Execute(url, body).Result;
            var response = JsonConvert.DeserializeObject<InitiateSigningResponseModel>(Encoding.UTF8.GetString(result));
            return response.SigningToken;
        }
    }
}