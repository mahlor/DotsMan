using Assets.Scripts.Components;
using Unity.Entities;
using UnityEngine;

namespace Assets.Scripts.Authoring
{
    [DisallowMultipleComponent]
    [RequiresEntityConversion]
    public class CameraAuthoring : MonoBehaviour, IConvertGameObjectToEntity
    {
        public AudioListener audioListener;
        public Camera cam;

        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentData(entity, new CameraTag() {});

            conversionSystem.AddHybridComponent(audioListener);
            conversionSystem.AddHybridComponent(cam);
        }
    }
}
