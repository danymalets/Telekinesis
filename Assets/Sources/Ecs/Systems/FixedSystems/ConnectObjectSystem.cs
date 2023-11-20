using Scellecs.Morpeh;
using Sources.Constants;
using Sources.Ecs.Components;
using Sources.Utils.MorpehEcsUtils;
using UnityEngine;

namespace Sources.Ecs.Systems.FixedSystems
{
    public class ConnectObjectSystem : IFixedSystem
    {
        private Filter _filter;
        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter
                .With<ObjectInHand>()
                .WithMonoReference<Transform>()
                .WithMonoReference<FixedJoint>()
                .Without<ObjectConnected>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                ObjectInHand objectInHand = entity.GetComponent<ObjectInHand>();
                Transform transform = entity.GetComponentReference<Transform>();
                FixedJoint fixedJoint = entity.GetComponentReference<FixedJoint>();
                Vector3 targetPosition = transform.position + transform.rotation * Balance.PickableRelatedPosition;

                Entity pickable = objectInHand.Pickable;
                Transform pickableTransform = pickable.GetComponentReference<Transform>();
                Rigidbody pickableRigidbody = pickable.GetComponentReference<Rigidbody>();

                if (pickableTransform.position == targetPosition)
                {
                    fixedJoint.connectedBody = pickableRigidbody;
                    entity.AddComponent<ObjectConnected>();
                }
            }
        }

        public void Dispose()
        {
        }
    }
}