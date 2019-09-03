using System;

namespace ReplaceHardCodedNotificationsWithObserver.InitialCode
{
    public class TestRunner : Frame   
    {
        private TestResult _testResult;

        protected TestResult CreateTestResult() 
        {
            return new UITestResult(this); // hard-coded to UITestResult
        }

        public void RunSuite() 
        {
            this._testResult = this.CreateTestResult();
            // testSuite.run(this._testResult);
        }

        public void AddFailure(UITestResult uiTestResult, Test test, Exception exception)
        {
            // display the failure in a graphical window
            throw new System.NotImplementedException();
        }
    }
}