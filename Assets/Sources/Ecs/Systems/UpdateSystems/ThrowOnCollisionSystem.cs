using Scellecs.Morpeh;
using Sources.Ecs.Components;

namespace Sources.Ecs.Systems.UpdateSystems
{
    public class ThrowOnCollisionSystem : ISystem
    {
        private Filter _filter;
        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter
                .With<ObjectInHand>()
                .With<ObjectConnected>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                ObjectInHand objectInHand = entity.GetComponent<ObjectInHand>();

                Entity pickable = objectInHand.Pickable;

                if (pickable.Has<CollisionEvent>())
                {
                    entity.SetComponent(new ThrowRequest
                    {
                        VelocityChangeForce = 0
                    });
                }
            }
        }

        public void Dispose()
        {
        }
    }
}