namespace Girand.Runtime.Services.GameSettings
{
    using System;

    [Serializable]
    [Flags]
    public enum BuildType
    {
        Server = 1,
        Client = 1 << 2,
    }
}