using System.Collections.Generic;
using Assets.Scripts.Components;
using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts.Authoring
{
    [DisallowMultipleComponent]
    [RequiresEntityConversion]
    public class SpawnerAuthoring : MonoBehaviour, IConvertGameObjectToEntity, IDeclareReferencedPrefabs
    {
        public GameObject spawnObject;

        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentData(entity,
                new Spawner {spawnPrefab = conversionSystem.GetPrimaryEntity(spawnObject)});
        }

        public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
        {
            referencedPrefabs.Add(spawnObject);
        }
    }
}