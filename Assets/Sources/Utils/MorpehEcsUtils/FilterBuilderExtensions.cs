using Scellecs.Morpeh;
using UnityEngine;

namespace Sources.Utils.MorpehEcsUtils
{
    public static class FilterBuilderExtensions
    {
        public static FilterBuilder WithMonoReference<T>(this FilterBuilder filter)
            where T : Component
        {
            return filter.With<ComponentReference<T>>();
        }
    }
}