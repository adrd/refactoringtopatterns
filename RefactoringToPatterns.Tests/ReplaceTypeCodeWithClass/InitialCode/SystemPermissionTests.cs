using NUnit.Framework;
using NUnit.Framework.Internal;
using ReplaceTypeCodeWithClass.InitialCode;

namespace RefactoringToPatterns.Tests.ReplaceTypeCodeWithClass.InitialCode
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
            Assert.AreEqual(SystemPermission.Requested,  systemPermission.GetState());
            Assert.AreEqual("REQUESTED", systemPermission.GetState());
        }


    }
}