using Scellecs.Morpeh;
using Sources.Constants;
using Sources.Ecs.Components;
using Sources.Utils.MorpehEcsUtils;
using UnityEngine;

namespace Sources.Ecs.Systems.FixedSystems
{
    public class PlayerAngularVelocityApplySystem : IFixedSystem
    {
        private Filter _playerFilter;
        public World World { get; set; }

        public void OnAwake()
        {
            _playerFilter = World.Filter
                .With<PlayerTag>()
                .WithMonoReference<Rigidbody>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");

            float angularSpeed = horizontalInput * Balance.PlayerAngularSpeed;
            
            foreach (Entity playerEntity in _playerFilter)
            {
                Rigidbody rigidbody = playerEntity.GetComponentReference<Rigidbody>();

                rigidbody.angularVelocity = angularSpeed * Vector3.up * Mathf.Deg2Rad;
            }
        }

        public void Dispose()
        {
        }
    }
}