using Unity.Burst;
using Unity.Entities;
using Unity.Collections;

namespace Assets.Scripts.Components
{
    [BurstCompile]
    public struct OnKill : IComponentData
    {
        public FixedString64 sfxName;
        public Entity spawnPrefab;
        public int pointValue;

    }
}