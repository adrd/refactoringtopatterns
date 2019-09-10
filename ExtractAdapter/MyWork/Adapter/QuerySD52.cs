using System;

namespace ExtractAdapter.MyWork.Adapter
{
    // Concrete Adapter
    public sealed class QuerySD52 : AbstractQuery
    {
        private SDLoginSession _sdLoginSession;
        private String _sdConfigFileName;

        public QuerySD52(String sdConfigFileName) : base()
        {
            this._sdConfigFileName = sdConfigFileName;
        }

        public override void Login(String server, String user, String password)
        {
            this._sdLoginSession = new SDLoginSession(this._sdConfigFileName, false);
        
            try {
                this._sdLoginSession.LoginSession(server, user, password);
            } 
            catch (SDLoginFailedException lfe) {
                throw new QueryException(QueryException.LOGIN_FAILED, "Login failure\n" + lfe, lfe);
            } 
            catch (SDSocketInitFailedException ife) {
                throw new QueryException(QueryException.LOGIN_FAILED, "Socket fail\n" + ife, ife);
            } 
            catch (SDNotFoundException nfe) { 
                throw new QueryException(QueryException.LOGIN_FAILED, "Not found exception\n" + nfe, nfe);
            }
        }

        protected override SDQuery CreateQuery()
        {
            return this._sdLoginSession.CreateQuery(SDQuery.OPEN_FOR_QUERY);
        }

    }
}