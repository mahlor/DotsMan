using Assets.Scripts.Components;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;


namespace Assets.Scripts.Systems
{
    [AlwaysUpdateSystem]
    public class GameStateSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var pelletQuery = GetEntityQuery(ComponentType.ReadOnly<Pellet>());
            Debug.Log(pelletQuery.CalculateEntityCount());

        }
    }
}
