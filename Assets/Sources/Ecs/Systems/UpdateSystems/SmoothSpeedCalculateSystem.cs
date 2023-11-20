using Scellecs.Morpeh;
using Sources.Constants;
using Sources.Ecs.Components;
using Sources.Utils.MorpehEcsUtils;
using UnityEngine;

namespace Sources.Ecs.Systems.UpdateSystems
{
    public class SmoothSpeedCalculateSystem : ISystem
    {
        private Filter _filter;
        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter
                .With<Speed>()
                .With<SmoothSpeed>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                Speed speed = entity.GetComponent<Speed>();
                ref SmoothSpeed smoothSpeed = ref entity.GetComponent<SmoothSpeed>();

                smoothSpeed.Value = Mathf.MoveTowards(
                    smoothSpeed.Value, speed.Value, deltaTime * Balance.PlayerAcceleration);
            }
        }

        public void Dispose()
        {
        }
    }
}