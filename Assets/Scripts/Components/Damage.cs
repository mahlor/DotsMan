using Unity.Burst;
using Unity.Entities;

namespace Assets.Scripts.Components
{
    [GenerateAuthoringComponent]
    [BurstCompile]
    public struct Damage : IComponentData
    {
        public float value;
    }
}