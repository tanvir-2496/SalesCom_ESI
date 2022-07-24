using System;
using System.Data.OracleClient;

namespace POS.DAL
{

    public class DBTransaction :IDisposable
    {
        internal OracleTransaction CurrentTransaction = null;
        private OracleConnection conn = new OracleConnection(Connection.ConnectionString);

        public void Begin()
        {
            
            conn.Open();
            CurrentTransaction =  conn.BeginTransaction();
        }

        public void Commit()
        {
            CurrentTransaction.Commit();
        }

        public void RollBack()
        {
            CurrentTransaction.Rollback();
           
        }

        public void Dispose()
        {
            CurrentTransaction.Dispose();
            conn.Dispose();

        }

        #region IDisposable Members

         void  IDisposable.Dispose()
        {
            CurrentTransaction.Dispose();
            conn.Dispose();
        }

        #endregion
    }
}
