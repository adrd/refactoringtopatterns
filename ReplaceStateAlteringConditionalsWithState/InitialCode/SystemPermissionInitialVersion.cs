using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplaceStateAlteringConditionalsWithState.InitialCode
{
    public class SystemPermissionInitialVersion
    {
        private SystemProfile _profile;
        private SystemUser _requestor;

        private SystemAdmin _admin;
        private Boolean _isGranted;
        private String _state;

        public static readonly String REQUESTED = "REQUESTED";
        public static readonly String CLAIMED = "CLAIMED";
        public static readonly String GRANTED = "GRANTED";
        public static readonly String DENIED = "DENIED";

        public SystemPermissionInitialVersion(SystemUser requestor, SystemProfile profile) {
            this._requestor = requestor;
            this._profile = profile;
            this._state = REQUESTED;
            this._isGranted = false;
            this.NotifyAdminOfPermissionRequest();
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
            throw new NotImplementedException();
        }

        public void ClaimedBy(SystemAdmin admin) {
            
            if (!this._state.Equals(REQUESTED))
                return;

            this.WillBeHandledBy(admin);
            this._state = CLAIMED;
        }

        private void WillBeHandledBy(SystemAdmin systemAdmin)
        {
            throw new NotImplementedException();
        }

        public void DeniedBy(SystemAdmin admin) {
            
            if (!this._state.Equals(CLAIMED))
                return;

            if (!this._admin.Equals(admin))
                return;

            this._isGranted = false;
            this._state = DENIED;
            this.NotifyUserOfPermissionRequestResult();
        }

        public void GrantedBy(SystemAdmin admin) {
            
            if (!this._state.Equals(CLAIMED))
                return;

            if (!this._admin.Equals(admin))
                return;

            this._state = GRANTED;
            this._isGranted = true;
            this.NotifyUserOfPermissionRequestResult();
        }

        private void NotifyUserOfPermissionRequestResult()
        {
            throw new NotImplementedException();
        }


    }
}
