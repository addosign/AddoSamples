using System;
using System.Linq;
using System.Text;
using AddoSamples.DomainModel;
using AddoSamples.Http;
using AddoSamples.ResponseModels;
using Newtonsoft.Json;

namespace AddoSamples.Actions
{
    public class GetSigningTemplate
    {
        readonly Context _context;

        public GetSigningTemplate(Context context)
        {
            _context = context;
        }

        public AddoSigningTemplate Execute(string templateName)
        {
            var url = $"{_context.BaseUrl}/GetSigningTemplates?token={_context.Token}";
            var result = new Get().Execute(url).Result;
            var response = JsonConvert.DeserializeObject<GetSigningTemplatesResponseModel>(Encoding.UTF8.GetString(result));
            if (response == null || !response.SigningTemplateItems.Any())
            {
                throw new Exception("No templates defined");
            }

            var template = response.SigningTemplateItems.FirstOrDefault(x => templateName.Equals(x.FriendlyName, StringComparison.CurrentCultureIgnoreCase));
            if (template == null)
            {
                throw new Exception($"Template not found: {templateName}");
            }

            return template;
        }
    }
}