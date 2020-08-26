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

            Entities
                .WithAll<Player>()
                .ForEach((ref Movable mov) =>
                {
                    mov.direction = new float3(x, 0, y);
                }).Schedule();
        }
    }
}
