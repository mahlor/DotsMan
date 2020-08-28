using Assets.Scripts.Components;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Systems
{
    public class PlayerSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");
            var dt = Time.DeltaTime;

            Entities
                .WithAll<Player>()
                .ForEach((ref Movable mov) => { mov.direction = new float3(x, 0, y); }).Schedule();

            var ecb = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>().CreateCommandBuffer();

            Entities
                .WithAll<Player>()
                .ForEach((Entity e, ref Health hp, ref PowerPill pill, ref Damage dmg) =>
                {
                    dmg.value = 100;
                    pill.pillTimer -= dt;
                    hp.invincibleTimer = pill.pillTimer;
                    if (pill.pillTimer <= 0)
                    {
                        dmg.value = 0;
                        ecb.RemoveComponent<PowerPill>(e);
                    }
                }).WithoutBurst().Run();
        }
    }
}