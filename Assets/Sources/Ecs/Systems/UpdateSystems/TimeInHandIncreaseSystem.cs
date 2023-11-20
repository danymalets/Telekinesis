using Scellecs.Morpeh;
using Sources.Ecs.Components;
using Sources.Utils.MorpehEcsUtils;
using UnityEngine;

namespace Sources.Ecs.Systems.UpdateSystems
{
    public class TimeInHandIncreaseSystem : ISystem
    {
        private Filter _filter;
        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter
                .With<ObjectInHand>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                ref ObjectInHand objectInHand = ref entity.GetComponent<ObjectInHand>();
                objectInHand.Time += deltaTime;
            }
        }

        public void Dispose()
        {
        }
    }
}