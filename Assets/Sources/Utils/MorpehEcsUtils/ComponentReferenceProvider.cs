using Scellecs.Morpeh.Providers;
using UnityEngine;

namespace Sources.Utils.MorpehEcsUtils
{
    public class ComponentReferenceProvider<T> : MonoProvider<ComponentReference<T>> 
        where T : Component
    {
        [SerializeField]
        protected T _reference;

        protected override void Initialize()
        {
            GetData().Reference = _reference;
        }
    }
}