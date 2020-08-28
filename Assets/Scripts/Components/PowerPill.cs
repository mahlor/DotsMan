using Unity.Burst;
using Unity.Entities;

namespace Assets.Scripts.Components
{
    [GenerateAuthoringComponent]
    [BurstCompile]
    public struct PowerPill : IComponentData
    {
        public float pillTimer;
    }
}