using System;

namespace ReplaceStateAlteringConditionalsWithState.InitialCode
{
    public class SystemPermission
    {
        private SystemProfile _profile = null;
        private SystemUser _requestor = null;

        private SystemAdmin _admin;
        private Boolean _isGranted = false;
        private String _state = String.Empty;

        public static readonly String REQUESTED = "REQUESTED";
        public static readonly String CLAIMED = "CLAIMED";
        public static readonly String GRANTED = "GRANTED";
        public static readonly String DENIED = "DENIED";
        public static readonly String UNIX_REQUESTED = "UNIX_REQUESTED";
        public static readonly String UNIX_CLAIMED = "UNIX_CLAIMED";

        private Boolean _isUnixPermissionGranted;

        public SystemPermission(SystemUser requestor, SystemProfile profile) {
            this._requestor = requestor;
            this._profile = profile;
            this._admin = new SystemAdmin();

            this._state = REQUESTED;
            this._isGranted = false;
            this._isUnixPermissionGranted = false;
            
            this.NotifyAdminOfPermissionRequest();
        }

        public Boolean IsUnixPermissionGranted()
        {
            return this._isUnixPermissionGranted;
        }

        public Boolean IsGranted()
        {
            return this._isGranted;
        }

        public String GetState()
        {
            return this._state;
        }

        private void NotifyAdminOfPermissionRequest()
        {
            
        }

        public void ClaimedBy(SystemAdmin admin) {
            
            if (!this._state.Equals(REQUESTED) && !this._state.Equals(UNIX_REQUESTED))
                return;

            this.WillBeHandledBy(admin);

            if (this._state.Equals(REQUESTED))
                this._state = CLAIMED;
            else if (this._state.Equals(UNIX_REQUESTED)) 
                this._state = UNIX_CLAIMED;
        }

        private void WillBeHandledBy(SystemAdmin systemAdmin)
        {
            
        }

        public void DeniedBy(SystemAdmin admin) {
            
            if (!this._state.Equals(CLAIMED) && !this._state.Equals(UNIX_CLAIMED))
                return;

            if (!this._admin.Equals(admin))
                return;

            this._isGranted = false;
            this._isUnixPermissionGranted = false;
            this._state = DENIED;

            this.NotifyUserOfPermissionRequestResult();
        }

        public void GrantedBy(SystemAdmin admin) {
            
            if (!this.IsInClaimedState())
                return;

            if (!this._admin.Equals(admin))
                return;

            if (this.IsUnixPermissionRequestedAndClaimed())
                this._isUnixPermissionGranted = true;
            else if (this.IsUnixPermissionDesiredButNotRequested())
            {
                this._state = UNIX_REQUESTED;
                this.NotifyUnixAdminsOfPermissionRequest();
                return;
            }

            this._state = GRANTED;
            this._isGranted = true;
            this.NotifyUserOfPermissionRequestResult();
        }

        private Boolean IsInClaimedState()
        {
            return this._state.Equals(CLAIMED) && !this._state.Equals(UNIX_CLAIMED);
        }

        private Boolean IsUnixPermissionRequestedAndClaimed()
        {
            return this._profile.IsUnixPermissionRequired() && this._state.Equals(UNIX_CLAIMED);
        }

        private Boolean IsUnixPermissionDesiredButNotRequested()
        {
            return this._profile.IsUnixPermissionRequired() && !this.IsUnixPermissionGranted();
        }

        private void NotifyUnixAdminsOfPermissionRequest()
        {
            throw new NotImplementedException();
        }

        private void NotifyUserOfPermissionRequestResult()
        {
            throw new NotImplementedException();
        }


    }
}
