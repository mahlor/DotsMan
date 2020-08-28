using Unity.Burst;
using Unity.Entities;

namespace Assets.Scripts.Systems
{
    [GenerateAuthoringComponent]
    [BurstCompile]
    public struct TriggerBuffer : IBufferElementData
    {
        public Entity entity;
    }
}