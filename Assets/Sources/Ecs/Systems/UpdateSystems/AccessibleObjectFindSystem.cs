using Scellecs.Morpeh;
using Sources.Constants;
using Sources.Ecs.Components;
using Sources.Utils.MorpehEcsUtils;
using UnityEngine;

namespace Sources.Ecs.Systems.UpdateSystems
{
    public class AccessibleObjectFindSystem : ISystem
    {
        private Filter _playerFilter;
        private Filter _pickableFilter;
        public World World { get; set; }

        public void OnAwake()
        {
            _playerFilter = World.Filter
                .With<PlayerTag>()
                .WithMonoReference<Transform>()
                .Build();

            _pickableFilter = World.Filter
                .With<PickableObjectTag>()
                .WithMonoReference<Transform>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            const float maxDistanceToPickUpSqr = Balance.MaxDistanceToPickUp * Balance.MaxDistanceToPickUp;
            
            foreach (Entity playerEntity in _playerFilter)
            {
                Transform transform = playerEntity.GetComponentReference<Transform>();

                Vector3 targetPosition = transform.position + transform.rotation * Balance.PickableRelatedPosition;

                if (playerEntity.Has<AccessibleObject>())
                {
                    playerEntity.RemoveComponent<AccessibleObject>();
                }

                Entity nearestPickable = null;
                float minSqrDistance = Mathf.Infinity;

                foreach (Entity pickableObject in _pickableFilter)
                {
                    Transform pickableTransform = pickableObject.GetComponentReference<Transform>();

                    float sqrDistance = Vector3.SqrMagnitude(pickableTransform.position - targetPosition);

                    if (sqrDistance < maxDistanceToPickUpSqr && sqrDistance < minSqrDistance)
                    {
                        nearestPickable = pickableObject;
                        minSqrDistance = sqrDistance;
                    }
                }

                if (nearestPickable != null)
                {
                    playerEntity.SetComponent(new AccessibleObject
                    {
                        Pickable = nearestPickable
                    });
                }
            }
        }

        public void Dispose()
        {
        }
    }
}