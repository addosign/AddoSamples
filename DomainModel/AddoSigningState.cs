using System.ComponentModel;

namespace AddoSamples.DomainModel
{
    public enum AddoSigningState
    {
        [Description("ENUM_SIGNING_STATE_FAILED")]
        Failed = -1,
        [Description("ENUM_SIGNING_STATE_INITIATING")]
        Initiating = 0,
        [Description("ENUM_SIGNING_STATE_CREATED")]
        Created = 1,
        [Description("ENUM_SIGNING_STATE_STARTED")]
        Started = 2,
        [Description("ENUM_SIGNING_STATE_COMPLETED")]
        Completed = 3,
        [Description("ENUM_SIGNING_STATE_EXPIRED")]
        Expired = 4,
        [Description("ENUM_SIGNING_STATE_STOPPED")]
        Stopped = 5,
        [Description("ENUM_SIGNING_STATE_CAMPAIGNSTARTED")]
        CampaignStarted = 6,
        [Description("ENUM_SIGNING_STATE_REJECTED")]
        Rejected = 7,
    }
}