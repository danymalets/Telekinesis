using Scellecs.Morpeh;
using Sources.Ecs.Components;
using Sources.Ecs.Systems.FixedSystems;
using Sources.Ecs.Systems.UpdateSystems;
using Sources.Utils.MorpehEcsUtils;
using UnityEngine;

namespace Sources.Ecs
{
    [DefaultExecutionOrder(-1000)]
    public class GameRunner : MonoBehaviour
    {
        private void Awake()
        {
            World world = World.Default;
            
            SystemsGroup fixedGroup = world.CreateSystemsGroup();
            world.AddSystemsGroup(order: 0, fixedGroup);
            
            SystemsGroup updateGroup = world.CreateSystemsGroup();
            world.AddSystemsGroup(order: 1, updateGroup);
            
            // fixed systems
            fixedGroup.AddSystem(new PlayerAngularVelocityApplySystem());
            fixedGroup.AddSystem(new VelocityApplySystem());
            fixedGroup.AddSystem(new ObjectInHandProgressSystem());
            fixedGroup.AddSystem(new ConnectObjectSystem());
            fixedGroup.AddFixedOneFrame<CollisionEvent>();
            
            // update systems
            updateGroup.AddSystem(new PlayerSpeedCalculateSystem());
            updateGroup.AddSystem(new SmoothSpeedCalculateSystem());

            updateGroup.AddSystem(new AnimatorSpeedApplySystem());
            updateGroup.AddSystem(new CameraFollowSystem());
            updateGroup.AddSystem(new AccessibleObjectFindSystem());
            
            updateGroup.AddSystem(new AbilityHandlerSystem());
            updateGroup.AddSystem(new ThrowOnCollisionSystem());
            updateGroup.AddSystem(new PickupSystem());
            updateGroup.AddSystem(new TimeInHandIncreaseSystem());
            updateGroup.AddSystem(new ThrowSystem());

            updateGroup.AddOneFrame<PickupRequest>();
            updateGroup.AddOneFrame<ThrowRequest>();
        }
    }
}