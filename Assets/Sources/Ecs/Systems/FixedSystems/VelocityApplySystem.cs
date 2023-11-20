using Scellecs.Morpeh;
using Sources.Ecs.Components;
using Sources.Utils.MorpehEcsUtils;
using UnityEngine;

namespace Sources.Ecs.Systems.FixedSystems
{
    public class VelocityApplySystem : IFixedSystem
    {
        private Filter _filter;
        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter
                .With<Speed>()
                .WithMonoReference<Rigidbody>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                Speed speed = entity.GetComponent<Speed>();
                Rigidbody rigidbody = entity.GetComponentReference<Rigidbody>();

                rigidbody.velocity = rigidbody.rotation * Vector3.forward * speed.Value;
            }
        }

        public void Dispose()
        {
        }
    }
}