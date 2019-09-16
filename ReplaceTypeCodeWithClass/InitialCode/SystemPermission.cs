using System;

namespace ReplaceTypeCodeWithClass.InitialCode
{
    public class SystemPermission
    {
        public static readonly String Requested = "REQUESTED";
        public static readonly String Claimed = "CLAIMED";
        public static readonly String Granted = "GRANTED";
        public static readonly String Denied = "DENIED";
        
        private String _state;  // Type-unsafe field
        private Boolean _granted;

        public SystemPermission()
        {
            this._state = Requested;
            this._granted = false;
        }

        public String GetState() => this._state;

        public Boolean IsGranted() => this._granted;

        public void Claim() 
        {
            if (this._state.Equals(Requested)) 
                this._state = Claimed;
        }

        public void Deny() 
        {
            if (this._state.Equals(Claimed)) 
                this._state = Denied;
        }

        public void Grant() {
            
            if (!this._state.Equals(Claimed)) 
                return;

            this._state = Granted;
            this._granted = true;
        }

        
    }
}
