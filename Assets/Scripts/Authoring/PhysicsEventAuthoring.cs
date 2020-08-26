using Assets.Scripts.Components;
using Assets.Scripts.Systems;
using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts.Authoring
{
    [DisallowMultipleComponent]
    [RequiresEntityConversion]
    public class PhysicsEventAuthoring : MonoBehaviour, IConvertGameObjectToEntity
    {
        public float hp;


        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddBuffer<CollisionBuffer>(entity);
            dstManager.AddBuffer<TriggerBuffer>(entity);
            dstManager.AddComponentData(entity, new Kill() { timer = 1 });
            dstManager.AddComponentData(entity, new Health() { value = hp });

        }
    }
}
