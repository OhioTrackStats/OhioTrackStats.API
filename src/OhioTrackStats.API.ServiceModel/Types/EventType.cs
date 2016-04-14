namespace OhioTrackStats.API.ServiceModel.Types
{
    public enum EventType
    {
        Running = 1 << 0,
        Throwing = 1 << 1,
        Relay = 1 << 2
    }
}