using System;
using ReplaceStateAlteringConditionalsWithState.MyWork.States;

namespace ReplaceStateAlteringConditionalsWithState.MyWork
{
    public class SystemPermission
    {
        private SystemProfile _profile = null;
        private SystemUser _requestor = null;

        private SystemAdmin _admin;
        private Boolean _isGranted = false;

        private Boolean _isUnixPermissionGranted;
        private PermissionState _permissionState;

        public SystemPermission(SystemUser requestor, SystemProfile profile) {
            this._requestor = requestor;
            this._profile = profile;
            this._admin = new SystemAdmin();

            this._isGranted = false;
            this._isUnixPermissionGranted = false;
            
            this.NotifyAdminOfPermissionRequest();
            this.SetState(PermissionState.REQUESTED); // start state
        }

        public SystemProfile GetProfile()
        {
            return this._profile; 
        }

        public void SetIsUnixPermissionGranted(Boolean isUnixPermissionGranted)
        {
             this._isUnixPermissionGranted = isUnixPermissionGranted;
        }

        public void SetIsGranted(Boolean isGranted)
        {
             this._isGranted = isGranted; 
        }

        public SystemAdmin GetAdmin()
        {
            return this._admin;
        }

        public PermissionState GetState()
        {
            return this._permissionState;
        }

        public void SetState(PermissionState state)
        {
            this._permissionState = state;
        }

        public Boolean IsUnixPermissionGranted()
        {
            return this._isUnixPermissionGranted;
        }

        public Boolean IsGranted()
        {
            return this._isGranted;
        }

        private void NotifyAdminOfPermissionRequest()
        {
            
        }

        public void ClaimedBy(SystemAdmin admin) {
            
            this._permissionState.ClaimedBy(admin, this);
        }

        public void WillBeHandledBy(SystemAdmin systemAdmin)
        {
            
        }

        public void DeniedBy(SystemAdmin admin) {
            
            this._permissionState.DeniedBy(admin, this);
        }

        public void GrantedBy(SystemAdmin admin) {
            
            this._permissionState.GrantedBy(admin, this);
        }

        public Boolean IsInClaimedState()
        {
            return this.GetState().Equals(PermissionState.CLAIMED) && !this.GetState().Equals(PermissionState.UNIX_CLAIMED);
        }

        public Boolean IsUnixPermissionRequestedAndClaimed()
        {
            return this._profile.IsUnixPermissionRequired() && this.GetState().Equals(PermissionState.UNIX_CLAIMED);
        }

        public Boolean IsUnixPermissionDesiredButNotRequested()
        {
            return this._profile.IsUnixPermissionRequired() && !this.IsUnixPermissionGranted();
        }

        public void NotifyUnixAdminsOfPermissionRequest()
        {
            throw new NotImplementedException();
        }

        public void NotifyUserOfPermissionRequestResult()
        {
            throw new NotImplementedException();
        }

    }
}
