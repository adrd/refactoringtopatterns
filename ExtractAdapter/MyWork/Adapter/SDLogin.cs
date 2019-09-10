using System;

namespace ExtractAdapter.MyWork.Adapter
{
    // Adaptee
    public class SDLogin
    {
        public SDSession LoginSession(String server, String user, String password)
        {
            throw new NotImplementedException();
        }

        public void LoginToDatabase(String db, String user, String password)
        {
            IQuery query;

            if (this.UsingSDVersion52())
                query = new QuerySD52(this.GetSD52ConfigFileName());
            else
                query = new QuerySD51();

            try
            {
                query.Login(db, user, password);
            }
            catch (QueryException qe)
            {

            }
        }

        private Boolean UsingSDVersion52()
        {
            throw new NotImplementedException();
        }

        private String GetSD52ConfigFileName()
        {
            throw new NotImplementedException();
        }
    }
}