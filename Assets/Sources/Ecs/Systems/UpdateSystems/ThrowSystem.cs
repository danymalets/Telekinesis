using Scellecs.Morpeh;
using Sources.Constants;
using Sources.Ecs.Components;
using Sources.Utils.MorpehEcsUtils;
using UnityEngine;

namespace Sources.Ecs.Systems.UpdateSystems
{
    public class ThrowSystem : ISystem
    {
        private Filter _filter;
        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter
                .With<ObjectInHand>()
                .WithMonoReference<Transform>()
                .WithMonoReference<FixedJoint>()
                .With<ThrowRequest>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                ObjectInHand objectInHand = entity.GetComponent<ObjectInHand>();
                ThrowRequest throwRequest = entity.GetComponent<ThrowRequest>();
                EmptyFixedJointTarget emptyFixedJointTarget = entity.GetComponent<EmptyFixedJointTarget>();
                Transform transform = entity.GetComponentReference<Transform>();
                FixedJoint fixedJoint = entity.GetComponentReference<FixedJoint>();
                
                Entity pickable = objectInHand.Pickable;
                Rigidbody pickableRigidbody = pickable.GetComponentReference<Rigidbody>();
                Mass mass = pickable.GetComponent<Mass>();

                if (entity.Has<ObjectConnected>())
                {
                    entity.RemoveComponent<ObjectConnected>();
                }

                entity.RemoveComponent<ObjectInHand>();

                pickableRigidbody.useGravity = true;
                pickableRigidbody.mass = mass.Value;
                emptyFixedJointTarget.Rigidbody.transform.localPosition = Vector3.zero;
                fixedJoint.connectedBody = emptyFixedJointTarget.Rigidbody;
                pickableRigidbody.velocity = transform.forward * throwRequest.VelocityChangeForce;
            }
        }

        public void Dispose()
        {
        }
    }
}