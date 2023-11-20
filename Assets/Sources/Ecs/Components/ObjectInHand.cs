using Scellecs.Morpeh;
using UnityEngine;

namespace Sources.Ecs.Components
{
    public struct ObjectInHand : IComponent
    {
        public Entity Pickable;
        public Vector3 StartPosition;
        public float Time;
    }
}