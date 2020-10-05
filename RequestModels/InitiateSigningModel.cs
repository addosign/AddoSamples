using System;
using AddoSamples.DomainModel;
using AddoSamples.Extensions;

namespace AddoSamples.RequestModels
{
    public class InitiateSigningModel
    {
        public InitiateSigningModel(Guid templateId, AddoSigningData signingData)
        {
            SigningTemplateId = templateId;
            SigningData = signingData;
            StartDate = DateTime.Now.AddoDate();
        }

        public string Name { get { return "Addo Sample Test"; } }
        public Guid SigningTemplateId { get; set; }
        public string StartDate { get; set; }
        public AddoSigningData SigningData { get; set; }
    }
}