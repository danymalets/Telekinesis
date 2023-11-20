using System;
using Scellecs.Morpeh;

namespace Sources.Utils.MorpehEcsUtils
{
    public class OneFrameCleanupSystem<T> : ISystem
        where T : struct, IComponent
    {
        private Filter _filter;
        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter.With<T>().Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                entity.RemoveComponent<T>();
            }
        }

        public void Dispose()
        {
        }
    }
}