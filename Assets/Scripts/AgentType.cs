namespace Scenes.Scripts
{
    using System;

    [Flags]
    public enum AgentType
    {
        Wolf = 1 << 0,
        Rabbit = 1 << 1,
        Deer = 1 << 2,
        Hunter = 1 << 3,
    }
}