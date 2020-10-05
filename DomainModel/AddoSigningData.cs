using System.Collections.Generic;

namespace AddoSamples.DomainModel
{
    public class AddoSigningData
    {
        public AddoSigningData()
        {
            Documents = new List<AddoDocument>();
            Recipients = new List<AddoRecipient>();
        }

        public List<AddoDocument> Documents { get; set; }
        public List<AddoRecipient> Recipients { get; set; }
    }
}