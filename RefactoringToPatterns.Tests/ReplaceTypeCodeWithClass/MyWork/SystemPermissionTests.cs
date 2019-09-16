using NUnit.Framework;
using ReplaceTypeCodeWithClass.MyWork;

namespace RefactoringToPatterns.Tests.ReplaceTypeCodeWithClass.MyWork
{
    [TestFixture()]
    public class SystemPermissionTests
    {
        [Test]
        public void TestDefaultsToPermissionRequested()
        {
            // Arrange
            SystemPermission systemPermission = new SystemPermission();

            // Act

            // Assert
            Assert.AreEqual(PermissionState.Requested,  systemPermission.GetPermissionState());
            // Assert.AreEqual("REQUESTED", systemPermission.GetPermissionState());
        }


    }
}