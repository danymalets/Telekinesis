using Scellecs.Morpeh;
using Sources.Constants;
using Sources.Ecs.Components;
using Sources.Utils.MorpehEcsUtils;
using UnityEngine;

namespace Sources.Ecs.Systems.UpdateSystems
{
    public class AnimatorSpeedApplySystem : ISystem
    {
        private Filter _filter;
        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter
                .With<SmoothSpeed>()
                .WithMonoReference<Animator>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                SmoothSpeed speed = entity.GetComponent<SmoothSpeed>();
                Animator animator = entity.GetComponentReference<Animator>();
                
                animator.SetFloat(AnimatorNames.Speed, speed.Value);
            }
        }

        public void Dispose()
        {
        }
    }
}