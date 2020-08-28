using Unity.Burst;
using Unity.Entities;

namespace Assets.Scripts.Components
{
    [BurstCompile]
    public struct Spawner : IComponentData
    {
        public Entity spawnPrefab, spawnObject;
    }
}