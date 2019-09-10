using System;

namespace ExtractAdapter.InitialCode
{
    public class Query
    {
        private SDLogin _sdLogin;               // needed for SD version 5.1
        private SDSession _sdSession;           // needed for SD version 5.1
        private SDLoginSession _sdLoginSession; // needed for SD version 5.2
        private Boolean _sd52;                  // tells if we’re running under SD 5.2
        private SDQuery _sdQuery;               // this is needed for SD versions 5.1 & 5.2

        // this is a login for SD 5.1
        // NOTE: remove this when we convert all applications to 5.2
        public void Login(String server, String user, String password)
        {
            this._sd52 = false;

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

        // 5.2 login
        public void Login(String server, String user, String password, String sdConfigFileName) 
        {
            this._sd52 = true;
        
            this._sdLoginSession = new SDLoginSession(sdConfigFileName, false);
        
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

        public void DoQuery() 
        {
            if (this._sdQuery != null)
                this._sdQuery.ClearResultSet();
        
            if (this._sd52)
              this._sdQuery = this._sdLoginSession.CreateQuery(SDQuery.OPEN_FOR_QUERY);
            else
              this._sdQuery = this._sdSession.CreateQuery(SDQuery.OPEN_FOR_QUERY);

            this.ExecuteQuery();
        }

        private void ExecuteQuery()
        {
            throw new NotImplementedException();
        }
    }
}
