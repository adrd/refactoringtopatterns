using NUnit.Framework;
using ReplaceStateAlteringConditionalsWithState.MyWork;
using ReplaceStateAlteringConditionalsWithState.MyWork.States;

namespace RefactoringToPatterns.Tests.ReplaceStateAlteringConditionalsWithState.MyWork
{
    [TestFixture]
    public class SystemPermissionTests
    {
        private SystemPermission _permission;

        [SetUp]
        public void SetUp()
        {
            SystemUser user = new SystemUser();
            SystemProfile profile = new SystemProfile();
            this._permission = new SystemPermission(user, profile);
        }

        [Test]
        public void TestGrantedBy() {
            SystemAdmin admin = new SystemAdmin();
            this._permission.GrantedBy(admin);
            
            // "requested"
            Assert.AreEqual(PermissionState.REQUESTED, this._permission.GetState());
            // "not granted"
            Assert.AreEqual(false, this._permission.IsGranted());

            this._permission.ClaimedBy(admin);
            this._permission.GrantedBy(admin);

            // "claimed"
            Assert.AreEqual(PermissionState.CLAIMED, this._permission.GetState());
            Assert.AreEqual(false, this._permission.IsGranted());
        }
    }
}