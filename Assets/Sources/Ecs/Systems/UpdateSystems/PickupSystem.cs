using Scellecs.Morpeh;
using Sources.Constants;
using Sources.Ecs.Components;
using Sources.Utils.MorpehEcsUtils;
using UnityEngine;

namespace Sources.Ecs.Systems.UpdateSystems
{
    public class PickupSystem : ISystem
    {
        private Filter _filter;
        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter
                .With<AccessibleObject>()
                .With<PickupRequest>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                Entity pickable = playerEntity.GetComponent<AccessibleObject>().Pickable;

                Rigidbody pickableRigidbody = pickable.GetComponentReference<Rigidbody>();
                pickableRigidbody.mass = Balance.FlyObjectMass;
                pickableRigidbody.useGravity = false;
                
                playerEntity.SetComponent(new ObjectInHand
                {
                    Pickable = pickable,
                    StartPosition = pickableRigidbody.position,
                    Time = 0f,
                });
            }
        }

        public void Dispose()
        {
        }
    }
}