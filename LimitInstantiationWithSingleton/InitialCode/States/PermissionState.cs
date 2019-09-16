namespace LimitInstantiationWithSingleton.InitialCode.States
{
    public class PermissionState
    {
        public virtual void ClaimedBy(SystemAdmin admin, SystemPermission systemPermission) {
            
        }

        public virtual void DeniedBy(SystemAdmin admin, SystemPermission systemPermission) {
            
        }

        public virtual void GrantedBy(SystemAdmin admin, SystemPermission systemPermission) {
            
        }
    }
}