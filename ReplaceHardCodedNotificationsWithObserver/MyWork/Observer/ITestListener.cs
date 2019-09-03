using System;

namespace ReplaceHardCodedNotificationsWithObserver.MyWork.Observer
{
    // Abstract Observer
    public interface ITestListener
    {
        void AddFailure(TestResult testResult, Test test, Exception exception);
        void AddError(TestResult testResult, Test test, Exception exception);
        void StartTest(TestResult testResult, Test test);
        void EndTest(TestResult testResult, Test test);
    }
}