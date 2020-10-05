using System.Collections.Generic;

namespace AddoSamples.DomainModel
{
    public class AddoSigning
    {
        public List<AddoDocument> Documents { get; set; }
        public string Name { get; set; }
        public List<AddoRecipient> Recipients { get; set; }
        public string ReferenceNumber { get; set; }
        public string SigningToken { get; set; }
    }
}
