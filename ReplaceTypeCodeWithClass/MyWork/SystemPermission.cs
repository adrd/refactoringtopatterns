using System;

namespace ReplaceTypeCodeWithClass.MyWork
{
    public class SystemPermission
    {
        private PermissionState _permissionState;

        private Boolean _granted;

        public SystemPermission()
        {
            this.SetPermissionState(PermissionState.Requested);
            this._granted = false;
        }

        public PermissionState GetPermissionState() => this._permissionState;

        private void SetPermissionState(PermissionState permissionState) => this._permissionState = permissionState;

        public Boolean IsGranted() => this._granted;

        public void Claim() 
        {
            if (this.GetPermissionState().Equals(PermissionState.Requested)) 
                this.SetPermissionState(PermissionState.Claimed);
        }

        public void Deny() 
        {
            if (this.GetPermissionState().Equals( PermissionState.Claimed)) 
                this.SetPermissionState(PermissionState.Denied);
        }

        public void Grant() {
            
            if (!this.GetPermissionState().Equals(PermissionState.Claimed)) 
                return;

            this.SetPermissionState(PermissionState.Granted);
            this._granted = true;
        }
    }
}
