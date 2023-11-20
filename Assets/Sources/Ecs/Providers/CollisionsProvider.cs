using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using Sources.Ecs.Components;
using UnityEngine;

namespace Sources.Ecs.Providers
{
    public class CollisionsProvider : MonoProvider<CollisionsHandler>
    {
        private void OnCollisionEnter(Collision other)
        {
            if (!Entity.Has<CollisionEvent>())
            {
                Entity.AddComponent<CollisionEvent>();
            }
        }
    }
}