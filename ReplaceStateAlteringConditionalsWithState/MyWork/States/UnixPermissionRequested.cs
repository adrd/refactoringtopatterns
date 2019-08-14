namespace ReplaceStateAlteringConditionalsWithState.MyWork.States
{
    public sealed class UnixPermissionRequested : PermissionState
    {
        public UnixPermissionRequested() : base("UNIX_REQUESTED")
        {
        }

        public override void ClaimedBy(SystemAdmin admin, SystemPermission systemPermission) {
            
            systemPermission.WillBeHandledBy(admin);

            systemPermission.SetState(PermissionState.UNIX_CLAIMED);
        }
    }
}