using System;
using Unity.Entities;

namespace Assets.Scripts.Components
{
    [Serializable]
    public struct CollisionBuffer : IBufferElementData
    {
        public Entity entity;
    }
}
