using System.Text;
using AddoSamples.DomainModel;
using AddoSamples.Extensions;
using AddoSamples.Http;
using Newtonsoft.Json;

namespace AddoSamples.Actions
{
    public class GetSigningDetails
    {
        readonly Context _context;

        public GetSigningDetails(Context context)
        {
            _context = context;
        }

        public AddoSigning Execute(string signingToken)
        {
            var url = $"{_context.BaseUrl}/GetSigning?signingToken={signingToken}&token={_context.Token}";
            var result = new Get().Execute(url).Result;
            var raw = Encoding.UTF8.GetString(result).ConvertDatesFromAddo();
            return JsonConvert.DeserializeObject<AddoSigning>(raw);
        }
    }
}