using System;

namespace OhioTrackStats.API.ServiceModel.Types
{
    [Flags]
    public enum Gender
    {
        Male = 1 << 0,
        Female = 1 << 1
    }
}