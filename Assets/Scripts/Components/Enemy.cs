﻿using Unity.Entities;
using Unity.Mathematics;

namespace Assets.Scripts.Components
{
    [GenerateAuthoringComponent]
    public struct Enemy : IComponentData
    {
        public float3 previousCell;

    }
}
