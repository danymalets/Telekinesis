using Scellecs.Morpeh;
using UnityEngine;

namespace Sources.Utils.MorpehEcsUtils
{
    public static class SystemGroupExtensions
    {
        public static void AddOneFrame<T>(this SystemsGroup systemsGroup)
            where T : struct, IComponent
        {
            systemsGroup.AddSystem(new OneFrameCleanupSystem<T>());
        }
        
        public static void AddFixedOneFrame<T>(this SystemsGroup systemsGroup)
            where T : struct, IComponent
        {
            systemsGroup.AddSystem(new FixedOneFrameCleanupSystem<T>());
        }
    }
}