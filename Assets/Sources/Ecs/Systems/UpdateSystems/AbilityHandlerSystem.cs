using Scellecs.Morpeh;
using Sources.Constants;
using Sources.Ecs.Components;
using Sources.Utils.MorpehEcsUtils;
using UnityEngine;

namespace Sources.Ecs.Systems.UpdateSystems
{
    public class AbilityHandlerSystem : ISystem
    {
        private Filter _playerFilter;
        public World World { get; set; }

        public void OnAwake()
        {
            _playerFilter = World.Filter
                .With<PlayerTag>()
                .WithMonoReference<Transform>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                foreach (Entity playerEntity in _playerFilter)
                {
                    if (playerEntity.Has<ObjectInHand>())
                    {
                        playerEntity.SetComponent(new ThrowRequest
                        {
                            VelocityChangeForce = Balance.VelocityChangeThrowForce
                        });
                    }
                    else
                    {
                        playerEntity.AddComponent<PickupRequest>();
                    }
                }
            }
        }

        public void Dispose()
        {
        }
    }
}