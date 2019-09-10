using System;

namespace ExtractAdapter.MyWork.Adapter
{
    // Concrete Adapter
    public sealed class QuerySD51 : AbstractQuery
    {
        private SDLogin _sdLogin;               
        private SDSession _sdSession;           

        public QuerySD51() : base()
        {
            
        }

        public override void Login(String server, String user, String password)
        {
            try
            {
                this._sdSession = this._sdLogin.LoginSession(server, user, password);
            }
            catch (SDLoginFailedException lfe)
            {
                throw new QueryException(QueryException.LOGIN_FAILED, "Login failure\n" + lfe, lfe);
            }
            catch (SDSocketInitFailedException ife)
            {
                throw new QueryException(QueryException.LOGIN_FAILED, "Socket fail\n" + ife, ife);
            }
        }

        protected override SDQuery CreateQuery()
        {
            return this._sdSession.CreateQuery(SDQuery.OPEN_FOR_QUERY);
        }
    }
}