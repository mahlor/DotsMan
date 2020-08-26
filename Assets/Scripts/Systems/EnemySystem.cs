using Assets.Scripts.Components;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.Systems;
using Unity.Transforms;

namespace Assets.Scripts.Systems
{
    [UpdateAfter(typeof(EndFramePhysicsSystem))]
    public class EnemySystem : SystemBase
    {
        private Unity.Mathematics.Random rng = new Unity.Mathematics.Random(123u);

        protected override void OnUpdate()
        {

            var raycaster = new MovementRayCast() { pw = World.GetOrCreateSystem<BuildPhysicsWorld>().PhysicsWorld };
            rng.NextInt();
            var rngTemp = rng;

        
            Entities.ForEach((ref Movable mov, ref Enemy enemy, in Translation trans) =>
            {
                if (math.distance(trans.Value, enemy.previousCell) > .9f)
                {
                    enemy.previousCell = math.round(trans.Value);

                    var validDir = new NativeList<float3>(Allocator.Temp);

                    if (!raycaster.CheckRay(trans.Value, new float3(0, 0, -1), mov.direction))
                        validDir.Add(new float3(0, 0, -1));
                    if (!raycaster.CheckRay(trans.Value, new float3(0, 0, 1), mov.direction))
                        validDir.Add(new float3(0, 0, 1));
                    if (!raycaster.CheckRay(trans.Value, new float3(-1, 0, 0), mov.direction))
                        validDir.Add(new float3(-1, 0, 0));
                    if (!raycaster.CheckRay(trans.Value, new float3(1, 0, 0), mov.direction))
                        validDir.Add(new float3(1, 0, 0));

                    mov.direction = validDir[rngTemp.NextInt(validDir.Length)];
                    validDir.Dispose();

                }
            }).Schedule();
        }

        private struct MovementRayCast
        {
            [ReadOnly]public PhysicsWorld pw;

            public bool CheckRay(float3 pos, float3 direction, float3 currentDirection)
            {
                if (direction.Equals(-currentDirection))
                    return true;

                var ray = new RaycastInput()
                {
                    Start = pos,
                    End = pos + (direction * .9f),
                    Filter = new CollisionFilter()
                    {
                        GroupIndex = 0,
                        BelongsTo = 1u << 1,
                        CollidesWith = 1u << 2
                    }
                };
                bool ret = pw.CastRay(ray);
                return pw.CastRay(ray);
            }
        }

    }
}
