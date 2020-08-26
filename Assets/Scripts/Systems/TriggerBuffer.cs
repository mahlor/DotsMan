using Unity.Entities;

namespace Assets.Scripts.Systems
{
    [GenerateAuthoringComponent]
    public struct TriggerBuffer : IBufferElementData
    {
        public Entity entity;
    }
}

