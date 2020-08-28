using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

namespace Assets.Scripts.Components
{
    [GenerateAuthoringComponent]
    [BurstCompile]
    public struct Enemy : IComponentData
    {
        public float3 previousCell;
    }
}