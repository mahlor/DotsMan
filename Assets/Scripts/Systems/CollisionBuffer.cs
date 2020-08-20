using Unity.Entities;
using UnityEngine;

[GenerateAuthoringComponent]
public struct CollisionBuffer : IBufferElementData
{
    public Entity entity;
}

