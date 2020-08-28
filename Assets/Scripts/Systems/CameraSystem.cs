using UnityEngine;
using Assets.Scripts.Components;
using Assets.Scripts.Monobehaviour;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

namespace Assets.Scripts.Systems
{
    public class CameraSystem : SystemBase
    {
        protected override void OnUpdate()
        {

            var playerQuery = GetEntityQuery(typeof(Player), typeof(Movable), typeof(Translation));

            if (playerQuery.CalculateEntityCount() == 0)
                return;

            var playerTrans = GetComponent<Translation>(playerQuery.GetSingletonEntity());

            var minDist = float.MaxValue;

            var camQuery = GetEntityQuery(typeof(CameraTag), typeof(Follow));
            var camEntity = camQuery.GetSingletonEntity();
            Debug.Log(camEntity);

            var camFollow = GetComponent<Follow>(camEntity);

            Entities
                .WithAll<CameraPoint>()
                .ForEach((Entity e, in Translation trans) =>
                {
                    var currentDist = math.distance(trans.Value, playerTrans.Value);
                    if (currentDist < minDist)
                    {
                        minDist = currentDist;
                        camFollow.target = e;
                        SetComponent(camEntity, camFollow);

                    }
                }).Run();
        }
    }
}