using Unity.Entities;

namespace Assets.Scripts.Components
{
    [GenerateAuthoringComponent]
    public struct Damage : IComponentData
    {
        public float value;

    }
}
