using System.Collections.Generic;
using AddoSamples.DomainModel;

namespace AddoSamples.ResponseModels
{
    public class GetSigningsResponseModel
    {
        public List<AddoOverviewItem> Signings { get; set; }
    }
}