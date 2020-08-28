using Unity.Entities;

namespace Assets.Scripts.Components
{
    [GenerateAuthoringComponent]
    public struct PowerPill : IComponentData
    {
        public float pillTimer;
    }

}
