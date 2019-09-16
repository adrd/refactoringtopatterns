using System;

namespace LimitInstantiationWithSingleton.InitialCode.States
{
    public sealed class PermissionRequested : PermissionState
    {
        public static readonly String NAME= "REQUESTED";

        public PermissionRequested()
        {
           
        }

        public String GetName()
        {
            return PermissionRequested.NAME;
        }

        public override void ClaimedBy(SystemAdmin admin, SystemPermission systemPermission)
        {
            systemPermission.WillBeHandledBy(admin);

            systemPermission.SetState(new PermissionClaimed());

        }
    }
}
