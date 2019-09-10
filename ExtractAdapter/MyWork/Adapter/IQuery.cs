using System;

namespace ExtractAdapter.MyWork.Adapter
{
    public interface IQuery
    {
        void Login(String server, String user, String password);
        void DoQuery();
    }
}