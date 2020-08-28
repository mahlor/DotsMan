using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

namespace Assets.Scripts.Components
{
    [GenerateAuthoringComponent]
    [BurstCompile]
    public struct Movable : IComponentData
    {
        public float speed;
        public float3 direction;
    }
}