using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data;

namespace SalesCom.DAL
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
