using System;

namespace OhioTrackStats.API.ServiceModel.Types
{
    [Flags]
    public enum EventType
    {
        Running = 1 << 0,
        Field = 1 << 1,
        Relay = 1 << 2
    }
}