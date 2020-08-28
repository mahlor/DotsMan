using System.Collections.Generic;
using Assets.Scripts.Components;
using Assets.Scripts.Systems;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts.Authoring
{
    [DisallowMultipleComponent]
    [RequiresEntityConversion]
    public class OnKillAuthoring : MonoBehaviour, IConvertGameObjectToEntity, IDeclareReferencedPrefabs
    {
        public string sfxName;
        public GameObject spawnPrefab;
        public int pointValue;


        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentData(entity, new OnKill()
            {
                sfxName = new FixedString64(sfxName), 
                pointValue = pointValue,
                spawnPrefab = conversionSystem.GetPrimaryEntity(spawnPrefab)
            });

        }

        public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
        {
            referencedPrefabs.Add(spawnPrefab);
        }
    }
}