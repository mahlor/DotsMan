﻿using Unity.Entities;

namespace Assets.Scripts.Components
{
    [GenerateAuthoringComponent]
    public struct Kill : IComponentData
    {
        public float timer;

    }
}
