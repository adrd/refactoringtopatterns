using System;

namespace ExtractAdapter.InitialCode
{
    public class SDLogin
    {
        public SDSession LoginSession(String server, String user, String password)
        {
            throw new NotImplementedException();
        }

        public void LoginToDatabase(String db, String user, String password)
        {
            Query query = new Query();

            try
            {
                if (this.UsingSDVersion52())
                {
                    query.Login(db, user, password, this.GetSD52ConfigFileName()); // Login to SD 5.2
                }
                else
                {
                    query.Login(db, user, password); // Login to SD 5.1
                }
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