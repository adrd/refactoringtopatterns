using System;

namespace ExtractAdapter.InitialCode
{
    public class QueryException : Exception
    {
        public static readonly String LOGIN_FAILED = "Login Failed";

        public QueryException(Object loginFailed, Object o, Exception exception)
        {
            throw new NotImplementedException();
        }
    }
}