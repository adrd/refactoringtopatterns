namespace ReplaceStateAlteringConditionalsWithState.MyWork.States
{
    public sealed class PermissionDenied : PermissionState
    {
        public PermissionDenied() : base("DENIED")
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
    }
}