using System;
using System.Collections.Generic;

namespace ReplaceHardCodedNotificationsWithObserver.MyWork.Observer
{
    // Concrete Subject
    public class TestResult
    {
        private readonly List<ITestListener> _observers = new List<ITestListener>();

        public TestResult()
        {

        }

        public void AddObserver(ITestListener testListener)
        {
            this._observers.Add(testListener);
        }

        public void AddFailure(Test test, Exception exception)
        {
            foreach (ITestListener observer in this._observers)
            {
                observer.AddFailure(this, test, exception);  // notification to TestRunner    
            }
        }

        public void AddError(Test test, Exception exception)
        {
            foreach (ITestListener observer in this._observers)
            {
                observer.AddError(this, test, exception);    
            }
        }

        public void StartTest(Test test)
        {
            foreach (ITestListener observer in this._observers)
            {
                observer.StartTest(this, test);    
            }
        }

        public void EndTest(Test test)
        {
            foreach (ITestListener observer in this._observers)
            {
                observer.EndTest(this, test);    
            }
        }
    }
}