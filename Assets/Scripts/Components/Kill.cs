﻿using Unity.Burst;
using Unity.Entities;

namespace Assets.Scripts.Components
{
    [GenerateAuthoringComponent]
    [BurstCompile]
    public struct Kill : IComponentData
    {
        public float timer;
    }
}