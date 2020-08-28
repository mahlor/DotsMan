using Unity.Entities;

namespace Assets.Scripts.Components
{
    [GenerateAuthoringComponent]
    public struct Collectible : IComponentData
    {
        public float points;

    }
}
