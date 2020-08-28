using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

namespace Assets.Scripts.Components
{
    [GenerateAuthoringComponent]
    [BurstCompile]
    public struct Follow : IComponentData
    {
        public Entity target;
        public float distance, speedMove, speedRotation;
        public float3 offset;
        public bool freezeXPos, freezeYPos, freezeZPos, freezeRot;
    }
}