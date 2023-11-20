using Scellecs.Morpeh;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Utils.MorpehEcsUtils
{
    public struct ComponentReference<T> : IComponent
        where T: Component
    {
        public T Reference;
    }
}