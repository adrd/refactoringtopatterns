using System;

namespace ReplaceHardCodedNotificationsWithObserver.InitialCode
{
    public class UITestResult : TestResult 
    {
        private readonly TestRunner _testRunner;

        public UITestResult(TestRunner testRunner) 
        {
            this._testRunner = testRunner;
        }

        protected override void AddFailure(Test test, Exception exception) 
        {
            base.AddFailure(test, exception);
            
            this._testRunner.AddFailure(this, test, exception); // notification to TestRunner
        }
    }
}
