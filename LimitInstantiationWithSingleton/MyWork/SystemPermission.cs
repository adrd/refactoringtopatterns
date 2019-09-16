using System;
using LimitInstantiationWithSingleton.MyWork.States;

namespace LimitInstantiationWithSingleton.MyWork
{
    public class SystemPermission
    {
        private PermissionState _permissionState;

        public SystemPermission() 
        {
            this.SetState(PermissionRequested.CreatePermissionState()); // start state
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