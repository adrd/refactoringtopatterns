using System;

namespace ExtractAdapter.MyWork.Adapter
{
    // Adaptee
    public class SDLoginSession
    {
        private String _configFileName;
        private Boolean v;

        public SDLoginSession(String configFileName, Boolean v)
        {
            this._configFileName = configFileName;
            this.v = v;
        }

        public void LoginSession(String server, String user, String password)
        {
            throw new NotImplementedException();
        }

        public SDQuery CreateQuery(Object openForQuery)
        {
            throw new NotImplementedException();
        }
    }
}