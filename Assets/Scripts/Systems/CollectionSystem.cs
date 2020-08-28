using Assets.Scripts.Components;
using Assets.Scripts.Monobehaviour;
using Unity.Entities;

namespace Assets.Scripts.Systems
{
    public class CollectionSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var ecb = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>().CreateCommandBuffer();

            Entities
                .WithAll<Player>()
                .ForEach((Entity playerEntity, DynamicBuffer<TriggerBuffer> tBuffer) =>
                {
                    for (var i = 0; i < tBuffer.Length; i++)
                    {
                        var e = tBuffer[i].entity;
                        if (HasComponent<Collectible>(e) && !HasComponent<Kill>(e))
                        {
                            ecb.AddComponent(e, new Kill {timer = 0});
                            GameManager.instance.AddPoints(GetComponent<Collectible>(e).points);
                        }

                        if (HasComponent<PowerPill>(e) && !HasComponent<Kill>(e))
                        {
                            ecb.AddComponent(playerEntity, GetComponent<PowerPill>(e));
                            ecb.AddComponent(e, new Kill {timer = 0});
                        }
                    }
                }).WithoutBurst().Run();
        }
    }
}