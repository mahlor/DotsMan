using Unity.Entities;

namespace Assets.Scripts.Components
{

    public struct Spawner : IComponentData
    {
        public Entity spawnPrefab, spawnObject;

    }
}
