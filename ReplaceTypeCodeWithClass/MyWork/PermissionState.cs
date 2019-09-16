using System;

namespace ReplaceTypeCodeWithClass.MyWork
{
    public class PermissionState
    {
        public static readonly PermissionState Requested = new PermissionState("REQUESTED");
        public static readonly PermissionState Claimed = new PermissionState("CLAIMED");
        public static readonly PermissionState Granted = new PermissionState("GRANTED");
        public static readonly PermissionState Denied = new PermissionState("DENIED");

        private readonly String _name;

        private PermissionState(String name)
        {
            this._name = name;
        }

        public override String ToString()
        {
            return this._name;
        }
    }
}