using System;

namespace ExtractAdapter.MyWork.Adapter
{
    // Abstract Adapter
    public abstract class AbstractQuery : IQuery
    {
        protected SDQuery _sdQuery;               

        public abstract void Login(String server, String user, String password);

        // Example of: Factory Method
        protected abstract SDQuery CreateQuery();

        // Example of: Template Method
        public virtual void DoQuery()
        {
            if (this._sdQuery != null)
                this._sdQuery.ClearResultSet();

            this._sdQuery = this.CreateQuery();       // call to the Factory Method

            this.ExecuteQuery();
        }

        protected virtual void ExecuteQuery()
        {
            throw new NotImplementedException();
        }
    }
}
