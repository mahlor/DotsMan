using System;
using Unity.Burst;
using Unity.Entities;

namespace Assets.Scripts.Components
{
    [Serializable] 
    [BurstCompile]
    public struct CollisionBuffer : IBufferElementData
    {
        public Entity entity;
    }
}