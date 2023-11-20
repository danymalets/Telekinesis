using UnityEngine;

namespace Sources.Constants
{
    public static class Balance
    {
        public const float PlayerSpeed = 3f;
        public const float PlayerAngularSpeed = 20f;
        
        public const float CameraBackDistance = 3f;
        public const float CameraUpDistance = 2.5f;
        public const float CameraAngle = 20f;
        
        public const float MaxDistanceToPickUp = 2.5f;
        
        public const float FlyObjectMass = 1f;
        public const float ObjectMoveTime = 0.21f;
        public const float VelocityChangeThrowForce = 10f;
        public const float PlayerAcceleration = 15f;

        public static readonly Vector3 PickableRelatedPosition = new(0, 2, 2);
    }
}