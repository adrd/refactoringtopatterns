using System;
using LimitInstantiationWithSingleton.InitialCode.States;

namespace LimitInstantiationWithSingleton.InitialCode
{
    public class SystemPermission
    {
        private PermissionState _permissionState;

        public SystemPermission() 
        {
            this.SetState(new PermissionRequested()); // start state
        }

        public void SetState(PermissionState permissionState)
        {
            this._permissionState = permissionState;
        }

        public void WillBeHandledBy(SystemAdmin admin)
        {
            throw new NotImplementedException();
        }
    }
}