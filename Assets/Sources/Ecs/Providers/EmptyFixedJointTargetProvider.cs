using Scellecs.Morpeh.Providers;
using Sources.Ecs.Components;
using UnityEngine;

namespace Sources.Ecs.Providers
{
    public class EmptyFixedJointTargetProvider : MonoProvider<EmptyFixedJointTarget>
    {
        [SerializeField]
        private Rigidbody _fakeTarget;
        
        protected override void Initialize()
        {
            GetData().Rigidbody = _fakeTarget;
        }
    }
}