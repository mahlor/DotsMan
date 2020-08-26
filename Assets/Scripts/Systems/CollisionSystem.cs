using Assets.Scripts.Components;
using Unity.Entities;
using Unity.Physics;
using Unity.Physics.Systems;

namespace Assets.Scripts.Systems
{
    public class CollisionSystem : SystemBase
    {

        private struct CollisionSystemsJob : ICollisionEventsJob
        {
            public BufferFromEntity<CollisionBuffer> Collisions;
            public void Execute(CollisionEvent collisionEvent)
            {
                if (Collisions.HasComponent(collisionEvent.EntityA))
                    Collisions[collisionEvent.EntityA].Add(new CollisionBuffer() { entity = collisionEvent.EntityB });
                if (Collisions.HasComponent(collisionEvent.EntityB))
                    Collisions[collisionEvent.EntityB].Add(new CollisionBuffer() { entity = collisionEvent.EntityA });
            }
        }

        private struct TriggerSystemJob : ITriggerEventsJob
        {
            public BufferFromEntity<TriggerBuffer> triggers;

            public void Execute(TriggerEvent triggerEvent)
            {
                if (triggers.HasComponent(triggerEvent.EntityA))
                    triggers[triggerEvent.EntityA].Add(new TriggerBuffer() { entity = triggerEvent.EntityB });
                if (triggers.HasComponent(triggerEvent.EntityB))
                    triggers[triggerEvent.EntityB].Add(new TriggerBuffer() { entity = triggerEvent.EntityA });
            
            }
        }

        protected override void OnUpdate()
        {
            var pw = World.GetOrCreateSystem<BuildPhysicsWorld>().PhysicsWorld;
            var sim = World.GetOrCreateSystem<StepPhysicsWorld>().Simulation;


            Entities.ForEach((DynamicBuffer<CollisionBuffer> collisions) =>  {
                collisions.Clear();
            }).Run();

            var colJobHandle = new CollisionSystemsJob()
                {
                    Collisions = GetBufferFromEntity<CollisionBuffer>()
                }
                .Schedule(sim, ref pw, this.Dependency);
            colJobHandle.Complete();


            Entities.ForEach((DynamicBuffer<TriggerBuffer> triggers) => {
                triggers.Clear();
            }).Run();

            var trigJobHandle = new TriggerSystemJob()
                {
                    triggers = GetBufferFromEntity<TriggerBuffer>()
                }
                .Schedule(sim, ref pw, this.Dependency);

            trigJobHandle.Complete();

        }

    }
}
