using Unity.Burst;
using Unity.Entities;

namespace Assets.Scripts.Components
{
    [GenerateAuthoringComponent]
    [BurstCompile]
    public struct Collectible : IComponentData
    {
        public int points;
    }
}