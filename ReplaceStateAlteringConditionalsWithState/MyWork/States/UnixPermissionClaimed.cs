namespace ReplaceStateAlteringConditionalsWithState.MyWork.States
{
    public sealed class UnixPermissionClaimed : PermissionState
    {
        public UnixPermissionClaimed() : base("UNIX_CLAIMED")
        {
        }

        public override void DeniedBy(SystemAdmin admin, SystemPermission systemPermission) {
            
            if (!systemPermission.GetAdmin().Equals(admin))
                return;

            systemPermission.SetIsGranted(false);
            systemPermission.SetIsUnixPermissionGranted(false);
            systemPermission.SetState(PermissionState.DENIED);

            systemPermission.NotifyUserOfPermissionRequestResult();
        }

        public override void GrantedBy(SystemAdmin admin, SystemPermission systemPermission) {
            
            if (!systemPermission.GetAdmin().Equals(admin))
                return;

            if (systemPermission.GetProfile().IsUnixPermissionRequired())
                systemPermission.SetIsUnixPermissionGranted(true);
            else if (systemPermission.IsUnixPermissionDesiredButNotRequested())
            {
                systemPermission.SetState(PermissionState.UNIX_REQUESTED);
                systemPermission.NotifyUnixAdminsOfPermissionRequest();
                return;
            }

            systemPermission.SetState(PermissionState.GRANTED);
            systemPermission.SetIsGranted(true);
            systemPermission.NotifyUserOfPermissionRequestResult();
        }
    }
}