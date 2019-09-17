using System;

namespace LimitInstantiationWithSingleton.MyWork.States
{
    public sealed class PermissionRequested : PermissionState
    {
        // Class/Type data
        private static readonly PermissionState Requested = new PermissionRequested("REQUESTED");

        // Instance/Object data
        private readonly String _name;

        private PermissionRequested(String name)
        {
            this._name = name;
        }

        // Example of: Creation Method
        public static PermissionState CreatePermissionState()
        {
            return PermissionRequested.Requested;
        }

        public String GetName()
        {
            return this._name;
        }

        public override void ClaimedBy(SystemAdmin admin, SystemPermission systemPermission)
        {
            systemPermission.WillBeHandledBy(admin);

            systemPermission.SetState(PermissionClaimed.CreatePermissionState());
        }
    }
}
