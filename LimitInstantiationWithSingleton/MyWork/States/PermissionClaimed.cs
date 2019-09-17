using System;

namespace LimitInstantiationWithSingleton.MyWork.States
{
    public sealed class PermissionClaimed : PermissionState
    {
        // Class/Type data
        private static readonly PermissionState Claimed = new PermissionClaimed("CLAIMED");

        // Instance/Object data
        private readonly String _name;

        private PermissionClaimed(String name)
        {
            this._name = name;
        }

        // Example of: Creation Method
        public static PermissionState CreatePermissionState()
        {
            return PermissionClaimed.Claimed;
        }

        public String GetName()
        {
            return this._name;
        }
    }
}