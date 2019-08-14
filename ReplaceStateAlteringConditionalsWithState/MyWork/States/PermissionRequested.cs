namespace ReplaceStateAlteringConditionalsWithState.MyWork.States
{
    public sealed class PermissionRequested : PermissionState
    {
        public PermissionRequested() : base("REQUESTED")
        {
           
        }

        public override void ClaimedBy(SystemAdmin admin, SystemPermission systemPermission) {
            
            systemPermission.WillBeHandledBy(admin);
            
            systemPermission.SetState(PermissionState.CLAIMED);
            
        }
    }
}