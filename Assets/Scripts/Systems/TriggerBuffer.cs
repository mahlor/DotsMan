using Unity.Entities;
using UnityEngine;

[GenerateAuthoringComponent]
public struct TriggerBuffer : IBufferElementData
{
    public Entity entity;
}

