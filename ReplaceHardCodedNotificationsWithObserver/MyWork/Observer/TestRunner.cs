using System;

namespace ReplaceHardCodedNotificationsWithObserver.MyWork.Observer
{
    // Concrete Observer
    public class TestRunner : Frame, ITestListener
    {
        private TestResult _testResult;

        protected TestResult CreateTestResult() 
        {
            TestResult testResult = new TestResult();
            testResult.AddObserver(this);

            return testResult;
        }

        public void RunSuite() 
        {
            this._testResult = this.CreateTestResult();
        }

        public void AddFailure(TestResult testResult, Test test, Exception exception)
        {
            Console.WriteLine("F");
        }

        public void AddError(TestResult testResult, Test test, Exception exception) 
        {
            Console.WriteLine("E");
        }

        public void StartTest(TestResult testResult, Test test)
        {
            throw new NotImplementedException();
        }

        public void EndTest(TestResult testResult, Test test)
        {
            throw new NotImplementedException();
        }
    }
}