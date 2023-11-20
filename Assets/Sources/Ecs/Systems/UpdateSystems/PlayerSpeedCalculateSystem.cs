using Scellecs.Morpeh;
using Sources.Constants;
using Sources.Ecs.Components;
using UnityEngine;

namespace Sources.Ecs.Systems.UpdateSystems
{
    public class PlayerSpeedCalculateSystem : ISystem
    {
        private Filter _playerFilter;
        public World World { get; set; }

        public void OnAwake()
        {
            _playerFilter = World.Filter
                .With<PlayerTag>()
                .With<Speed>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            float verticalInput = Input.GetAxisRaw("Vertical");

            float speedValue;

            if (Mathf.Approximately(verticalInput, 0))
            {
                speedValue = 0;
            }
            else if (verticalInput < 0)
            {
                speedValue = Balance.PlayerSpeed * -1;
            }
            else
            {
                speedValue = Balance.PlayerSpeed;
            }
            
            foreach (Entity playerEntity in _playerFilter)
            {
                ref Speed speed = ref playerEntity.GetComponent<Speed>();
                speed.Value = speedValue;
            }
        }

        public void Dispose()
        {
        }
    }
}