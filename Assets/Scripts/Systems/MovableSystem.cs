using Assets.Scripts.Components;
using Unity.Entities;
using Unity.Physics;
using UnityEditor;

namespace Assets.Scripts.Systems
{
    public class MovableSystem : SystemBase
    {
       
        protected override void OnUpdate()
        {
            Entities.ForEach((ref PhysicsVelocity physVel, in Movable mov) =>
            {
                var step = mov.direction * mov.speed;
                physVel.Linear = step;

            }).Schedule();
        }
    }
}
