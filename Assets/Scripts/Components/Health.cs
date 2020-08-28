using Unity.Burst;
using Unity.Entities;

namespace Assets.Scripts.Components
{
    [GenerateAuthoringComponent]
    [BurstCompile]
    public struct Health : IComponentData
    {
        public float value, invincibleTimer, killTimer;
    }
}