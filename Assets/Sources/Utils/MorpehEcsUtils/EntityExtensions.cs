using Scellecs.Morpeh;
using UnityEngine;

namespace Sources.Utils.MorpehEcsUtils
{
    public static class EntityExtensions
    {
        public static T GetComponentReference<T>(this Entity entity)
            where T : Component
        {
            return entity.GetComponent<ComponentReference<T>>().Reference;
        }
    }
}