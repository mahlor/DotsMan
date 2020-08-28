using Assets.Scripts.Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;


namespace Assets.Scripts.Systems
{

    public class SpawnSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((ref Spawner spawner, in Translation trns, in Rotation rot) =>
                    {
                        if (EntityManager.Exists(spawner.spawnObject)) return;
                        spawner.spawnObject = EntityManager.Instantiate(spawner.spawnPrefab);
                        EntityManager.SetComponentData(spawner.spawnObject, trns);
                        EntityManager.SetComponentData(spawner.spawnObject, rot);
                    }).WithStructuralChanges()
                .Run();
        }
    }
}
