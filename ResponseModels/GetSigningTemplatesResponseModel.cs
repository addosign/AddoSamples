using System.Collections.Generic;
using AddoSamples.DomainModel;

namespace AddoSamples.ResponseModels
{
    public class GetSigningTemplatesResponseModel
    {
        public GetSigningTemplatesResponseModel()
        {
            SigningTemplateItems = new List<AddoSigningTemplate>();
        }

        public List<AddoSigningTemplate> SigningTemplateItems { get; set; }
    }
}