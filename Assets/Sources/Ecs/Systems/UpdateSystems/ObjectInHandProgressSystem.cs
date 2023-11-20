using Scellecs.Morpeh;
using Sources.Constants;
using Sources.Ecs.Components;
using Sources.Utils.MorpehEcsUtils;
using UnityEngine;

namespace Sources.Ecs.Systems.UpdateSystems
{
    public class ObjectInHandProgressSystem : IFixedSystem
    {
        private Filter _filter;
        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter
                .WithMonoReference<Transform>()
                .With<ObjectInHand>()
                .Without<ObjectConnected>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                Transform transform = entity.GetComponentReference<Transform>();
                
                Vector3 targetPosition = transform.position + transform.rotation * Balance.PickableRelatedPosition;
                
                ObjectInHand objectInHand = entity.GetComponent<ObjectInHand>();
                Entity pickable = objectInHand.Pickable;

                float progress = Mathf.Clamp01(objectInHand.Time / Balance.ObjectMoveTime);

                Transform pickableTransform = pickable.GetComponentReference<Transform>();

                pickableTransform.position = Vector3.Lerp(objectInHand.StartPosition, targetPosition, progress);
            }
        }

        public void Dispose()
        {
        }
    }
}