using System.ComponentModel;
using Scellecs.Morpeh.Providers;
using Sources.Ecs.Components;
using UnityEngine;

namespace Sources.Ecs.Providers
{
    [RequireComponent(typeof(Rigidbody))]
    public class MassProvider : MonoProvider<Mass>
    {
        protected override void Initialize()
        {
            GetData().Value = GetComponent<Rigidbody>().mass;
        }
    }
}