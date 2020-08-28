using Unity.Transforms;
using Assets.Scripts.Components;
using Assets.Scripts.Monobehaviour;
using Unity.Entities;

namespace Assets.Scripts.Systems
{
    public class DamageSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var dt = Time.DeltaTime;
            Entities.ForEach((DynamicBuffer<CollisionBuffer> col, ref Health hp) =>
            {
                for (var i = 0; i < col.Length; i++)
                    if (hp.invincibleTimer <= 0 && HasComponent<Damage>(col[i].entity))
                    {
                        hp.value -= GetComponent<Damage>(col[i].entity).value;
                        hp.invincibleTimer = 1;
                    }
            }).Schedule();

            Entities.WithNone<Kill>().ForEach((Entity e, ref Health hp) =>
            {
                hp.invincibleTimer -= dt;
                if (hp.value <= 0)
                    EntityManager.AddComponentData(e, new Kill {timer = hp.killTimer});
            }).WithStructuralChanges().Run();

            var ecbSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
            var ecb = ecbSystem.CreateCommandBuffer();

            Entities.ForEach((Entity e, ref Kill kill, in Translation trns, in Rotation rot ) =>
            {
                if (HasComponent<OnKill>(e))
                {
                    var onKill = GetComponent<OnKill>(e);
                    AudioManager.instance.PlaySfxRequest(onKill.sfxName.ToString());
                    GameManager.instance.AddPoints(onKill.pointValue);

                    if (EntityManager.Exists(onKill.spawnPrefab))
                    {
                        var spawnedEntity = ecb.Instantiate(onKill.spawnPrefab);
                        ecb.AddComponent(spawnedEntity, trns);
                        ecb.AddComponent(spawnedEntity, rot);
                    }
                }

                kill.timer -= dt;
                if (kill.timer <= 0)
                   ecb.DestroyEntity(e);

            }).WithoutBurst().Run();


        }
    }
}