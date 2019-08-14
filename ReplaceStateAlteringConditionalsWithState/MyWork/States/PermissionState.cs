using System;

namespace ReplaceStateAlteringConditionalsWithState.MyWork.States
{
    public abstract class PermissionState
    {
        // Instance/Object data
        private String _name;

        // Class/Type data
        public static readonly PermissionState REQUESTED = new PermissionRequested();
        public static readonly PermissionState CLAIMED = new PermissionClaimed();
        public static readonly PermissionState GRANTED = new PermissionGranted();
        public static readonly PermissionState DENIED = new PermissionDenied();
        public static readonly PermissionState UNIX_REQUESTED = new UnixPermissionRequested();
        public static readonly PermissionState UNIX_CLAIMED = new UnixPermissionClaimed();

        protected PermissionState(String name)
        {
            this._name = name;
        }

        public override String ToString()
        {
            return this._name;
        }

        public virtual void ClaimedBy(SystemAdmin admin, SystemPermission systemPermission) {
            
        }

        public virtual void DeniedBy(SystemAdmin admin, SystemPermission systemPermission) {
            
        }

        public virtual void GrantedBy(SystemAdmin admin, SystemPermission systemPermission) {
            
        }
    }
}