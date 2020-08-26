using Unity.Entities;

namespace Assets.Scripts.Components
{
    [GenerateAuthoringComponent]
    public struct Health : IComponentData
    {
        public float value, invincibleTimer, killTimer;

    }
}
