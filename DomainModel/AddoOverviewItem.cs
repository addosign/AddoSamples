using System;

namespace AddoSamples.DomainModel
{
    public class AddoOverviewItem
    {
        public DateTime CreatedOn { get; set; }
        public DateTime ExpiresOn { get; set; }
        public string ReferenceNumber { get; set; }
        public AddoSigningState State { get; set; }
        public string Token { get; set; }
    }
}