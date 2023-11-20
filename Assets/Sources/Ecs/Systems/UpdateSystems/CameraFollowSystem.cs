using Scellecs.Morpeh;
using Sources.Constants;
using Sources.Ecs.Components;
using Sources.Utils.MorpehEcsUtils;
using UnityEngine;

namespace Sources.Ecs.Systems.UpdateSystems
{
    public class CameraFollowSystem : ISystem
    {
        private Filter _playerFilter;
        private Filter _cameraFilter;
        public World World { get; set; }

        public void OnAwake()
        {
            _playerFilter = World.Filter
                .With<PlayerTag>()
                .WithMonoReference<Transform>()
                .Build();

            _cameraFilter = World.Filter
                .With<CameraTag>()
                .WithMonoReference<Transform>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            if (_playerFilter.GetLengthSlow() == 0)
            {
                return;
            }

            Entity playerEntity = _playerFilter.First();
            Transform playerTransform = playerEntity.GetComponentReference<Transform>();

            foreach (Entity cameraEntity in _cameraFilter)
            {
                Transform cameraTransform = cameraEntity.GetComponentReference<Transform>();

                cameraTransform.position = playerTransform.position
                                           - playerTransform.forward * Balance.CameraBackDistance
                                           + playerTransform.up * Balance.CameraUpDistance;

                cameraTransform.eulerAngles = new Vector3(
                    Balance.CameraAngle, playerTransform.transform.eulerAngles.y, 0);
            }
        }

        public void Dispose()
        {
        }
    }
}